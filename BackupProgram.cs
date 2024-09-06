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
    [Export] Button ChooseProjPathButton;
    [Export] Button BackupAllButton;

    public override void _Ready()
    {
        Instance = this;
        fileDialog.DirSelected += SetProject;
        BackupAllButton.ButtonDown += BackupAll;
        PleaseWaitPopup = GetNode<Label>("WaitPopup");
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
