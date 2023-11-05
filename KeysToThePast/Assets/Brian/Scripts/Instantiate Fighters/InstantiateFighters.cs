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
        GameObject player1 = Instantiate(SelectFighter.players[0].fighter, spawnLocations[0].position, Quaternion.Euler(0, 90, 0));
        PlayerInformation player1Info = player1.AddComponent<PlayerInformation>();
        player1Info.info = SelectFighter.players[0];

        GameObject player2 = Instantiate(SelectFighter.players[1].fighter, spawnLocations[1].position, Quaternion.Euler(0, 270, 0));
        PlayerInformation player2Info = player2.AddComponent<PlayerInformation>();
        player2Info.info = SelectFighter.players[1];
    }
}
