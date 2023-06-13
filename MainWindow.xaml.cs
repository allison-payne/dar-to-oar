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

namespace oar_explorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<SubmodConfig> submodConfigs;

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

        private void loadConditionFiles(string folderPath)
        {
            folderPath += "\\meshes\\actors\\character\\animations\\";
            bool darDirectoryExists = Directory.Exists(folderPath + "DynamicAnimationReplacer");
            bool oarDirectoryExists = Directory.Exists(folderPath + "OpenAnimationReplacer");

            submodConfigs = new ObservableCollection<SubmodConfig>();
            lvSubmods.ItemsSource = submodConfigs;

            DirectoryInfo[] directories;

            if (darDirectoryExists)
            {
                directories = new DirectoryInfo(folderPath + "DynamicAnimationReplacer\\" + "_CustomConditions\\").GetDirectories();
                txtImportPath.Text = folderPath + "DynamicAnimationReplacer\\" + "_CustomConditions\\";
                foreach (var directory in directories)
                {
                    SubmodConfig submodConfig = new ();
                    var lines = File.ReadAllLines(directory.FullName + "\\_conditions.txt").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToArray();

                    submodConfig.name = directory.Name;
                    submodConfig.priority = int.Parse(directory.Name);
                    submodConfig.conditions = Converter.parseConditions(lines);

                    submodConfigs.Add(submodConfig);
                }
            } else if (oarDirectoryExists)
            {
                directories = new DirectoryInfo(folderPath + "OpenAnimationReplacer\\").GetDirectories();

                foreach (var directory in directories)
                {
                    var submodDirectories = directory.GetDirectories();
                    txtImportPath.Text = directory.FullName;
                    txtOutputPath.Text = directory.FullName;

                    foreach (var submodDirectory in submodDirectories)
                    {
                        SubmodConfig submodConfig = new();
                        submodConfig = JsonConvert.DeserializeObject<SubmodConfig>(File.ReadAllText(submodDirectory.FullName + "\\config.json"));
                        submodConfigs.Add(submodConfig);
                    }

                }
            }
            
        }
    }
}
