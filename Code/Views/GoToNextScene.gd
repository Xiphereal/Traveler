extends Node

@export var pathToNextScene : String

func _go_to_next_scene():
	get_tree().change_scene_to_file(pathToNextScene)
