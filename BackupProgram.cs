using Godot;
using System;

public partial class BackupProgram : Panel
{
    public static string ProjectPath;
    public static Label PleaseWaitPopup;
    public static BackupProgram Instance;
    [Export] PackedScene BackupOptionScene;
    [Export] FileDialog fileDialog;
    [Export] Label ProjectPathLabel;
    [Export] BackupOption backupOption;
    [Export] Button ChooseProjPathButton;
    [Export] Button BackupAllButton;
    [Export] Button SaveSettingsButton;

    public override void _Ready()
    {
        Instance = this;
        fileDialog.DirSelected += SetProject;
        BackupAllButton.ButtonDown += BackupAll;
        PleaseWaitPopup = GetNode<Label>("WaitPopup");
        SaveSettingsButton.ButtonDown += SaveSettings;
        LoadSettings();
    }

    private void SaveSettings()
    {
        var config = new ConfigFile();
        config.SetValue("Main", "ProjectPath", ProjectPath);
        config.SetValue("BackupOne", "BackupPath", backupOption.backupPath);

        config.Save("user://Config.cfg");
    }
    private void LoadSettings()
    {
        var config = new ConfigFile();
        Error err = config.Load("user://Config.cfg");
        if (err != Error.Ok)
        {
            return;
        }

        string projpath = (String)config.GetValue("Main", "ProjectPath");
        SetProject(projpath);

        string backupPath = (String)config.GetValue("BackupOne", "BackupPath");
        backupOption.fileDialog_DirSelected(backupPath);

    }


    private void SetProject(string dir)
    {
        ProjectPath = dir;
        ProjectPathLabel.Text = "Project path: " + dir;
        GD.Print("Project path set");
    }

    private void BackupAll()
    {
        PleaseWaitPopup.Show();
        GD.Print("Backup All Pressed");
        PleaseWaitPopup.Hide();

    }

}
