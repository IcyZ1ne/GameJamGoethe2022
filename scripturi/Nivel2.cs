using Godot;
using System;

public class Nivel2 : Node2D
{
    int progres = 0;
    Timer timer;
    Timer timer2;
    Tween tween;
    Tween tween2;
    Tween tween3;
    Sprite Alarma;
    AudioStreamPlayer muzica;
    RandomNumberGenerator rng = new RandomNumberGenerator();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Alarma = (Sprite)GetNode("Arrow");
        tween = (Tween)GetNode("Tween");
        tween2 = (Tween)GetNode("Tween2");
        // tween3 = (Tween)GetNode("Tween3");
        timer = (Timer)GetNode("Timer");
        // timer2 = (Timer)GetNode("Timer2");
        timer.Start();
        // timer2.Start();
        
        muzica = (AudioStreamPlayer)GetNode("AudioStreamPlayer");
        muzica.Play();
    }

    public override void _Process(float delta)
    {
        // var chestiu = GetTree().GetNodesInGroup("chesti");
        // for (int i=0;i<chestiu.Count;i++) {
        //     Area2D c = (Area2D)chestiu[i];
        //     c.RotationDegrees += delta*10;
        // }
    }

    public void _on_Timer_timeout() {
        var tiles = GetTree().GetNodesInGroup("pamant");
        TileFall((StaticBody2D)tiles[rng.RandiRange(0,tiles.Count-1)]);
        timer.Start();
    }

    void TileFall(StaticBody2D Tile) {
        Tile.RemoveFromGroup("pamant");
        Alarma.GlobalPosition = new Vector2(Tile.GlobalPosition.x,Tile.GlobalPosition.y-250);
        // tween2.InterpolateProperty(Alarma,"modulate",new Color(1,1,1,0),new Color(1,1,1,1),.5f,Tween.TransitionType.Linear,Tween.EaseType.InOut);
        // tween2.Start();
        tween2.InterpolateProperty(Alarma,"modulate",new Color(1,1,1,1),new Color(1,1,1,0),2,Tween.TransitionType.Linear,Tween.EaseType.InOut);
        tween2.Start();
        tween.InterpolateProperty(Tile,"position",Tile.GlobalPosition,new Vector2(Tile.GlobalPosition.x,2000),2,Tween.TransitionType.Linear,Tween.EaseType.InOut,1.5f);
        tween.Start();
    }

    public void _on_Area2D6_body_entered(Area2D body) {
        body.QueueFree();
        progres++;
        if (progres == 2) {
            GetTree().ChangeScene("res://scene/Nivel3.tscn");
        }
    }

    // public void _on_Timer2_timeout() {
    //     var chesti = GetTree().GetNodesInGroup("chesti");
    //     ObjectFall((Area2D)chesti[rng.RandiRange(0,chesti.Count-1)],rng.RandiRange(64, 1856));
    //     timer2.Start();
    // }

    // void ObjectFall(Area2D chestie, int pos) {
    //     chestie.GlobalPosition = new Vector2(pos,chestie.GlobalPosition.y-300);
    //     chestie.Visible = true;
    //     tween3.InterpolateProperty(chestie,"position",chestie.GlobalPosition,new Vector2(chestie.GlobalPosition.x,chestie.GlobalPosition.y+1000),.8f);
    //     tween3.Start();
    // }
}
