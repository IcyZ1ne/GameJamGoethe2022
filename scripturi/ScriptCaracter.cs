using Godot;
using System;

public class ScriptCaracter : KinematicBody2D
{
	[Export]
	private string animatie_idle;
	[Export]
	private string animatie_mers;
	Node2D node2D;
	AnimationPlayer animationPlayer;
	Particles2D particles2D;
	Vector2 StartScale = new Vector2(1,1);
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
		particles2D = (Particles2D)GetNode("Node2D/Particles2D");
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
		bool IsJumping = Input.IsActionJustPressed("ui_up") && (Jumps) != 1;
		bool IsJumpCancelled = Input.IsActionJustReleased("ui_up") && Velocity.y < 0f;
		bool IsIdling = IsOnFloor() && Mathf.IsZeroApprox(Velocity.x);
		bool IsRunning = IsOnFloor() && !(Mathf.IsZeroApprox(Velocity.x));

		if (IsJumping == true) {
			Jumps += 1;
			Velocity.y = -JumpStrength;
		} else if (IsJumpCancelled == true) {
			Velocity.y = 0;
		}

		Velocity = MoveAndSlide(Velocity,UpDirection,false,4,Mathf.Pi/4f,false);

		// int sc = GetSlideCount();
		// if (sc > 0) {
		// 	for (int i = 0; i < sc; i++) {
		// 		Node body = GetSlideCollision(i);
		// 		// if (body.Name == "Carucior") {

		// 		// }
		// 	}
		// }

		if (!(Mathf.IsZeroApprox(Velocity.x))) {
			node2D.Scale = node2D.Scale.LinearInterpolate(new Vector2(Mathf.Sign(Velocity.x) * StartScale.x,1),.18f);
		} else if (Mathf.IsZeroApprox(Velocity.x) && node2D.Scale.x != 1) {
			node2D.Scale = new Vector2(1*LastDir,1);
		}

		if (IsRunning) {
			particles2D.Emitting = true;
			Jumps = 0;
			animationPlayer.Play(animatie_mers);
		} else if (IsIdling) {
			particles2D.Emitting = false;
			Jumps = 0;
			animationPlayer.Play(animatie_idle);
		}
	}
}
