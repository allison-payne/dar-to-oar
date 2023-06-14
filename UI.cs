using DARtoOAR.Components;
using NLog;

namespace DARtoOAR
{
    public partial class UI : Form
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        private static string DEFAULT_FOLDER_PATH = @"c:\Users";

        public UI()
        {
            InitializeComponent();
        }

        private void UI_Load(object sender, EventArgs e)
        {

        }

        private void darFolderPickerBtn_Click(object sender, EventArgs e)
        {
            var darFolderDlg = new FolderPicker();
            darFolderDlg.InputPath = DEFAULT_FOLDER_PATH;
            if (darFolderDlg.ShowDialog(darFolderPickerBtn.Handle) == true)
            {
                darModFolderPath.Text = darFolderDlg.ResultPath;
            }
        }

        private void oarFolderPickerBtn_Click(object sender, EventArgs e)
        {
            var oarFolderDlg = new FolderPicker();
            oarFolderDlg.InputPath = DEFAULT_FOLDER_PATH;
            if (oarFolderDlg.ShowDialog(oarFolderPickerBtn.Handle) == true)
            {
                oarModFolderPath.Text = oarFolderDlg.ResultPath;
            }
        }

        private void convertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Converter.convertDARtoOAR(darModFolderPath.Text, oarModFolderPath.Text, modName.Text, modAuthor.Text);
                MessageBox.Show("Conversion successful!");
            }
            catch (Exception ex)
            {
                LOGGER.Error(ex);
            }
        }

        private void darModFolderPath_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(darModFolderPath.Text))
            {
                oarModFolderPath.Text = darModFolderPath.Text;
                modName.Text = new DirectoryInfo(oarModFolderPath.Text).Name;
            }
        }
    }
}