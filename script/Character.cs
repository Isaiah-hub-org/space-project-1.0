using Godot;
using System;



public interface ICharacter
{
	void _PhysicsProcess(global::System.Double delta);
	void _Ready();
}


public partial class Character : CharacterBody2D, ICharacter
{
    private int speed = 500;
    private int jump_height = 100;

    public override void _Ready() { }


    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionPressed("right"))
        {
            Position += new Vector2(speed * (float)delta, 0);
        }
        if (Input.IsActionPressed("left"))
        {
            Position -= new Vector2(speed * (float)delta, 0);
        }
        if (Input.IsActionPressed("jump"))
        {
            Velocity += new Vector2(0, jump_height);
        }
        if (!this.IsOnFloor())
        {
            Velocity -= GetGravity();
        }
    }
}