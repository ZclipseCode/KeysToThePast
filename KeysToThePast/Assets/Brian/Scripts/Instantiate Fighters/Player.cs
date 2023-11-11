using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player
{
    public int playerId;
    public InputDevice input;
    public GameObject fighter;

    public Player(int playerId, InputDevice input, GameObject fighter)
    {
        this.playerId = playerId;
        this.input = input;
        this.fighter = fighter;
    }
}
