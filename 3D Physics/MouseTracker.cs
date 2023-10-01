using Godot;

namespace Learning; 

public partial class MouseTracker : Node3D {

	[Export] public Camera3D Camera;
	
	private Viewport _viewport;
	private Node3D _selected;

	public override void _Ready() {
		base._Ready();
		_viewport = GetViewport();
	}

	public override void _Input(InputEvent @event) {
		base._Input(@event);
		if (@event is InputEventMouseButton { ButtonIndex: MouseButton.Left, Pressed: true } eventMouseButton) {
			var mousePosition = eventMouseButton.Position;
			var from = Camera.ProjectRayOrigin(mousePosition);
			GD.Print(mousePosition);
			var query = PhysicsRayQueryParameters3D.Create(from, from.Normalized() * 100);
			var result = GetWorld3D().DirectSpaceState.IntersectRay(query);
			if (result.Count == 0) return;
			GD.Print($"{result}");
		} else if (@event is InputEventMouseMotion eventMouseMotion) {
		}
	}
}