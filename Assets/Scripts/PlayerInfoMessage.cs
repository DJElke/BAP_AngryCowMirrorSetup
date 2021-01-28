using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public enum PlayerClass
{
    Cow,
    Farmer
}
public struct PlayerInfoMessage : NetworkMessage
{
    public PlayerClass playerClass;
    public string description;
    public bool isHost;
}
