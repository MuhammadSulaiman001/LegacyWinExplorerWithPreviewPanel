using System;
using System.Diagnostics;
using System.Windows;
using WpfCustomFileDialog;

namespace LegacyWinExplorerWithPreviewPanel.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LegacyOpenFileDialogWithPreview_OnClick(object sender, RoutedEventArgs e)
        {
            LegacyOpenFileDialogHelper.OpenCustomFileDialog<PreviewView>(
                // Callbacks
                onFileChosen: chosenFilePath => MessageBox.Show(chosenFilePath),
                onDialogClosed: () => Debug.WriteLine($"{nameof(PreviewView)} Closed"),
                // Customization
                title: "Select File",
                filter: "Everything|*.*",
                initialDirectory: Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            );
        }
    }
}