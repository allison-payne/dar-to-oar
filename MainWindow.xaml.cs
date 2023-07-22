using NLog.Config;
using oar_explorer.OARStructures;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using oar_explorer.OARStructures.Conditions;
using oar_explorer.Utils;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Windows.Media.Animation;

namespace oar_explorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<SubmodConfig> submodConfigs;
        private ProjectConfig? projectConfig;
        private DirectoryInfo[]? submodStructure;

        public MainWindow()
        {
            InitializeComponent();

            // create a configuration instance
            LoggingConfiguration config = new LoggingConfiguration();

            // create a console logging target
            var logTarget = new NLog.Targets.FileTarget() { FileName = "${basedir}\\oar_explorer.log", ArchiveOldFileOnStartup = true };

            // send logs with levels from Info to Fatal to the console
            config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, logTarget);

            // apply the configuration
            NLog.LogManager.Configuration = config;
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();

            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                loadConditionFiles(folderDialog.SelectedPath);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void loadConditionFiles(string folderPath)
        {
            var animationReplacerDirectory = new DirectoryInfo(@$"{folderPath}\{PathConstants.MESHES}")
                .GetDirectories("*", SearchOption.AllDirectories)
                .First(arg => arg.FullName.Contains(PathConstants.DAR_FOLDER) || arg.FullName.Contains(PathConstants.OAR_FOLDER));

            submodConfigs = new ObservableCollection<SubmodConfig>();
            lvSubmods.ItemsSource = submodConfigs;

            if (animationReplacerDirectory.Name == PathConstants.DAR_FOLDER)
            {
                var darDirectory = new DirectoryInfo(@$"{animationReplacerDirectory.FullName}\{PathConstants.DAR_CONDITIONS}");
                txtImportPath.Text = darDirectory.FullName;
                var directories = darDirectory.GetDirectories();

                foreach (var directory in directories)
                {
                    SubmodConfig submodConfig = new();
                    var lines = File.ReadAllLines(@$"{directory.FullName}\{PathConstants.DAR_CONFIG_NAME}").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToArray();

                    submodConfig.name = directory.Name;
                    submodConfig.priority = int.Parse(directory.Name);
                    submodConfig.conditions = Converter.parseConditions(lines);

                    submodConfigs.Add(submodConfig);
                }

                projectConfig = new ProjectConfig()
                {
                    name = new DirectoryInfo(folderPath).Name,
                    description = "",
                    author = ""
                };

            }
            else if (animationReplacerDirectory.Name == PathConstants.OAR_FOLDER)
            {
                var oarDirectory = new DirectoryInfo(@$"{animationReplacerDirectory.FullName}");
                txtImportPath.Text = oarDirectory.FullName;
                var directories = oarDirectory.GetDirectories();

                foreach (var directory in directories)
                {
                    var submodDirectories = directory.GetDirectories();

                    foreach (var submodDirectory in submodDirectories)
                    {
                        var submodConfig = JsonConvert.DeserializeObject<SubmodConfig>(File.ReadAllText($@"{submodDirectory.FullName}\{PathConstants.OAR_CONFIG_NAME}"));
                        submodConfigs.Add(submodConfig);
                    }
                }

                projectConfig = JsonConvert.DeserializeObject<ProjectConfig>(File.ReadAllText($@"{oarDirectory.FullName}\{PathConstants.OAR_CONFIG_NAME}"));

            }

        }

        private void SaveOARStructure()
        {
            var folderPath = txtImportPath.Text;

            if (folderPath.Contains(PathConstants.DAR_FOLDER))
            {
                folderPath = folderPath.Replace(@$"\{PathConstants.DAR_CONDITIONS}", "").Replace(PathConstants.DAR_FOLDER, PathConstants.OAR_FOLDER);
                folderPath += @$"\{projectConfig.name}";
                Directory.CreateDirectory(folderPath.Replace(@$"\{PathConstants.DAR_CONDITIONS}", "").Replace(PathConstants.DAR_FOLDER, PathConstants.OAR_FOLDER) + @$"\{projectConfig.name}");
            }
        }

        private void CreateProjectConfigFile()
        {
            var folderPath = txtImportPath.Text;


        }

        private void CreateSubmodConfigFiles()
        {
            foreach (var submod in submodStructure)
            {
                var writer = File.CreateText(submod.FullName);
                writer.Write(JsonConvert.SerializeObject)
            }
        }


    }
}
