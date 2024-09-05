extends Panel
class_name BackupProgram

static var backupProgram: BackupProgram
@export var BackupOptionScene:PackedScene

@onready var FileOpener:FileDialog = $FileDialog

var project_path:String
@onready var ProjPathLabel:Label = $VBoxContainer/FirstR
# Called when the node enters the scene tree for the first time.
func _ready():
	backupProgram = self

# Called every frame. 'delta' is the elapsed timeow/ProjectPathLabel

func _process(delta):
	pass


func _on_choose_folder_button_button_down():
	FileOpener.show()
	FileOpener.dir_selected.connect(_set_project_folder)

func _set_project_folder(path:String):
	FileOpener.dir_selected.disconnect(_set_project_folder)
	project_path = path
	ProjPathLabel.text = project_path
	
func _on_backup_all_button_button_down():
	pass
