using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class InstantiateFighters : MonoBehaviour
{
    [SerializeField] Transform[] spawnLocations = new Transform[2];
    [SerializeField] GameObject eightesGuy;

    private void Start()
    {
        CreateFighters();
    }

    public void CreateFighters()
    {
        GameObject player1;
        if (SelectFighter.players[0].fighter == eightesGuy)
        {
            player1 = Instantiate(SelectFighter.players[0].fighter, spawnLocations[0].position, Quaternion.identity);
        }
        else
        {
            player1 = Instantiate(SelectFighter.players[0].fighter, spawnLocations[0].position, Quaternion.Euler(0, 90, 0));
        }
        PlayerInformation player1Info = player1.AddComponent<PlayerInformation>();
        player1Info.info = SelectFighter.players[0];

        GameObject player2;
        if (SelectFighter.players[0].fighter == eightesGuy)
        {
            player2 = Instantiate(SelectFighter.players[1].fighter, spawnLocations[1].position, Quaternion.Euler(0, 180, 0));
        }
        else
        {
            player2 = Instantiate(SelectFighter.players[1].fighter, spawnLocations[1].position, Quaternion.Euler(0, 270, 0));
        }
        PlayerInformation player2Info = player2.AddComponent<PlayerInformation>();
        player2Info.info = SelectFighter.players[1];

        CameraFollowPlayers.addPlayerToCamera(player1.transform);
        CameraFollowPlayers.addPlayerToCamera(player2.transform);
    }
}
