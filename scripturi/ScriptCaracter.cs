using Godot;
using System;

public class ScriptCaracter : KinematicBody2D
{
	Node2D node2D;
	Vector2 StartScale = new Vector2(1,1);
	AnimationPlayer animationPlayer;
	private Vector2 UpDirection = Vector2.Up;
	private Vector2 Velocity = Vector2.Zero;
	private int LastDir = 1;
	private float Speed = 400f;
	private float JumpStrength = 800f;
	private float Gravity = 4000f;
	private int Jumps = 0;

	public override void _Ready()
	{
		node2D = (Node2D)GetNode("Node2D");
		animationPlayer = (AnimationPlayer)GetNode("AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		float HorizontalDirection = (
			Input.GetActionStrength("ui_right")
			- Input.GetActionStrength("ui_left")
		);

		if (HorizontalDirection > 0 || HorizontalDirection < 0) {
			LastDir = (int)HorizontalDirection;
		}

		Velocity.x = HorizontalDirection * Speed;
		Velocity.y += Gravity * delta;

		bool IsFalling = Velocity.y > 0f && !(IsOnFloor());
		bool IsJumping = Input.IsActionJustPressed("ui_accept") && (Jumps) != 1;
		bool IsJumpCancelled = Input.IsActionJustReleased("ui_accept") && Velocity.y < 0f;
		bool IsIdling = IsOnFloor() && Mathf.IsZeroApprox(Velocity.x);
		bool IsRunning = IsOnFloor() && !(Mathf.IsZeroApprox(Velocity.x));

		if (IsJumping == true) {
			Jumps += 1;
			Velocity.y = -JumpStrength;
		} else if (IsJumpCancelled == true) {
			Velocity.y = 0;
		}

		Velocity = MoveAndSlide(Velocity,UpDirection);

		if (!(Mathf.IsZeroApprox(Velocity.x))) {
			node2D.Scale = node2D.Scale.LinearInterpolate(new Vector2(Mathf.Sign(Velocity.x) * StartScale.x,1),.18f);
		} else if (Mathf.IsZeroApprox(Velocity.x) && node2D.Scale.x != 1) {
			node2D.Scale = new Vector2(1*LastDir,1);
		}

		if (IsRunning) {
			Jumps = 0;
			animationPlayer.Play("animatie_mers_1");
		} else if (IsIdling) {
			Jumps = 0;
			animationPlayer.Play("animatie_idle_1");
		}
	}
}
