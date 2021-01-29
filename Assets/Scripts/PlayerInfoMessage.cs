using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


/// <summary>
/// The PlayerClass enum.
/// <para>Enum to define the type of the player.</para>
/// </summary>
public enum PlayerClass
{
    Cow,
    Farmer
}

/// <summary>
/// The PlayerInfoMessage class.
/// <para>This class defines the message a player sends to the server.</para>
/// </summary>
public struct PlayerInfoMessage : NetworkMessage
{
    public PlayerClass playerClass;
    public string description;
    public bool isHost;
}
