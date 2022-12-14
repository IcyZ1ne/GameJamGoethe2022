using Godot;
using System;

public class ScriptCaracter2 : KinematicBody2D
{
	Node2D node2D;
	Vector2 StartScale = new Vector2(1,1);
	AnimationPlayer animationPlayer;
	Timer DashTimer;
	Tween DashTween;
	private Vector2 UpDirection = Vector2.Up;
	private Vector2 Velocity = Vector2.Zero;
	private int LastDir = 1;
	private float Speed = 300f;
	private float Gravity = 4500f;
	private bool CanDash = true;
	public override void _Ready()
	{
		DashTimer = (Timer)GetNode("Timer");
		DashTween = (Tween)GetNode("Tween");
		node2D = (Node2D)GetNode("Node2D");
		animationPlayer = (AnimationPlayer)GetNode("AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override async void _Process(float delta)
	{
		float HorizontalDirection = (
			Input.GetActionStrength("dreapta")
			- Input.GetActionStrength("stanga")
		);

		if (HorizontalDirection != 0) {
			LastDir = (int)HorizontalDirection;
		}

		Velocity.x = HorizontalDirection * Speed;
		Velocity.y += Gravity * delta;

		bool IsFalling = Velocity.y > 0f && !(IsOnFloor());
		bool IsIdling = IsOnFloor() && Mathf.IsZeroApprox(Velocity.x);
		bool IsRunning = IsOnFloor() && !(Mathf.IsZeroApprox(Velocity.x));
		bool IsDashing = Input.IsActionJustPressed("interact");
		if (IsDashing == true && CanDash == true) {
			CanDash = false;
			DashTimer.Start();
			Velocity = new Vector2(LastDir,0).Normalized() * 5000;
		}

		Velocity = MoveAndSlide(Velocity,UpDirection);

		if (!(Mathf.IsZeroApprox(Velocity.x))) {
			node2D.Scale = node2D.Scale.LinearInterpolate(new Vector2(Mathf.Sign(Velocity.x) * StartScale.x,1),.18f);
		} else if (Mathf.IsZeroApprox(Velocity.x) && node2D.Scale.x != 1) {
			node2D.Scale = new Vector2(1*LastDir,1);
		}

		if (IsRunning) {
			animationPlayer.Play("animatie_mers_2");
		} else if (IsIdling) {
			animationPlayer.Play("animatie_idle_2");
		}
	}

	public void _on_Timer_timeout() {
		CanDash = true;
	}
}
