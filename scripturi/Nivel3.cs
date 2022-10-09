using Godot;
using System;

public class Nivel3 : Node2D
{
    int obiecte = 0;
    Area2D area2D;
    Area2D area2D2;
    Area2D area2D3;
    Area2D area2D4;
    Label label;
    Label label2;
    Label label3;
    Label label4;
    Tween tween;
    ColorRect colorRect4;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        area2D = (Area2D)GetNode("Area2D");
        area2D2 = (Area2D)GetNode("Area2D2");
        area2D3 = (Area2D)GetNode("Area2D3");
        area2D4 = (Area2D)GetNode("Area2D4");
        label = (Label)GetNode("Label");
        label2 = (Label)GetNode("Label2");
        label3 = (Label)GetNode("Label3");
        label4 = (Label)GetNode("Label4");
        tween = (Tween)GetNode("Tween");
        colorRect4 = (ColorRect)GetNode("ColorRect4");
    }

    public void a(Area2D area) {
        if (area2D.IsInGroup("obiecte")) {
            area2D.RemoveFromGroup("obiecte");
            area2D.GetNode<Particles2D>("Particles2D").QueueFree();
            area2D.Modulate = new Color(.5f,.5f,.5f,1);
            obiecte++;
            tween.InterpolateProperty(label3,"modulate",new Color(1,1,1,0),new Color(1,1,1,1),0.5f);
            tween.InterpolateProperty(label3,"rect_position",label3.RectPosition, new Vector2(label3.RectPosition.x,label3.RectPosition.y-80),0.5f);
            tween.Start();
            if (obiecte == 4) {
                EndScene();
            }
        }
    }

    public void _on_Area2D2_body_entered(Area2D area) {
        if (area2D2.IsInGroup("obiecte")) {
            area2D2.RemoveFromGroup("obiecte");
            area2D2.GetNode<Particles2D>("Particles2D").QueueFree();
            area2D2.Modulate = new Color(.5f,.5f,.5f,1);
            obiecte++;
            tween.InterpolateProperty(label2,"modulate",new Color(1,1,1,0),new Color(1,1,1,1),0.5f);
            tween.InterpolateProperty(label2,"rect_position",label2.RectPosition, new Vector2(label2.RectPosition.x,label2.RectPosition.y-80),0.5f);
            tween.Start();
            if (obiecte == 4) {
                EndScene();
            }
        }
    }

    public async void _on_Area2D3_body_entered(Area2D area) {
        if (area2D3.IsInGroup("obiecte")) {
            area2D3.RemoveFromGroup("obiecte");
            area2D3.GetNode<Particles2D>("Particles2D").QueueFree();
            area2D3.Modulate = new Color(.5f,.5f,.5f,1);
            obiecte++;
            tween.InterpolateProperty(label,"modulate",new Color(1,1,1,0),new Color(1,1,1,1),0.5f);
            tween.InterpolateProperty(label,"rect_position",label.RectPosition, new Vector2(label.RectPosition.x,label.RectPosition.y-80),0.5f);
            tween.Start();
            if (obiecte == 4) {
                EndScene();
            }
        }
    }

    public void _on_Area2D4_body_entered(Area2D area) {
        if (area2D4.IsInGroup("obiecte")) {
            area2D4.GetNode<Particles2D>("Particles2D").QueueFree();
            area2D4.Modulate = new Color(.5f,.5f,.5f,1);
            area2D4.RemoveFromGroup("obiecte");
            obiecte++;
            tween.InterpolateProperty(label4,"modulate",new Color(1,1,1,0),new Color(1,1,1,1),0.5f);
            tween.InterpolateProperty(label4,"rect_position",label4.RectPosition, new Vector2(label4.RectPosition.x,label4.RectPosition.y-80),0.5f);
            tween.Start();
            if (obiecte == 4) {
                EndScene();
            }
        }
    }

    async void EndScene() {
        tween.InterpolateProperty(colorRect4,"color",new Color(0,0,0,0),new Color(0,0,0,1),1,Tween.TransitionType.Linear,Tween.EaseType.InOut,10);
        tween.Start();
        await ToSignal(tween,"tween_all_completed");
        GetTree().ChangeScene("res://scene/Nivel4.tscn");
    }
}
