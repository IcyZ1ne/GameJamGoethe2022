using Godot;
using System;

public class ScriptCaracter2 : KinematicBody2D
{
	private Vector2 direction;
	[Export]
	private float MoveSpeed=500;
	[Export]
	private float Gravity=90;
	[Export]
	private float MaxFalSpeed=1000;
	[Export]
	private float MinFallSpeed=5;
	[Export]
	private float JumpForce=0;
	Sprite Sprite;
	AnimationPlayer animationPlayer;

	
	public override void _Ready()
	{
		Sprite = (Sprite)GetNode("Sprite");
		animationPlayer = (AnimationPlayer)GetNode("AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		//gravitatia jucatorului
		direction.y += Gravity;
		if (direction.y > MaxFalSpeed) {
			direction.y = MaxFalSpeed;
		}
		if (IsOnFloor()) {
			direction.y = MinFallSpeed;
		}

		//controlale caracterului
		direction.x = Input.GetActionStrength("dreapta") - Input.GetActionStrength("stanga");
		direction.x *= MoveSpeed;

		//saritura caracter
		if (IsOnFloor() && Input.IsActionJustPressed("sus")) {
			direction.y -= JumpForce;
		}

		//rotind caracterul
		if(direction.x>0) {
			Sprite.FlipH = false;
		} else if (direction.x<0) {
			Sprite.FlipH = true;
		}

		direction = MoveAndSlide(direction,Vector2.Up);
	}
}
