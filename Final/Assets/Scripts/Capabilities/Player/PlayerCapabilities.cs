using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCapabilities : ICapabilities
{

    protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private Movement movement;
    private Core core;

    protected Player player;

    protected string _animBoolName;

    public PlayerCapabilities(Player player, string animBoolName)
    {
        this.player = player;
        core = player.Core;
        _animBoolName = animBoolName;
    }

    public virtual void CapabilityAction() { }
}
