using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.Users;

public class MenuTraversal : VirtualMouseInput{
    private Mouse mouse;
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private Canvas canvas;
    [SerializeField] 
    private RectTransform canvasTransform;
    [SerializeField]
    private RectTransform cursorTransform;
    [SerializeField]
    private float cursorSpeed = 10f;
    private bool prevMouseState;
    private Camera mainCam;

    private void OnEnable() {
        mainCam = Camera.main;
        if(mouse == null) {
            mouse = (Mouse)InputSystem.AddDevice("VirtualMouse");
        }
        else if (!mouse.added) {
            InputSystem.AddDevice(mouse);
        }

        InputUser.PerformPairingWithDevice(mouse, playerInput.user);

        if(cursorTransform != null) {
            Vector2 position = cursorTransform.anchoredPosition;
        }

        InputSystem.onAfterUpdate += UpdateMotion;
    }

    private void OnDisable() {
        InputSystem.onAfterUpdate -= UpdateMotion;
    }

    private void UpdateMotion() {
        if (virtualMouse == null || Gamepad.current == null) {
            return;
        }

        Vector2 deltaValue = Gamepad.current.leftStick.ReadValue();
        deltaValue *= cursorSpeed * Time.deltaTime;

        Vector2 currPos = virtualMouse.position.ReadValue();
        Vector2 newPos = currPos + deltaValue;

        newPos.x = Mathf.Clamp(newPos.x, 0f, Screen.width);
        newPos.y = Mathf.Clamp(newPos.y, 0f, Screen.height);

        InputState.Change(virtualMouse.position, newPos);
        InputState.Change(virtualMouse.delta, deltaValue);

        bool aButtonIsPressed = Gamepad.current.aButton.isPressed;
        if (prevMouseState != aButtonIsPressed) {
            virtualMouse.CopyState<MouseState>(out var mouseState);
            mouseState.WithButton(MouseButton.Left, aButtonIsPressed);
            InputState.Change(virtualMouse,mouseState);
            prevMouseState = aButtonIsPressed;
        }

        AnchorCursor(newPos);
    }

    private void AnchorCursor(Vector2 pos) {
        Vector2 anchoredPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTransform, pos, canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : mainCam, out anchoredPos);
        cursorTransform.anchoredPosition = anchoredPos;
    }
}
