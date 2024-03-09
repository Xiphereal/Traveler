extends Node

func _go_to_next_scene():
	call_deferred("change_scene")
	
func change_scene():
	get_tree().change_scene_to_file("res://Scenes/" + $"/root/Roadmap".NextStop() + ".tscn")
