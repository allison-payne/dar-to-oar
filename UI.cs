using DARtoOAR.Components;

namespace DARtoOAR
{
    public partial class UI : Form
    {
        private const string DEFAULT_FOLDER_PATH = @"c:\Users";

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
            Converter.convertDARtoOAR(darModFolderPath.Text, oarModFolderPath.Text, modName.Text, modAuthor.Text);
        }

        private void darModFolderPath_TextChanged(object sender, EventArgs e)
        {
            oarModFolderPath.Text = darModFolderPath.Text;
            modName.Text = new DirectoryInfo(oarModFolderPath.Text).Name;
        }
    }
}