using Godot;
using System;
using System.Collections.Generic;

public partial class BossRoomWaves : Node2D
{
	private PackedScene SpawnExplosionScene = GD.Load<PackedScene>("res://scenes/game/LevelItems/RoomItems/SpawnExplosion/SpawnExplosion.tscn");

	private PackedScene ExitPlatformScene = GD.Load<PackedScene>("res://scenes/game/LevelItems/RoomItems/ExitPlatform/ExitPlatform.tscn");

	public Godot.Collections.Array<PackedScene> Enemies = new Godot.Collections.Array<PackedScene>{
		GD.Load<PackedScene>("res://scenes/game/entities/Scav/Scav.tscn"),
		GD.Load<PackedScene>("res://scenes/game/entities/Scav/Scav.tscn"),
		GD.Load<PackedScene>("res://scenes/game/entities/Barbarian/Barbarian.tscn"),
		GD.Load<PackedScene>("res://scenes/game/entities/Hunter/HunterLv1.tscn")
	};	private Node2D EnemyPositionsContainer;
	private Area2D PlayerDetector;
	private Marker2D ExitPlatformPosition;
	private Marker2D PlayerSpawn;
	private Area2D DamageBox;
	public int WavesCount = 3;

	public int num_enemies;
	public override void _Ready()
	{
		EnemyPositionsContainer = GetNode<Node2D>("EnemyPositions");
		PlayerDetector = GetNode<Area2D>("PlayerDetector");
		DamageBox = GetNode<Area2D>("DamageBox");
		PlayerSpawn = GetNode<Marker2D>("PlayerSpawn");
		ExitPlatformPosition = GetNode<Marker2D>("ExitPlatformPosition");
		num_enemies = EnemyPositionsContainer.GetChildCount();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private async void SpawnEnemies(){
		foreach(Marker2D EnemyPosition in EnemyPositionsContainer.GetChildren()){
			Random rnd = new Random();
			Node2D enemy = Enemies[rnd.Next(Enemies.Count)].Instantiate<Node2D>();
			enemy.Connect("tree_exited", Callable.From(_on_enemy_killed));
			enemy.Position = EnemyPosition.Position;
			this.AddChild(enemy);

			Node2D SpawnExplosion = SpawnExplosionScene.Instantiate<Node2D>();
			SpawnExplosion.Position = EnemyPosition.Position;
			
			this.AddChild(SpawnExplosion);
			await ToSignal(GetTree().CreateTimer(0.2), SceneTreeTimer.SignalName.Timeout);
			
		}
	}

	public void _on_enemy_killed(){
		num_enemies -= 1;
		if (num_enemies == 0 && WavesCount > 0){
			WavesCount -= 1;
			num_enemies = EnemyPositionsContainer.GetChildCount();
			SpawnEnemies();
		}else if (WavesCount == 0){
			ExitPlatform exitPlatform = ExitPlatformScene.Instantiate<ExitPlatform>();
			exitPlatform.Position = ExitPlatformPosition.Position;
			this.AddChild(exitPlatform);
		}
	}

	public async void _on_player_detector_body_entered(Node2D body){
		if (body.Name == "Player"){
			PlayerDetector.QueueFree();
			await ToSignal(GetTree().CreateTimer(0.5), SceneTreeTimer.SignalName.Timeout);
			this.CallDeferred("SpawnEnemies");

			if (num_enemies == 0){
				ExitPlatform exitPlatform = ExitPlatformScene.Instantiate<ExitPlatform>();
				exitPlatform.Position = ExitPlatformPosition.Position;
				this.AddChild(exitPlatform);
			}

			DamageBox.SetCollisionMaskValue(2, true);
		}
	}

	public void _on_damage_box_body_entered(Node2D body){
		if (body.Name == "Player"){
			body.GlobalPosition = PlayerSpawn.GlobalPosition;
			body.CallDeferred("GetDamaged", 20);
		}
	}
}
