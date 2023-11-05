using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player
{
    public int playerId;
    public InputAction input;
    public GameObject fighter;

    public Player(int playerId, InputAction input, GameObject fighter)
    {
        this.playerId = playerId;
        this.input = input;
        this.fighter = fighter;
    }
}
