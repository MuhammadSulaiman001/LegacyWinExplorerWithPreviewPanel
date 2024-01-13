using System;

namespace WpfCustomFileDialog;

public abstract class PreviewViewBase : ControlAddOnBase
{
    public abstract void PreviewCallback(string selectedFilePath);

    protected PreviewViewBase()
    {
        Loaded += (_, _) => ParentDlg.EventFileNameChanged += OnFileChanged;
        Unloaded += (_, _) => ParentDlg.EventFileNameChanged -= OnFileChanged;
    }

    private void OnFileChanged(IFileDlgExt sender, string filepath) => PreviewCallback(filepath);
}

public static class LegacyOpenFileDialogHelper
{
    public static void OpenCustomFileDialog<T>(
        Action<string> onFileChosen,
        string title = "Select File",
        string initialDirectory = null,
        string filter = "Everything|*.*",
        Action onDialogClosed = null
    ) where T : PreviewViewBase, new()
    {
        var ofd = new OpenFileDialog<T>
        {
            Title = title,
            Multiselect = false,
            InitialDirectory = initialDirectory,
            FileDlgStartLocation = AddonWindowLocation.Right,
            FileDlgDefaultViewMode = NativeMethods.FolderViewMode.Icon,
            FileDlgEnableOkBtn = false,
            Filter = filter
        };

        var res = ofd.ShowDialog();
        if (res != null && res.Value)
        {
            var chosenFilePath = ofd.FileName;
            onFileChosen?.Invoke(chosenFilePath);
        }

        onDialogClosed?.Invoke();
    }
}