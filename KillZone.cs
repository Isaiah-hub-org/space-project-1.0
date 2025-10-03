using Godot;
using System;

public partial class KillZone : Area2D
	{
		Timer timer;
		
		public override void _Ready() {
			timer = GetNode<Timer>("Timer");
		}
		
		// Called when a body enters the Area2D
		public void OnBodyEntered(Node2D body)
		{
			// Check if the entering body is the player
			if (body.HasMethod("Die")) 
			{
				// Call the player's "Die" method
				body.Call("Die"); 
				GD.Print("Player entered killzone and died!");
			}
			else if (body is CharacterBody2D player) // Alternatively, check for the specific player type
			{
				player.QueueFree(); // Or call a specific death function on the player
				GD.Print("Player entered killzone and was removed!");
			}
			// You can add more logic here for other types of bodies if needed
		}
	}
