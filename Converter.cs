using DARtoOAR.OARStructures;
using DARtoOAR.OARStructures.Conditions;
using DARtoOAR.OARStructures.Values;
using DARtoOAR.Utils;
using NLog;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DARtoOAR
{
    internal class Converter
    {
        private static string ACTOR_FOLDER_PATH = @"meshes\actors\";
        private static string ANIMATION_FOLDER_PATH = @"\animations\";
        private static string DAR_FOLDER = "DynamicAnimationReplacer";
        private static string DAR_CONDITIONS_FOLDER = "_CustomConditions";
        private static string OAR_FOLDER = "OpenAnimationReplacer";
        private static string DAR_CONDITIONS_FILE_NAME = "_conditions.txt";
        private static string CONFIG_FILE_NAME = "config.json";
        private static string CONFIG_FILE_DEFAULT_VERSION = "1.0.0.0";

        private static JsonSerializerOptions serializerOptions = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        private static PluginValue GetPluginValue(string condition)
        {
            string[] conditionSplit = condition.Split('|', StringSplitOptions.TrimEntries);
            return new PluginValue()
            {
                pluginName = conditionSplit[0].Replace("\"", ""),
                formID = conditionSplit[1].Substring(2).TrimStart('0')
            };
        }
        private static Condition parseCondition(string condition, bool isNegated = false)
        {
            var splitIndex = condition.LastIndexOf(" ");
            string conditionToParse = condition;
            string conjunction = "";
            if (splitIndex > 0)
            {
                conditionToParse = condition.Substring(0, splitIndex);
                conjunction = condition.Substring(splitIndex + 1, condition.Length - splitIndex - 1);
            }
            string[] conditionSet = conditionToParse.Split(new string[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
            string conditionName = conditionSet[0];
            Condition cond = new Condition();
            LOGGER.Debug($"Parsing condition: {conditionName}");
            switch (conditionName)
            {
                case "Random":
                    cond = new RandomCondition()
                    {
                        requiredVersion = CONFIG_FILE_DEFAULT_VERSION,
                        condition = conditionName,
                        negated = isNegated,
                        Comparison = "<=",
                        randomValue = new RandomValue() { min = 0, max = 1 },
                        numericValue = new NumericValue() { value = float.Parse(conditionSet[1]) }
                    };
                    break;
                case "IsActorBase":
                    cond = new IsActorBase()
                    {
                        requiredVersion = CONFIG_FILE_DEFAULT_VERSION,
                        condition = conditionName,
                        negated = isNegated,
                        actorBase = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "IsInFaction":
                    cond = new IsInFaction()
                    {
                        requiredVersion = CONFIG_FILE_DEFAULT_VERSION,
                        condition = conditionName,
                        negated = isNegated,
                        Faction = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "IsEquippedRightType":
                case "IsEquippedLeftType":
                    cond = new IsEquippedType
                    {
                        requiredVersion = CONFIG_FILE_DEFAULT_VERSION,
                        condition = "IsEquippedType",
                        negated = isNegated,
                        leftHand = conditionName.Equals("IsEquippedLeftType"),
                        typeValue = new TypeValue() { value = float.Parse(conditionSet[1]) }
                    };
                    break;
                case "IsEquippedHasKeyword":
                    cond = new EquippedHasKeyword
                    {
                        requiredVersion = CONFIG_FILE_DEFAULT_VERSION,
                        condition = conditionName,
                        negated = isNegated,
                        leftHand = conditionName.Equals("IsEquippedLeftType"),
                        Keyword = new FormValue()
                        {
                            Form = GetPluginValue(conditionSet[1])
                        }
                    };
                    break;
                case "IsMovementDirection":
                    cond = new NumericComparison()
                    {
                        requiredVersion = CONFIG_FILE_DEFAULT_VERSION,
                        condition = conditionName,
                        negated = isNegated,
                        numericValue = new NumericValue() { value = float.Parse(conditionSet[1]) }
                    };
                    break;
                case "HasMagicEffect":
                    cond = new HasMagicEffect()
                    {
                        requiredVersion = CONFIG_FILE_DEFAULT_VERSION,
                        condition = conditionName,
                        negated = isNegated,
                        magicEffect = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "CurrentWeather":
                    cond = new CurrentWeather()
                    {
                        requiredVersion = CONFIG_FILE_DEFAULT_VERSION,
                        condition = conditionName,
                        negated = isNegated,
                        Weather = GetPluginValue(conditionSet[1])
                    };
                    break;
                default:
                    LOGGER.Warn($"Condition({conditionName}) has no value. This can be intentional, or it can be due to an as yet umapped condition.");
                    cond = new Condition()
                    {
                        requiredVersion = CONFIG_FILE_DEFAULT_VERSION,
                        condition = conditionName,
                        negated = isNegated,
                    };
                    break;
            }
            return cond;
        }
        private static List<Condition> parseConditions(string[] conditions)
        {
            List<Condition> result = new List<Condition>();
            foreach (string condition in conditions)
            {
                string cleaned = condition;
                bool isNegated = false;

                if (condition.StartsWith("AND"))
                {
                    cleaned = condition.Split(' ', 2)[1].Trim();
                    result.Add(parseCondition(cleaned));
                }
                else if (condition.StartsWith("OR"))
                {
                    cleaned = condition.Split(' ', 2)[1].Trim();
                    MessageBox.Show(cleaned);
                }

                if (cleaned.StartsWith("NOT"))
                {
                    isNegated = true;
                    cleaned = cleaned.Split(' ', 2)[1].Trim();
                }
                result.Add(parseCondition(cleaned, isNegated));


            }
            return result;
        }
        private static async Task<DirectoryInfo> GenerateMainConfigFile(DirectoryInfo darActorFolder, DirectoryInfo oarModFolder, string? modName, string? author = "")
        {

            MainConfig mc = new MainConfig()
            {
                author = author,
                name = String.IsNullOrEmpty(modName) ? oarModFolder.Name : modName,
                description = ""
            };

            string oarModPath = $"{oarModFolder.FullName}\\{ACTOR_FOLDER_PATH}\\{darActorFolder.Name}\\{ANIMATION_FOLDER_PATH}\\{OAR_FOLDER}\\{mc.name}";
            string filePath = $"{oarModPath}\\{CONFIG_FILE_NAME}";
            FileInfo configFileInfo = new FileInfo(filePath);
            if (configFileInfo.Directory != null)
            {
                configFileInfo.Directory.Create();
            }

            // TODO: Add some better error handling here.
            await using FileStream createStream = File.Create(filePath);
            await JsonSerializer.SerializeAsync(createStream, mc, serializerOptions);
            return new DirectoryInfo(oarModPath);
        }
        private static async Task<List<DirectoryInfo>> BuildOARDirectories(DirectoryInfo oarModFolder, string darModFolder, bool overwrite, string? modName, string? modAuthor)
        {
            DirectoryInfo darDirectoryInfo = new DirectoryInfo(darModFolder);
            DirectoryInfo[] darActorFolders = darDirectoryInfo.GetDirectories(ACTOR_FOLDER_PATH);

            List<DirectoryInfo> animationsDirectories = new List<DirectoryInfo>();
            foreach (DirectoryInfo darActorFolder in darActorFolders)
            {
                DirectoryInfo oarAnimationsFolder = await GenerateMainConfigFile(darActorFolder, oarModFolder, modName, modAuthor);
                animationsDirectories.Add(oarAnimationsFolder);
                DirectoryInfo darConditionsFolder = new DirectoryInfo($"{darActorFolder.FullName}\\{ANIMATION_FOLDER_PATH}\\{DAR_FOLDER}\\{DAR_CONDITIONS_FOLDER}");
                DirectoryUtils.CopyDirectory(darConditionsFolder, oarAnimationsFolder, overwrite, true);
            }
            return animationsDirectories;
        }
        private static async void GenerateConditionsConfigFile(FileInfo conditionsFile)
        {
            // TODO: Add some better error handling here.
            Int32 priority = conditionsFile.Directory != null ? Int32.Parse(conditionsFile.Directory.Name) : 0;
            string name = conditionsFile.Directory != null ? conditionsFile.Directory.Name : "";
            string conditionsFolder = conditionsFile.DirectoryName != null ? conditionsFile.DirectoryName : "";

            string[] conditions = File.ReadAllLines(conditionsFile.FullName);
            LOGGER.Info($"Parsing conditions at path: {conditionsFile.DirectoryName}");
            List<Condition> conditionsList = parseConditions(conditions);
            ConditionsConfig config = new ConditionsConfig()
            {
                name = name,
                priority = priority,
                description = "",
                overrideAnimationsFolder = "",
                conditions = conditionsList.ToArray()
            };
            // TODO: Add some better error handling here.
            await using FileStream createStream = File.Create($"{conditionsFolder}\\{CONFIG_FILE_NAME}");
            await JsonSerializer.SerializeAsync<object>(createStream, config, serializerOptions);
            conditionsFile.Delete();
        }
        private static void ConvertConditions(List<DirectoryInfo> oarConditionsFolders)
        {
            foreach (DirectoryInfo directory in oarConditionsFolders)
            {
                FileInfo[] conditionsFiles = directory.GetFiles(DAR_CONDITIONS_FILE_NAME, SearchOption.AllDirectories);
                foreach (FileInfo conditionsFile in conditionsFiles)
                {
                    GenerateConditionsConfigFile(conditionsFile);
                }
            }
        }
        public static async void convertDARtoOAR(string darModFolder, string oarModFolderPath, string? modName, string? modAuthor)
        {
            DirectoryInfo oarModFolder = new DirectoryInfo(oarModFolderPath);
            List<DirectoryInfo> directories = await BuildOARDirectories(oarModFolder, darModFolder, true, modName, modAuthor);
            ConvertConditions(directories);
        }
    }
}
