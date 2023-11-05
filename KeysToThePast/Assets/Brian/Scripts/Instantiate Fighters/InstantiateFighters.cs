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
        for (int i = 0; i < SelectFighter.players.Length; i++)
        {
            Instantiate(SelectFighter.players[i].fighter, spawnLocations[i].position, Quaternion.identity);
        }
    }
}
