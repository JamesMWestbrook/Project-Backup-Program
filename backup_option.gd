extends HBoxContainer
var backup_path:String

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass


func _on_file_dialog_dir_selected(dir: String) -> void:
	$BackupPath.text = dir
	backup_path = dir
