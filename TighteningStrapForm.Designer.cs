namespace TighteningStrap
{
    partial class TighteningStrapForm
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
            SuspendLayout();
            // 
            // FileDialog
            // 
            FileDialog.CheckPathExists = false;
            FileDialog.FileName = "file";
            FileDialog.InitialDirectory = "./";
            // 
            // TighteningStrapForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 297);
            Name = "TighteningStrapForm";
            Text = "TighteningStrap";
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog FileDialog;
    }
}