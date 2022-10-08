using Godot;
using System;

public class CameraScript : Godot.Camera2D
{
    [Export]
    private NodePath Caracter1Path;
    [Export]
    private NodePath Caracter2Path;
    private KinematicBody2D Caracter1;
    private KinematicBody2D Caracter2;
    private const float VitezaCamera = 7.0f;
    private const float ZoomMinim = .6f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Caracter1 = GetNode<KinematicBody2D>(Caracter1Path);
        Caracter2 = GetNode<KinematicBody2D>(Caracter2Path);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        this.GlobalPosition = (Caracter1.GlobalPosition + Caracter2.GlobalPosition) * 0.5f;

        float zoom_factor1 = Math.Abs(Caracter1.GlobalPosition.x - Caracter2.GlobalPosition.x)/(1920-150);
        float zoom_factor2 = Math.Abs(Caracter1.GlobalPosition.y - Caracter2.GlobalPosition.y)/(1080-150);
        float zoom_factor = Math.Max(Math.Max(zoom_factor1,zoom_factor2),ZoomMinim);

        this.Zoom = this.Zoom.LinearInterpolate(new Vector2(zoom_factor,zoom_factor),delta*VitezaCamera); //new Vector2(zoom_factor,zoom_factor);
    }
}
