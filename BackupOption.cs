using Godot;
using System;
using System.IO.Compression;

public partial class BackupOption : HBoxContainer
{

    [Export] public FileDialog fileDialog;
    [Export] Button InitiateBackupButton;
    [Export] Label BackupPathLabel;
    string backupPath;
    public override void _Ready()
    {
        base._Ready();
        fileDialog.DirSelected += fileDialog_DirSelected;
        InitiateBackupButton.ButtonDown += Backup;

    }

    private void fileDialog_DirSelected(string dir)
    {
        backupPath = dir + @"\Backup.zip";
        BackupPathLabel.Text = dir;
        GD.Print("backup destination selected");

    }
    public void Backup()
    {
        string fromPath = BackupProgram.ProjectPath;
        string zipPath = backupPath;

        ZipFile.CreateFromDirectory(fromPath, zipPath);
        GD.PrintT("Individual backup", zipPath, "backed up");
    }
}
