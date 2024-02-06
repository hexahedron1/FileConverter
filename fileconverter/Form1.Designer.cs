namespace fileconverter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            BrowseImport = new Button();
            FromLabel = new Label();
            ImportPathBox = new TextBox();
            OpenFileDialog1 = new OpenFileDialog();
            TypeBox = new ComboBox();
            OutputNameBox = new TextBox();
            OutputPathBox = new TextBox();
            ToLabel = new Label();
            BrowseOutput = new Button();
            label3 = new Label();
            ConvertButton = new Button();
            Progressbar = new ProgressBar();
            FolderBrowserDialog1 = new FolderBrowserDialog();
            SettingsBox = new GroupBox();
            WatermarkHelp = new Button();
            WatermarkTextBox = new TextBox();
            WatermarkCheckBox = new CheckBox();
            SampleRateHelp = new Button();
            SampleRateBox = new ComboBox();
            SampleRateLabel = new Label();
            LangHelpButton = new Button();
            BitrateHelpButton = new Button();
            BitrateBox = new ComboBox();
            BitrateLabel = new Label();
            SaveSettingsButton = new Button();
            LanguageBox = new ComboBox();
            LangLabel = new Label();
            HelpButton = new Button();
            CancelButton = new Button();
            statusStrip1 = new StatusStrip();
            PercentageLabel = new ToolStripStatusLabel();
            EstTimeLabel = new ToolStripStatusLabel();
            SettingsBox.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BrowseImport
            // 
            BrowseImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BrowseImport.Location = new Point(494, 12);
            BrowseImport.Name = "BrowseImport";
            BrowseImport.Size = new Size(75, 24);
            BrowseImport.TabIndex = 0;
            BrowseImport.Text = "Browse...";
            BrowseImport.UseVisualStyleBackColor = true;
            BrowseImport.Click += BrowseImport_Click;
            // 
            // FromLabel
            // 
            FromLabel.AutoSize = true;
            FromLabel.Location = new Point(12, 16);
            FromLabel.Name = "FromLabel";
            FromLabel.Size = new Size(35, 15);
            FromLabel.TabIndex = 1;
            FromLabel.Text = "From";
            // 
            // ImportPathBox
            // 
            ImportPathBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ImportPathBox.BackColor = SystemColors.Window;
            ImportPathBox.Location = new Point(56, 13);
            ImportPathBox.Name = "ImportPathBox";
            ImportPathBox.PlaceholderText = "FIle path";
            ImportPathBox.Size = new Size(432, 23);
            ImportPathBox.TabIndex = 2;
            ImportPathBox.TextChanged += ImportPathBox_TextChanged;
            // 
            // OpenFileDialog1
            // 
            OpenFileDialog1.FileName = "openFileDialog1";
            // 
            // TypeBox
            // 
            TypeBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TypeBox.Enabled = false;
            TypeBox.FormattingEnabled = true;
            TypeBox.Location = new Point(494, 42);
            TypeBox.Name = "TypeBox";
            TypeBox.Size = new Size(75, 23);
            TypeBox.TabIndex = 3;
            TypeBox.SelectedIndexChanged += TypeBox_SelectedIndexChanged;
            // 
            // OutputNameBox
            // 
            OutputNameBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OutputNameBox.Location = new Point(402, 42);
            OutputNameBox.Name = "OutputNameBox";
            OutputNameBox.PlaceholderText = "File name";
            OutputNameBox.Size = new Size(70, 23);
            OutputNameBox.TabIndex = 4;
            OutputNameBox.TextChanged += OutputNameBox_TextChanged;
            // 
            // OutputPathBox
            // 
            OutputPathBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            OutputPathBox.Location = new Point(56, 42);
            OutputPathBox.Name = "OutputPathBox";
            OutputPathBox.PlaceholderText = "Path";
            OutputPathBox.Size = new Size(259, 23);
            OutputPathBox.TabIndex = 5;
            OutputPathBox.TextChanged += OutputPathBox_TextChanged;
            // 
            // ToLabel
            // 
            ToLabel.AutoSize = true;
            ToLabel.Location = new Point(12, 45);
            ToLabel.Name = "ToLabel";
            ToLabel.Size = new Size(19, 15);
            ToLabel.TabIndex = 6;
            ToLabel.Text = "To";
            // 
            // BrowseOutput
            // 
            BrowseOutput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BrowseOutput.Location = new Point(321, 42);
            BrowseOutput.Name = "BrowseOutput";
            BrowseOutput.Size = new Size(75, 23);
            BrowseOutput.TabIndex = 7;
            BrowseOutput.Text = "Browse";
            BrowseOutput.UseVisualStyleBackColor = true;
            BrowseOutput.Click += BrowseOutput_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(478, 50);
            label3.Name = "label3";
            label3.Size = new Size(10, 15);
            label3.TabIndex = 8;
            label3.Text = ".";
            // 
            // ConvertButton
            // 
            ConvertButton.Enabled = false;
            ConvertButton.Location = new Point(12, 71);
            ConvertButton.Name = "ConvertButton";
            ConvertButton.Size = new Size(110, 23);
            ConvertButton.TabIndex = 9;
            ConvertButton.Text = "Convert";
            ConvertButton.UseVisualStyleBackColor = true;
            ConvertButton.Click += ConvertButton_Click;
            // 
            // Progressbar
            // 
            Progressbar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Progressbar.Location = new Point(239, 71);
            Progressbar.MarqueeAnimationSpeed = 50;
            Progressbar.Maximum = 25;
            Progressbar.Name = "Progressbar";
            Progressbar.Size = new Size(249, 23);
            Progressbar.Step = 1;
            Progressbar.TabIndex = 10;
            // 
            // SettingsBox
            // 
            SettingsBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SettingsBox.Controls.Add(WatermarkHelp);
            SettingsBox.Controls.Add(WatermarkTextBox);
            SettingsBox.Controls.Add(WatermarkCheckBox);
            SettingsBox.Controls.Add(SampleRateHelp);
            SettingsBox.Controls.Add(SampleRateBox);
            SettingsBox.Controls.Add(SampleRateLabel);
            SettingsBox.Controls.Add(LangHelpButton);
            SettingsBox.Controls.Add(BitrateHelpButton);
            SettingsBox.Controls.Add(BitrateBox);
            SettingsBox.Controls.Add(BitrateLabel);
            SettingsBox.Controls.Add(SaveSettingsButton);
            SettingsBox.Controls.Add(LanguageBox);
            SettingsBox.Controls.Add(LangLabel);
            SettingsBox.Location = new Point(12, 100);
            SettingsBox.Name = "SettingsBox";
            SettingsBox.Size = new Size(557, 129);
            SettingsBox.TabIndex = 12;
            SettingsBox.TabStop = false;
            SettingsBox.Text = "Settings";
            // 
            // WatermarkHelp
            // 
            WatermarkHelp.Location = new Point(188, 95);
            WatermarkHelp.Name = "WatermarkHelp";
            WatermarkHelp.Size = new Size(23, 23);
            WatermarkHelp.TabIndex = 14;
            WatermarkHelp.Text = "?";
            WatermarkHelp.UseVisualStyleBackColor = true;
            WatermarkHelp.Click += WatermarkHelp_Click;
            // 
            // WatermarkTextBox
            // 
            WatermarkTextBox.Enabled = false;
            WatermarkTextBox.Location = new Point(6, 95);
            WatermarkTextBox.Name = "WatermarkTextBox";
            WatermarkTextBox.PlaceholderText = "Watermark text";
            WatermarkTextBox.Size = new Size(176, 23);
            WatermarkTextBox.TabIndex = 13;
            // 
            // WatermarkCheckBox
            // 
            WatermarkCheckBox.AutoSize = true;
            WatermarkCheckBox.Location = new Point(6, 71);
            WatermarkCheckBox.Name = "WatermarkCheckBox";
            WatermarkCheckBox.Size = new Size(84, 19);
            WatermarkCheckBox.TabIndex = 12;
            WatermarkCheckBox.Text = "Watermark";
            WatermarkCheckBox.UseVisualStyleBackColor = true;
            WatermarkCheckBox.CheckedChanged += WatermarkCheckBox_CheckedChanged;
            // 
            // SampleRateHelp
            // 
            SampleRateHelp.Location = new Point(448, 37);
            SampleRateHelp.Name = "SampleRateHelp";
            SampleRateHelp.Size = new Size(23, 23);
            SampleRateHelp.TabIndex = 10;
            SampleRateHelp.Text = "?";
            SampleRateHelp.UseVisualStyleBackColor = true;
            SampleRateHelp.Click += SampleRateHelp_Click;
            // 
            // SampleRateBox
            // 
            SampleRateBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SampleRateBox.FormattingEnabled = true;
            SampleRateBox.Items.AddRange(new object[] { "8000", "16000", "44100", "48000", "88200", "96000", "192000" });
            SampleRateBox.Location = new Point(307, 37);
            SampleRateBox.Name = "SampleRateBox";
            SampleRateBox.Size = new Size(135, 23);
            SampleRateBox.TabIndex = 9;
            // 
            // SampleRateLabel
            // 
            SampleRateLabel.AutoSize = true;
            SampleRateLabel.Location = new Point(307, 19);
            SampleRateLabel.Name = "SampleRateLabel";
            SampleRateLabel.Size = new Size(156, 15);
            SampleRateLabel.TabIndex = 8;
            SampleRateLabel.Text = "Sample rate (Hz, if available)";
            // 
            // LangHelpButton
            // 
            LangHelpButton.Location = new Point(104, 38);
            LangHelpButton.Name = "LangHelpButton";
            LangHelpButton.Size = new Size(23, 23);
            LangHelpButton.TabIndex = 6;
            LangHelpButton.Text = "?";
            LangHelpButton.UseVisualStyleBackColor = true;
            LangHelpButton.Click += LangHelpButton_Click;
            // 
            // BitrateHelpButton
            // 
            BitrateHelpButton.Location = new Point(278, 37);
            BitrateHelpButton.Name = "BitrateHelpButton";
            BitrateHelpButton.Size = new Size(23, 23);
            BitrateHelpButton.TabIndex = 5;
            BitrateHelpButton.Text = "?";
            BitrateHelpButton.UseVisualStyleBackColor = true;
            BitrateHelpButton.Click += BitrateHelpButton_Click;
            // 
            // BitrateBox
            // 
            BitrateBox.DropDownStyle = ComboBoxStyle.DropDownList;
            BitrateBox.FormattingEnabled = true;
            BitrateBox.Items.AddRange(new object[] { "128000", "192000", "256000", "320000" });
            BitrateBox.Location = new Point(133, 37);
            BitrateBox.Name = "BitrateBox";
            BitrateBox.Size = new Size(139, 23);
            BitrateBox.TabIndex = 4;
            BitrateBox.SelectedIndexChanged += BitrateBox_SelectedIndexChanged;
            // 
            // BitrateLabel
            // 
            BitrateLabel.AutoSize = true;
            BitrateLabel.Location = new Point(133, 19);
            BitrateLabel.Name = "BitrateLabel";
            BitrateLabel.Size = new Size(168, 15);
            BitrateLabel.TabIndex = 3;
            BitrateLabel.Text = "Audio bitrate (bps, if available)";
            // 
            // SaveSettingsButton
            // 
            SaveSettingsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveSettingsButton.Location = new Point(482, 100);
            SaveSettingsButton.Name = "SaveSettingsButton";
            SaveSettingsButton.Size = new Size(69, 23);
            SaveSettingsButton.TabIndex = 2;
            SaveSettingsButton.Text = "Save";
            SaveSettingsButton.UseVisualStyleBackColor = true;
            SaveSettingsButton.Click += SaveSettingsButton_Click;
            // 
            // LanguageBox
            // 
            LanguageBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LanguageBox.FormattingEnabled = true;
            LanguageBox.Location = new Point(6, 37);
            LanguageBox.Name = "LanguageBox";
            LanguageBox.Size = new Size(92, 23);
            LanguageBox.TabIndex = 1;
            LanguageBox.SelectedIndexChanged += LanguageBox_SelectedIndexChanged;
            // 
            // LangLabel
            // 
            LangLabel.AutoSize = true;
            LangLabel.Location = new Point(6, 19);
            LangLabel.Name = "LangLabel";
            LangLabel.Size = new Size(59, 15);
            LangLabel.TabIndex = 0;
            LangLabel.Text = "Language";
            // 
            // HelpButton
            // 
            HelpButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            HelpButton.Location = new Point(494, 71);
            HelpButton.Name = "HelpButton";
            HelpButton.Size = new Size(75, 23);
            HelpButton.TabIndex = 13;
            HelpButton.Text = "Help";
            HelpButton.UseVisualStyleBackColor = true;
            HelpButton.Click += HelpButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Enabled = false;
            CancelButton.Location = new Point(128, 71);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(105, 23);
            CancelButton.TabIndex = 14;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { PercentageLabel, EstTimeLabel });
            statusStrip1.Location = new Point(0, 232);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(581, 22);
            statusStrip1.TabIndex = 15;
            statusStrip1.Text = "statusStrip1";
            // 
            // PercentageLabel
            // 
            PercentageLabel.Name = "PercentageLabel";
            PercentageLabel.Size = new Size(35, 17);
            PercentageLabel.Text = "Idle...";
            // 
            // EstTimeLabel
            // 
            EstTimeLabel.Name = "EstTimeLabel";
            EstTimeLabel.Size = new Size(10, 17);
            EstTimeLabel.Text = " ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(581, 254);
            Controls.Add(statusStrip1);
            Controls.Add(CancelButton);
            Controls.Add(HelpButton);
            Controls.Add(SettingsBox);
            Controls.Add(Progressbar);
            Controls.Add(ConvertButton);
            Controls.Add(label3);
            Controls.Add(BrowseOutput);
            Controls.Add(ToLabel);
            Controls.Add(OutputPathBox);
            Controls.Add(OutputNameBox);
            Controls.Add(TypeBox);
            Controls.Add(ImportPathBox);
            Controls.Add(FromLabel);
            Controls.Add(BrowseImport);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "File converter";
            Load += Form1_Load;
            Shown += Form1_Shown;
            SettingsBox.ResumeLayout(false);
            SettingsBox.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BrowseImport;
        private Label FromLabel;
        private TextBox ImportPathBox;
        private OpenFileDialog OpenFileDialog1;
        private ComboBox TypeBox;
        private TextBox OutputNameBox;
        private TextBox OutputPathBox;
        private Label ToLabel;
        private Button BrowseOutput;
        private Label label3;
        private Button ConvertButton;
        private ProgressBar Progressbar;
        private FolderBrowserDialog FolderBrowserDialog1;
        private GroupBox SettingsBox;
        private Label LangLabel;
        private ComboBox LanguageBox;
        private Button SaveSettingsButton;
        private Label BitrateLabel;
        private ComboBox BitrateBox;
        private Button BitrateHelpButton;
        private Button HelpButton;
        private Button LangHelpButton;
        private Button CancelButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel PercentageLabel;
        private ToolStripStatusLabel EstTimeLabel;
        private Button SampleRateHelp;
        private ComboBox SampleRateBox;
        private Label SampleRateLabel;
        private TextBox WatermarkTextBox;
        private CheckBox WatermarkCheckBox;
        private Button WatermarkHelp;
    }
}