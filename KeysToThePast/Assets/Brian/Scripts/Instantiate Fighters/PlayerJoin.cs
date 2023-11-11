using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoin : MonoBehaviour
{
    private void Start()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();

        // Access the first input action
        InputAction[] inputActions = playerInput.actions.ToArray();
        InputAction inputAction = inputActions.Length > 0 ? inputActions[0] : null;

        // Pass the input action to the SelectFighter.playerJoin method
        if (inputAction != null)
        {
            SelectFighter.playerJoin?.Invoke(playerInput.devices[0]);

            // prints out input device
            Debug.Log(playerInput.devices[0]);
        }
    }
}
