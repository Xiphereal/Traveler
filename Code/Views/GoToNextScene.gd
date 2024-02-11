extends Node

@export var next : PackedScene

func _go_to_next_scene():
	get_tree().change_scene_to_packed(next)
