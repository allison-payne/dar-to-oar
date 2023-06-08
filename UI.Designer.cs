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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
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
            darModFolderPath.Location = new Point(133, 47);
            darModFolderPath.Margin = new Padding(4, 5, 4, 5);
            darModFolderPath.Name = "darModFolderPath";
            darModFolderPath.Size = new Size(523, 31);
            darModFolderPath.TabIndex = 0;
            darModFolderPath.TextChanged += darModFolderPath_TextChanged;
            // 
            // darFolderPickerBtn
            // 
            darFolderPickerBtn.Location = new Point(17, 45);
            darFolderPickerBtn.Margin = new Padding(4, 5, 4, 5);
            darFolderPickerBtn.Name = "darFolderPickerBtn";
            darFolderPickerBtn.Size = new Size(107, 38);
            darFolderPickerBtn.TabIndex = 1;
            darFolderPickerBtn.Text = "Select Folder";
            darFolderPickerBtn.UseVisualStyleBackColor = true;
            darFolderPickerBtn.Click += darFolderPickerBtn_Click;
            // 
            // darModFolderPathLabel
            // 
            darModFolderPathLabel.AutoSize = true;
            darModFolderPathLabel.Location = new Point(17, 15);
            darModFolderPathLabel.Margin = new Padding(4, 0, 4, 0);
            darModFolderPathLabel.Name = "darModFolderPathLabel";
            darModFolderPathLabel.Size = new Size(146, 25);
            darModFolderPathLabel.TabIndex = 2;
            darModFolderPathLabel.Text = "DAR Mod Folder";
            // 
            // oarModFolderLabel
            // 
            oarModFolderLabel.AutoSize = true;
            oarModFolderLabel.Location = new Point(17, 125);
            oarModFolderLabel.Margin = new Padding(4, 0, 4, 0);
            oarModFolderLabel.Name = "oarModFolderLabel";
            oarModFolderLabel.Size = new Size(147, 25);
            oarModFolderLabel.TabIndex = 5;
            oarModFolderLabel.Text = "OAR Mod Folder";
            // 
            // oarFolderPickerBtn
            // 
            oarFolderPickerBtn.Location = new Point(17, 155);
            oarFolderPickerBtn.Margin = new Padding(4, 5, 4, 5);
            oarFolderPickerBtn.Name = "oarFolderPickerBtn";
            oarFolderPickerBtn.Size = new Size(107, 38);
            oarFolderPickerBtn.TabIndex = 4;
            oarFolderPickerBtn.Text = "Select Folder";
            oarFolderPickerBtn.UseVisualStyleBackColor = true;
            oarFolderPickerBtn.Click += oarFolderPickerBtn_Click;
            // 
            // oarModFolderPath
            // 
            oarModFolderPath.Location = new Point(133, 155);
            oarModFolderPath.Margin = new Padding(4, 5, 4, 5);
            oarModFolderPath.Name = "oarModFolderPath";
            oarModFolderPath.Size = new Size(523, 31);
            oarModFolderPath.TabIndex = 3;
            // 
            // convertBtn
            // 
            convertBtn.Location = new Point(17, 327);
            convertBtn.Margin = new Padding(4, 5, 4, 5);
            convertBtn.Name = "convertBtn";
            convertBtn.Size = new Size(177, 38);
            convertBtn.TabIndex = 6;
            convertBtn.Text = "Convert";
            convertBtn.UseVisualStyleBackColor = true;
            convertBtn.Click += convertBtn_Click;
            // 
            // modNameLabel
            // 
            modNameLabel.AutoSize = true;
            modNameLabel.Location = new Point(17, 232);
            modNameLabel.Margin = new Padding(4, 0, 4, 0);
            modNameLabel.Name = "modNameLabel";
            modNameLabel.Size = new Size(102, 25);
            modNameLabel.TabIndex = 8;
            modNameLabel.Text = "Mod Name";
            // 
            // modName
            // 
            modName.Location = new Point(17, 262);
            modName.Margin = new Padding(4, 5, 4, 5);
            modName.Name = "modName";
            modName.Size = new Size(294, 31);
            modName.TabIndex = 7;
            // 
            // modAuthorLabel
            // 
            modAuthorLabel.AutoSize = true;
            modAuthorLabel.Location = new Point(363, 232);
            modAuthorLabel.Margin = new Padding(4, 0, 4, 0);
            modAuthorLabel.Name = "modAuthorLabel";
            modAuthorLabel.Size = new Size(110, 25);
            modAuthorLabel.TabIndex = 10;
            modAuthorLabel.Text = "Mod Author";
            // 
            // modAuthor
            // 
            modAuthor.Location = new Point(363, 262);
            modAuthor.Margin = new Padding(4, 5, 4, 5);
            modAuthor.Name = "modAuthor";
            modAuthor.Size = new Size(294, 31);
            modAuthor.TabIndex = 9;
            // 
            // UI
            // 
            AcceptButton = convertBtn;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 390);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
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