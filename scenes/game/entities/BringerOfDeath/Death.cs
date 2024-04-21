using Godot;
using System;

public partial class Death : state
{
    public async override void Enter()
    {
        base.Enter();
        AnimationPlayer.Play("disappear");
        await ToSignal(AnimationPlayer, AnimationPlayer.SignalName.AnimationFinished);
        Owner.QueueFree();
    }
}