namespace LiteCut
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
            CompressButton = new Button();
            MergeAudioTrackCheckBox = new CheckBox();
            TopLabel = new Label();
            ProgressBar = new ProgressBar();
            MbBox = new NumericUpDown();
            MBLabel = new Label();
            StartTimeBox = new NumericUpDown();
            EndTimeBox = new NumericUpDown();
            DashLabel = new Label();
            cutlabel = new Label();
            secondsstartlabel = new Label();
            SecondsEndLabel = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)MbBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartTimeBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EndTimeBox).BeginInit();
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
            FileNameTextBox.ReadOnly = true;
            FileNameTextBox.Size = new Size(229, 23);
            FileNameTextBox.TabIndex = 2;
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
            // MergeAudioTrackCheckBox
            // 
            MergeAudioTrackCheckBox.AutoSize = true;
            MergeAudioTrackCheckBox.Checked = true;
            MergeAudioTrackCheckBox.CheckState = CheckState.Checked;
            MergeAudioTrackCheckBox.Location = new Point(23, 169);
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
            // MbBox
            // 
            MbBox.Location = new Point(285, 144);
            MbBox.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            MbBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            MbBox.Name = "MbBox";
            MbBox.Size = new Size(48, 23);
            MbBox.TabIndex = 14;
            MbBox.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // MBLabel
            // 
            MBLabel.AutoSize = true;
            MBLabel.Location = new Point(339, 148);
            MBLabel.Name = "MBLabel";
            MBLabel.Size = new Size(25, 15);
            MBLabel.TabIndex = 15;
            MBLabel.Text = "MB";
            // 
            // StartTimeBox
            // 
            StartTimeBox.Location = new Point(23, 118);
            StartTimeBox.Name = "StartTimeBox";
            StartTimeBox.Size = new Size(105, 23);
            StartTimeBox.TabIndex = 16;
            StartTimeBox.ValueChanged += StartTimeBox_ValueChanged;
            // 
            // EndTimeBox
            // 
            EndTimeBox.Location = new Point(152, 118);
            EndTimeBox.Name = "EndTimeBox";
            EndTimeBox.Size = new Size(100, 23);
            EndTimeBox.TabIndex = 17;
            EndTimeBox.ValueChanged += EndTimeBox_ValueChanged;
            // 
            // DashLabel
            // 
            DashLabel.AutoSize = true;
            DashLabel.Location = new Point(134, 118);
            DashLabel.Name = "DashLabel";
            DashLabel.Size = new Size(12, 15);
            DashLabel.TabIndex = 18;
            DashLabel.Text = "-";
            // 
            // cutlabel
            // 
            cutlabel.AutoSize = true;
            cutlabel.Location = new Point(101, 100);
            cutlabel.Name = "cutlabel";
            cutlabel.Size = new Size(77, 15);
            cutlabel.TabIndex = 19;
            cutlabel.Text = "Cut between ";
            // 
            // secondsstartlabel
            // 
            secondsstartlabel.AutoSize = true;
            secondsstartlabel.Location = new Point(23, 146);
            secondsstartlabel.Name = "secondsstartlabel";
            secondsstartlabel.Size = new Size(105, 15);
            secondsstartlabel.TabIndex = 20;
            secondsstartlabel.Text = "seconds from start";
            // 
            // SecondsEndLabel
            // 
            SecondsEndLabel.AutoSize = true;
            SecondsEndLabel.Location = new Point(152, 146);
            SecondsEndLabel.Name = "SecondsEndLabel";
            SecondsEndLabel.Size = new Size(105, 15);
            SecondsEndLabel.TabIndex = 21;
            SecondsEndLabel.Text = "seconds from start";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(284, 118);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 22;
            label1.Text = "Compress to";
            // 
            // LiteCut
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 308);
            Controls.Add(label1);
            Controls.Add(SecondsEndLabel);
            Controls.Add(secondsstartlabel);
            Controls.Add(cutlabel);
            Controls.Add(DashLabel);
            Controls.Add(EndTimeBox);
            Controls.Add(StartTimeBox);
            Controls.Add(MBLabel);
            Controls.Add(MbBox);
            Controls.Add(ProgressBar);
            Controls.Add(TopLabel);
            Controls.Add(MergeAudioTrackCheckBox);
            Controls.Add(CompressButton);
            Controls.Add(FileNameTextBox);
            Controls.Add(PickFileButton);
            Name = "LiteCut";
            Text = "LiteCut";
            ((System.ComponentModel.ISupportInitialize)MbBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartTimeBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)EndTimeBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog FileDialog;
        private Button PickFileButton;
        private TextBox FileNameTextBox;
        private Button CompressButton;
        private CheckBox MergeAudioTrackCheckBox;
        private Label TopLabel;
        private ProgressBar ProgressBar;
        private NumericUpDown MbBox;
        private Label MBLabel;
        private NumericUpDown StartTimeBox;
        private NumericUpDown EndTimeBox;
        private Label DashLabel;
        private Label cutlabel;
        private Label secondsstartlabel;
        private Label SecondsEndLabel;
        private Label label1;
    }
}