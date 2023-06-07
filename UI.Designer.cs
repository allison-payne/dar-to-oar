namespace DARtoOAR
{
    partial class UI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            darModFolderPath = new TextBox();
            darFolderPickerBtn = new Button();
            darModFolderPathLabel = new Label();
            oarModFolderLabel = new Label();
            oarFolderPickerBtn = new Button();
            oarModFolderPath = new TextBox();
            convertBtn = new Button();
            modNameLabel = new Label();
            modName = new TextBox();
            modAuthorLabel = new Label();
            modAuthor = new TextBox();
            SuspendLayout();
            // 
            // darModFolderPath
            // 
            darModFolderPath.Location = new Point(93, 28);
            darModFolderPath.Name = "darModFolderPath";
            darModFolderPath.Size = new Size(367, 23);
            darModFolderPath.TabIndex = 0;
            darModFolderPath.TextChanged += darModFolderPath_TextChanged;
            // 
            // darFolderPickerBtn
            // 
            darFolderPickerBtn.Location = new Point(12, 27);
            darFolderPickerBtn.Name = "darFolderPickerBtn";
            darFolderPickerBtn.Size = new Size(75, 23);
            darFolderPickerBtn.TabIndex = 1;
            darFolderPickerBtn.Text = "Select Folder";
            darFolderPickerBtn.UseVisualStyleBackColor = true;
            darFolderPickerBtn.Click += darFolderPickerBtn_Click;
            // 
            // darModFolderPathLabel
            // 
            darModFolderPathLabel.AutoSize = true;
            darModFolderPathLabel.Location = new Point(12, 9);
            darModFolderPathLabel.Name = "darModFolderPathLabel";
            darModFolderPathLabel.Size = new Size(94, 15);
            darModFolderPathLabel.TabIndex = 2;
            darModFolderPathLabel.Text = "DAR Mod Folder";
            // 
            // oarModFolderLabel
            // 
            oarModFolderLabel.AutoSize = true;
            oarModFolderLabel.Location = new Point(12, 75);
            oarModFolderLabel.Name = "oarModFolderLabel";
            oarModFolderLabel.Size = new Size(95, 15);
            oarModFolderLabel.TabIndex = 5;
            oarModFolderLabel.Text = "OAR Mod Folder";
            // 
            // oarFolderPickerBtn
            // 
            oarFolderPickerBtn.Location = new Point(12, 93);
            oarFolderPickerBtn.Name = "oarFolderPickerBtn";
            oarFolderPickerBtn.Size = new Size(75, 23);
            oarFolderPickerBtn.TabIndex = 4;
            oarFolderPickerBtn.Text = "Select Folder";
            oarFolderPickerBtn.UseVisualStyleBackColor = true;
            oarFolderPickerBtn.Click += oarFolderPickerBtn_Click;
            // 
            // oarModFolderPath
            // 
            oarModFolderPath.Location = new Point(93, 93);
            oarModFolderPath.Name = "oarModFolderPath";
            oarModFolderPath.Size = new Size(367, 23);
            oarModFolderPath.TabIndex = 3;
            // 
            // convertBtn
            // 
            convertBtn.Location = new Point(12, 196);
            convertBtn.Name = "convertBtn";
            convertBtn.Size = new Size(124, 23);
            convertBtn.TabIndex = 6;
            convertBtn.Text = "Convert";
            convertBtn.UseVisualStyleBackColor = true;
            convertBtn.Click += convertBtn_Click;
            // 
            // modNameLabel
            // 
            modNameLabel.AutoSize = true;
            modNameLabel.Location = new Point(12, 139);
            modNameLabel.Name = "modNameLabel";
            modNameLabel.Size = new Size(67, 15);
            modNameLabel.TabIndex = 8;
            modNameLabel.Text = "Mod Name";
            // 
            // modName
            // 
            modName.Location = new Point(12, 157);
            modName.Name = "modName";
            modName.Size = new Size(207, 23);
            modName.TabIndex = 7;
            // 
            // modAuthorLabel
            // 
            modAuthorLabel.AutoSize = true;
            modAuthorLabel.Location = new Point(254, 139);
            modAuthorLabel.Name = "modAuthorLabel";
            modAuthorLabel.Size = new Size(72, 15);
            modAuthorLabel.TabIndex = 10;
            modAuthorLabel.Text = "Mod Author";
            // 
            // modAuthor
            // 
            modAuthor.Location = new Point(254, 157);
            modAuthor.Name = "modAuthor";
            modAuthor.Size = new Size(207, 23);
            modAuthor.TabIndex = 9;
            // 
            // UI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 234);
            Controls.Add(modAuthorLabel);
            Controls.Add(modAuthor);
            Controls.Add(modNameLabel);
            Controls.Add(modName);
            Controls.Add(convertBtn);
            Controls.Add(oarModFolderLabel);
            Controls.Add(oarFolderPickerBtn);
            Controls.Add(oarModFolderPath);
            Controls.Add(darModFolderPathLabel);
            Controls.Add(darFolderPickerBtn);
            Controls.Add(darModFolderPath);
            Name = "UI";
            Text = "DAR to OAR Converter";
            Load += UI_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox darModFolderPath;
        private Button darFolderPickerBtn;
        private Label darModFolderPathLabel;
        private Label oarModFolderLabel;
        private Button oarFolderPickerBtn;
        private TextBox oarModFolderPath;
        private Button convertBtn;
        private Label modNameLabel;
        private TextBox modName;
        private Label modAuthorLabel;
        private TextBox modAuthor;
    }
}