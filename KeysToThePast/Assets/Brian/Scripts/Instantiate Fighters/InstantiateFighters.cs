using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class InstantiateFighters : MonoBehaviour
{
    [SerializeField] Transform[] spawnLocations = new Transform[2];
    [SerializeField] GameObject eightesGuy;

    [Header("Environments")]
    [SerializeField] GameObject caveman;
    [SerializeField] GameObject knight;
    [SerializeField] GameObject brain;
    GameObject timeTraveler;
    [SerializeField] GameObject leftCavemanEnvironement;
    [SerializeField] GameObject leftKnightEnvironment;
    [SerializeField] GameObject leftEightesGuyEnvironment;
    [SerializeField] GameObject leftBrainEnvironment;
    [SerializeField] GameObject leftTimeTravelerEnvironment;
    [SerializeField] GameObject rightCavemanEnvironement;
    [SerializeField] GameObject rightKnightEnvironment;
    [SerializeField] GameObject rightEightesGuyEnvironment;
    [SerializeField] GameObject rightBrainEnvironment;
    [SerializeField] GameObject rightTimeTravelerEnvironment;

    [Header("Health UI")]
    [SerializeField] Image[] portraits = new Image[2];
    [SerializeField] Sprite cavemanPortrait;
    [SerializeField] Sprite knightPortrait;
    [SerializeField] Sprite eightiesGuyPortrait;
    [SerializeField] Sprite brainPortrait;
    [SerializeField] Sprite timeTravelerPortrait;
    [SerializeField] Slider leftHealthBar;
    [SerializeField] Slider rightHealthBar;


    private void Start()
    {
        timeTraveler = GameManager.timeTraveler;
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
        if (SelectFighter.players[1].fighter == eightesGuy)
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

        CreateEnvironment(SelectFighter.players[0].fighter, new Vector3(-6, 5, 14.25f), true);
        CreateEnvironment(SelectFighter.players[1].fighter, new Vector3(-6, 5, 14.25f), false);

        player1.GetComponent<PlayerInput>().SwitchCurrentControlScheme(SelectFighter.players[0].input);
        player2.GetComponent<PlayerInput>().SwitchCurrentControlScheme(SelectFighter.players[1].input);

        AssignPortaits(SelectFighter.players[0].fighter, 0);
        AssignPortaits(SelectFighter.players[1].fighter, 1);

        AssignHealth(SelectFighter.players[0].fighter, 0);
        AssignHealth(SelectFighter.players[1].fighter, 1);
    }

    public void CreateEnvironment(GameObject fighter, Vector3 position, bool isLeft)
    {
        GameObject environement;

        if (isLeft)
        {
            if (fighter == caveman)
            {
                environement = leftCavemanEnvironement;
            }
            else if (fighter == knight)
            {
                environement = leftKnightEnvironment;
            }
            else if (fighter == eightesGuy)
            {
                environement = leftEightesGuyEnvironment;
            }
            else if (fighter = brain)
            {
                environement = leftBrainEnvironment;
            }
            else if (fighter == timeTraveler)
            {
                environement = leftTimeTravelerEnvironment;
            }
            else
            {
                environement = leftCavemanEnvironement;
            }
        }
        else
        {
            if (fighter == caveman)
            {
                environement = rightCavemanEnvironement;
            }
            else if (fighter == knight)
            {
                environement = rightKnightEnvironment;
            }
            else if (fighter == eightesGuy)
            {
                environement = rightEightesGuyEnvironment;
            }
            else if (fighter = brain)
            {
                environement = rightBrainEnvironment;
            }
            else if (fighter == timeTraveler)
            {
                environement = rightTimeTravelerEnvironment;
            }
            else
            {
                environement = rightCavemanEnvironement;
            }
        }

        Instantiate(environement, position, Quaternion.identity);
    }

    public void AssignPortaits(GameObject fighter, int index)
    {
        if (fighter == caveman)
        {
            portraits[index].sprite = cavemanPortrait;
        }
        else if (fighter == knight)
        {
            portraits[index].sprite = knightPortrait;
        }
        else if (fighter == eightesGuy)
        {
            portraits[index].sprite = eightiesGuyPortrait;
        }
        else if (fighter == brain)
        {
            portraits[index].sprite = brainPortrait;
        }
        else if (fighter == timeTraveler)
        {
            portraits[index].sprite = timeTravelerPortrait;
        }
        else
        {
            portraits[index].sprite = timeTravelerPortrait;
        }
    }

    public void AssignHealth(GameObject fighter, int index)
    {
        Health health = fighter.GetComponent<Health>();

        if (index == 0)
        {
            health.SetHealthBar(leftHealthBar);
        }
        else
        {
            health.SetHealthBar(rightHealthBar);
        }

        //health.ChangeHealthBar();

        //unfinished
    }
}
