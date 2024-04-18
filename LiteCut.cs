namespace TighteningStrap
{
    public partial class LiteCut : Form
    {
        public LiteCut()
        {
            InitializeComponent();
        }

        private void PickFileButton_Click(object sender, EventArgs e)
        {
            var result = FileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {

            }
        }
    }
}