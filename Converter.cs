using DARtoOAR.OARStructures;
using DARtoOAR.OARStructures.Conditions;
using DARtoOAR.OARStructures.Values;
using DARtoOAR.Utils;
using NLog;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

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
  

        private static JsonSerializerOptions serializerOptions = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        private static PluginValue GetPluginValue(string condition)
        {
            string[] conditionSplit = condition.Split("|", StringSplitOptions.TrimEntries);
            return new PluginValue()
            {
                pluginName = conditionSplit[0].Replace("\"", ""),
                formID = conditionSplit[1].Substring(2).TrimStart('0')
            };
        }
        private static KeywordValue GetKeywordValue(string condition)
        {
            // only PluginValue for DAR conversion
            string[] conditionSplit = condition.Split("|", StringSplitOptions.TrimEntries);
            return new KeywordValue()
            {
                form = new PluginValue()
                {
                    pluginName = conditionSplit[0].Replace("\"", ""),
                    formID = conditionSplit[1].Substring(2).TrimStart('0')
                }
            };
        }

        private static Condition parseCondition(string condition, bool isNegated = false)
        {
            var splitIndex = condition.IndexOf(")");
            string conditionToParse = condition;
            string conjunction = "";
            if (splitIndex > 0)
            {
                conditionToParse = condition.Substring(0, splitIndex);
                conjunction = condition.Substring(splitIndex + 1, condition.Length - splitIndex - 1);
            }
            string[] conditionSet = conditionToParse.Split(new string[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
            string conditionName = conditionSet[0];
            Condition cond;
            LOGGER.Debug($"Parsing -> condition: {conditionName}");
            switch (conditionName)
            {
                case "Random":
                    cond = new RandomCondition()
                    {
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
                        condition = conditionName,
                        negated = isNegated,
                        actorBase = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "IsInFaction":
                    cond = new IsInFaction()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        Faction = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "IsEquippedRightType":
                case "IsEquippedLeftType":
                    cond = new IsEquippedType
                    {
                        condition = "IsEquippedType",
                        negated = isNegated,
                        leftHand = conditionName.Equals("IsEquippedLeftType"),
                        typeValue = new TypeValue() { value = float.Parse(conditionSet[1]) }
                    };
                    break;
                case "IsEquippedRightHasKeyword":
                case "IsEquippedLeftHasKeyword":
                    cond = new IsEquippedHasKeyword
                    {
                        condition = conditionName,
                        negated = isNegated,
                        leftHand = conditionName.Equals("IsEquippedLeftHasKeyword"),
                        Keyword = new KeywordValue()
                        {
                            form = GetKeywordValue(conditionSet[1]).form
                        }
                    };
                    break;
                case "HasKeyword":
                    cond = new HasKeyword
                    {
                        condition = conditionName,
                        negated = isNegated,
                        Keyword = new KeywordValue()
                        {
                            form = GetKeywordValue(conditionSet[1]).form
                        }
                    };
                    break;
                case "IsMovementDirection":
                    cond = new NumericComparison()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        numericValue = new NumericValue() { value = float.Parse(conditionSet[1]) }
                    };
                    break;
                case "HasMagicEffect":
                    cond = new HasMagicEffect()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        magicEffect = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "HasMagicEffectWithKeyword":
                    cond = new HasMagicEffectWithKeyword
                    {
                        condition = conditionName,
                        negated = isNegated,
                        Keyword = new KeywordValue()
                        {
                            form = GetKeywordValue(conditionSet[1]).form
                        }
                    };
                    break;
                case "CurrentWeather":
                    cond = new CurrentWeather()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        Weather = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "IsInLocation":
                    cond = new IsInLocation()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        Location = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "IsWorn":
                    cond = new IsWorn()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        Form = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "IsWornHasKeyword":
                    cond = new IsWornHasKeyword()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        Keyword = new KeywordValue()
                        {
                            form = GetKeywordValue(conditionSet[1]).form
                        }
                    };
                    break;
                case "HasPerk":
                    cond = new HasPerk()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        Perk = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "HasSpell":
                    cond = new HasSpell()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        Spell = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "IsRace":
                    cond = new IsRace()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        Race = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "IsClass":
                    cond = new IsClass()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        Class = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "IsCombatStyle":
                    cond = new IsCombatStyle()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        CombatStyle = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "IsVoiceType":
                    cond = new IsVoiceType()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        VoiceType = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "HasRefType":
                    cond = new HasRefType()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        LocationRefType = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "IsParentCell":
                    cond = new IsParentCell()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        Cell = GetPluginValue(conditionSet[1])
                    };
                    break;
                case "IsWorldSpace":
                    cond = new IsWorldSpace()
                    {
                        condition = conditionName,
                        negated = isNegated,
                        Worldspace = GetPluginValue(conditionSet[1])
                    };
                    break;
                default:
                    LOGGER.Warn($"Condition({conditionName}) has no explicit mapping.");
                    cond = new Condition()
                    {
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
                string cleaned = condition.Replace(" ", "");
                bool isNegated = false;

                if (cleaned.StartsWith("NOT"))
                {
                    isNegated = true;
                    cleaned = cleaned.Replace("NOT", "");
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
