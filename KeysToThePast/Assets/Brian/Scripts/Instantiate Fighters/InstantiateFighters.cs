using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InstantiateFighters : MonoBehaviour
{
    [SerializeField] Transform[] spawnLocations = new Transform[2];

    private void Start()
    {
        CreateFighters();
    }

    public void CreateFighters()
    {
        Instantiate(SelectFighter.players[0].fighter, spawnLocations[0].position, Quaternion.Euler(0, 90, 0));
        Instantiate(SelectFighter.players[1].fighter, spawnLocations[1].position, Quaternion.Euler(0, 270, 0));
    }
}
