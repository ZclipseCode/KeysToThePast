using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class testInputManager : MonoBehaviour
{
    //public PlayerInputManager inputManager;

    public void OnPlayerJoined(PlayerInput playerInput)
    {

        //Debug.Log(playerInput.playerIndex);

        // Set the player ID, add one to the index to start at Player 1
        playerInput.gameObject.GetComponent<PlayerDetails>().playerNumber = playerInput.playerIndex + 1;
    }
}
