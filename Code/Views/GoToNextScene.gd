extends Button


@export var next : PackedScene


func _on_pressed():
	get_tree().change_scene_to_packed(next)