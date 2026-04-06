extends Node

var shady: Shader = preload("res://mods/Toes.Shaderade/pixelize.gdshader")

func _ready() -> void:
	get_tree().connect("node_added", self, "_join_tree")

func _join_tree(node: Node) -> void:
	if not node.name == "world":
		return
	var world: ViewportContainer = node
	var mat:= ShaderMaterial.new()
	mat.shader = shady
	var res: Vector2 = (OS.window_size / Globals.pixelize_amount).ceil()
	mat.set_shader_param("resX", min(res[0], 512))
	mat.set_shader_param("resY", min(res[1], 512))
	mat.set_shader_param("rgb255", Vector3( 0.1, 0.1, 0.1 ))
	world.material = mat
