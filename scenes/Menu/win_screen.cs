using Godot;
using System;

public partial class win_screen : Control
{
	
	public static Button button;
	public static Button button_s;
    public AudioStreamPlayer click;
    public AudioStreamPlayer mute;
    public level1_music stop1;
    public level2_music stop2;
    public level3_music stop3;
    public AudioStreamPlayer Music;

    public override void _Ready()
	{
        click = GetNode<AudioStreamPlayer>("Buttons");
        mute = GetNode<AudioStreamPlayer>("AudioButtons");
        stop1 = GetNode<level1_music>("/root/Level1PlatformerMusic");
        stop2 = GetNode<level2_music>("/root/Level2PlatformerMusic");
        stop3 = GetNode<level3_music>("/root/Level3PlatformerMusic");
        stop1.musicp.Stop();
        stop1.musicb.Stop();
        stop2.musicp.Stop();
        stop2.musicb.Stop();
        stop2.musicboss.Stop();
        stop3.musicp.Stop();
        stop3.musicb.Stop();
        stop3.musicboss.Stop();
        Music = GetNode<AudioStreamPlayer>("Music");
        if (settings.Audio)
        {
            Music.Play();
        }

    }
	
	public async void _on_exit_pressed()
	{
        if (settings.Sound)
        {
            click.Play();
            await ToSignal(click, AudioStreamPlayer.SignalName.Finished);
        }
        GetTree().ChangeSceneToFile("res://scenes/Menu/menu.tscn");
	}

	public async void _on_new_game_pressed()
	{
        if (settings.Sound)
        {
            click.Play();
            await ToSignal(click, AudioStreamPlayer.SignalName.Finished);
        }
        GetTree().ChangeSceneToFile("res://scenes/game/Level/Level1/level1.tscn");
	}

	
	
}