using Godot;
using System;
using System.IO;
using System.IO.Compression;

public partial class BackupOption : HBoxContainer
{

    [Export] public FileDialog fileDialog;
    [Export] Button InitiateBackupButton;
    [Export] Label BackupPathLabel;
    public string backupPath;
    public override void _Ready()
    {
        base._Ready();
        fileDialog.DirSelected += fileDialog_DirSelected;
        InitiateBackupButton.ButtonDown += InitiateBackup;

    }

    public void fileDialog_DirSelected(string dir)
    {
        backupPath = dir + @"/Backup" + ".zip";
        BackupPathLabel.Text = dir;
        GD.Print("backup destination selected");

    }
    public async void InitiateBackup()
    {
        BackupProgram.PleaseWaitPopup.Show();
        Backup();
        BackupProgram.PleaseWaitPopup.Hide();

    }
    public async void Backup()
    {
        string fromPath = BackupProgram.ProjectPath;
        string zipPath = backupPath.Replace(".zip", Time.GetDatetimeStringFromSystem().Replace(":", "-") + ".zip");
        GD.PrintT("Trying to back up", zipPath);
        if (Godot.FileAccess.FileExists(zipPath))
        {
            File.Delete(zipPath);
        }
        ZipFile.CreateFromDirectory(fromPath, zipPath);
        GD.PrintT("Individual backup", zipPath, "backed up");
    }
}
