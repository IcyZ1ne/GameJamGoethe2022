using Godot;
using System;

public class caracter2 : KinematicBody2D
{
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		Vector2 velocity = new Vector2();
		if (Input.IsActionPressed("stanga")) {
			velocity.x -= 150;
		}
		if (Input.IsActionPressed("dreapta")) {
			velocity.x += 150;
		}
		if (Input.IsActionPressed("sus")) {
			velocity.y -= 150;
		}
		if (Input.IsActionPressed("jos")) {
			velocity.y += 150;
		}
		MoveAndSlide(velocity,Vector2.Up);
	}
}
