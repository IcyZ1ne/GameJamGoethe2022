using Godot;
using System;

public class caracter : KinematicBody2D
{
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		Vector2 velocity = new Vector2();
		if (Input.IsActionPressed("ui_left")) {
			velocity.x -= 150;
		}
		if (Input.IsActionPressed("ui_right")) {
			velocity.x += 150;
		}
		if (Input.IsActionPressed("ui_up")) {
			velocity.y -= 150;
		}
		if (Input.IsActionPressed("ui_down")) {
			velocity.y += 150;
		}
		MoveAndSlide(velocity,Vector2.Up);
	}
}
