namespace LegacyWinExplorerWithPreviewPanel.Sample
{
    public partial class PreviewView
    {
        public PreviewView()
        {
            InitializeComponent();
        }

        public override void PreviewCallback(string selectedFilePath)
        {
            PreviewInfo.Text = $"Selected File: {selectedFilePath}";
        }
    }
}