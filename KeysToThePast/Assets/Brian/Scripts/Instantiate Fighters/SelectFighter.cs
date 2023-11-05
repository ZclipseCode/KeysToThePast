using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectFighter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI prompt;
    InputAction[] inputs = new InputAction[2];
    GameObject[] fighters = new GameObject[2];
    int currentPlayerIndex;
    PlayerInputManager inputManager;

    private void Start()
    {
        ReadyForInput();
    }

    public void AddInput(InputAction input)
    {
        inputs[currentPlayerIndex] = input;
    }

    public void AddFighter(GameObject fighter)
    {
        fighters[currentPlayerIndex] = fighter;

        currentPlayerIndex++;
    }

    public void ReadyForInput()
    {
        prompt.text = $"Player {currentPlayerIndex + 1}: press any button!";
    }

    public void ReadyForFighter()
    {
        prompt.text = $"Player {currentPlayerIndex + 1}: choose your fighter!";
    }
}
