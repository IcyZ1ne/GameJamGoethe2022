using Godot;
using System;

public class MeniuPrincipal : Node2D
{
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void _on_Button_pressed() {
        GetTree().ChangeScene("res://scene/Nivel1.tscn");
    } 
}
