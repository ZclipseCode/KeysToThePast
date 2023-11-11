using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelectFighter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI prompt;
    [SerializeField] string fightScene;
    public static Player[] players;
    int currentPlayerIndex;
    InputDevice tempInput;
    GameObject tempFighter;
    public delegate void PlayerJoinDelegate(InputDevice action);
    public static PlayerJoinDelegate playerJoin;

    PlayerInputManager playerInputManager;

    private void Awake()
    {
        playerJoin += AddInput;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();

        players = new Player[2];
        ReadyForInput();
    }

    public void AddInput(InputDevice input)
    {
        tempInput = input;

        ReadyForFighter();
    }

    public void AddFighter(GameObject fighter)
    {
        if (tempInput != null)
        {
            tempFighter = fighter;

            players[currentPlayerIndex] = new Player(currentPlayerIndex + 1, tempInput, tempFighter);

            currentPlayerIndex++;

            if (currentPlayerIndex < players.Length)
            {
                ReadyForInput();
                tempInput = null;
            }
            else
            {
                SceneManager.LoadScene(fightScene);
            }
        }
    }

    public void AddCustomFighter()
    {
        if (tempInput != null)
        {
            tempFighter = GameManager.timeTraveler;

            players[currentPlayerIndex] = new Player(currentPlayerIndex + 1, tempInput, tempFighter);

            currentPlayerIndex++;

            if (currentPlayerIndex < players.Length)
            {
                ReadyForInput();
                tempInput = null;
            }
            else
            {
                SceneManager.LoadScene(fightScene);
            }
        }
    }

    public void ReadyForInput()
    {
        prompt.text = $"Player {currentPlayerIndex + 1}: Press Any Button!";

        playerInputManager.EnableJoining();
    }

    public void ReadyForFighter()
    {
        prompt.text = $"Player {currentPlayerIndex + 1}: Choose Your Fighter!";

        playerInputManager.DisableJoining();
    }

    private void OnDestroy()
    {
        playerJoin -= AddInput;
    }
}
