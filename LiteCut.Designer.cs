namespace TighteningStrap
{
    partial class LiteCut
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
            FileDialog = new OpenFileDialog();
            PickFileButton = new Button();
            FileNameTextBox = new TextBox();
            StartTimeTextBox = new TextBox();
            EndTimeTextBox = new TextBox();
            DashLabel = new Label();
            CompressButton = new Button();
            SmallSizeRadioButton = new RadioButton();
            MidSizeRadioButton = new RadioButton();
            LargeSizeRadioButton = new RadioButton();
            MergeAudioTrackCheckBox = new CheckBox();
            TopLabel = new Label();
            ProgressBar = new ProgressBar();
            SuspendLayout();
            // 
            // FileDialog
            // 
            FileDialog.FileName = "file";
            FileDialog.InitialDirectory = "./";
            // 
            // PickFileButton
            // 
            PickFileButton.Location = new Point(285, 66);
            PickFileButton.Name = "PickFileButton";
            PickFileButton.Size = new Size(75, 23);
            PickFileButton.TabIndex = 0;
            PickFileButton.Text = "Pick file";
            PickFileButton.UseVisualStyleBackColor = true;
            PickFileButton.Click += PickFileButton_Click;
            // 
            // FileNameTextBox
            // 
            FileNameTextBox.Location = new Point(23, 66);
            FileNameTextBox.Name = "FileNameTextBox";
            FileNameTextBox.Size = new Size(229, 23);
            FileNameTextBox.TabIndex = 2;
            // 
            // StartTimeTextBox
            // 
            StartTimeTextBox.Location = new Point(23, 95);
            StartTimeTextBox.Name = "StartTimeTextBox";
            StartTimeTextBox.Size = new Size(105, 23);
            StartTimeTextBox.TabIndex = 3;
            // 
            // EndTimeTextBox
            // 
            EndTimeTextBox.Location = new Point(152, 95);
            EndTimeTextBox.Name = "EndTimeTextBox";
            EndTimeTextBox.Size = new Size(100, 23);
            EndTimeTextBox.TabIndex = 4;
            // 
            // DashLabel
            // 
            DashLabel.AutoSize = true;
            DashLabel.Location = new Point(134, 98);
            DashLabel.Name = "DashLabel";
            DashLabel.Size = new Size(12, 15);
            DashLabel.TabIndex = 5;
            DashLabel.Text = "-";
            // 
            // CompressButton
            // 
            CompressButton.Location = new Point(152, 273);
            CompressButton.Name = "CompressButton";
            CompressButton.Size = new Size(75, 23);
            CompressButton.TabIndex = 6;
            CompressButton.Text = "Compress!";
            CompressButton.UseVisualStyleBackColor = true;
            CompressButton.Click += CompressButton_Click;
            // 
            // SmallSizeRadioButton
            // 
            SmallSizeRadioButton.AutoSize = true;
            SmallSizeRadioButton.Location = new Point(266, 143);
            SmallSizeRadioButton.Name = "SmallSizeRadioButton";
            SmallSizeRadioButton.Size = new Size(49, 19);
            SmallSizeRadioButton.TabIndex = 7;
            SmallSizeRadioButton.TabStop = true;
            SmallSizeRadioButton.Text = "8MB";
            SmallSizeRadioButton.UseVisualStyleBackColor = true;
            // 
            // MidSizeRadioButton
            // 
            MidSizeRadioButton.AutoSize = true;
            MidSizeRadioButton.Location = new Point(266, 168);
            MidSizeRadioButton.Name = "MidSizeRadioButton";
            MidSizeRadioButton.Size = new Size(55, 19);
            MidSizeRadioButton.TabIndex = 8;
            MidSizeRadioButton.TabStop = true;
            MidSizeRadioButton.Text = "25MB";
            MidSizeRadioButton.UseVisualStyleBackColor = true;
            // 
            // LargeSizeRadioButton
            // 
            LargeSizeRadioButton.AutoSize = true;
            LargeSizeRadioButton.Location = new Point(266, 193);
            LargeSizeRadioButton.Name = "LargeSizeRadioButton";
            LargeSizeRadioButton.Size = new Size(61, 19);
            LargeSizeRadioButton.TabIndex = 9;
            LargeSizeRadioButton.TabStop = true;
            LargeSizeRadioButton.Text = "100MB";
            LargeSizeRadioButton.UseVisualStyleBackColor = true;
            // 
            // MergeAudioTrackCheckBox
            // 
            MergeAudioTrackCheckBox.AutoSize = true;
            MergeAudioTrackCheckBox.Location = new Point(23, 144);
            MergeAudioTrackCheckBox.Name = "MergeAudioTrackCheckBox";
            MergeAudioTrackCheckBox.Size = new Size(127, 19);
            MergeAudioTrackCheckBox.TabIndex = 10;
            MergeAudioTrackCheckBox.Text = "Merge audio tracks";
            MergeAudioTrackCheckBox.UseVisualStyleBackColor = true;
            // 
            // TopLabel
            // 
            TopLabel.AutoSize = true;
            TopLabel.Location = new Point(101, 30);
            TopLabel.Name = "TopLabel";
            TopLabel.Size = new Size(184, 15);
            TopLabel.TabIndex = 11;
            TopLabel.Text = "Welcome, pick a file to compress:";
            // 
            // ProgressBar
            // 
            ProgressBar.Location = new Point(23, 236);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(337, 23);
            ProgressBar.TabIndex = 12;
            // 
            // LiteCut
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 308);
            Controls.Add(ProgressBar);
            Controls.Add(TopLabel);
            Controls.Add(MergeAudioTrackCheckBox);
            Controls.Add(LargeSizeRadioButton);
            Controls.Add(MidSizeRadioButton);
            Controls.Add(SmallSizeRadioButton);
            Controls.Add(CompressButton);
            Controls.Add(DashLabel);
            Controls.Add(EndTimeTextBox);
            Controls.Add(StartTimeTextBox);
            Controls.Add(FileNameTextBox);
            Controls.Add(PickFileButton);
            Name = "LiteCut";
            Text = "TighteningStrap";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog FileDialog;
        private Button PickFileButton;
        private TextBox FileNameTextBox;
        private TextBox StartTimeTextBox;
        private TextBox EndTimeTextBox;
        private Label DashLabel;
        private Button CompressButton;
        private RadioButton SmallSizeRadioButton;
        private RadioButton MidSizeRadioButton;
        private RadioButton LargeSizeRadioButton;
        private CheckBox MergeAudioTrackCheckBox;
        private Label TopLabel;
        private ProgressBar ProgressBar;
    }
}