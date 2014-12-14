namespace Mfc2Mvvm.Contracts
{
    public interface IFileDialogService
    {
        string OpenFileDialog(string fileName, string defaultExtension, string filter);
    }
}