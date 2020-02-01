using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    InputActions inputActions;
    GamepadVibrate gpVibrate;

    void Awake()
    {
        
        gpVibrate = GetComponent<GamepadVibrate>();
        inputActions = new InputActions();
    }

    public void VibrateRight()
    {
        gpVibrate.Vibrate(1.0f, 0.0f, 1.0f);
        Invoke(nameof(VibrateLeft), 2.0f);
    }
    public void VibrateLeft()
    {
        gpVibrate.Vibrate(0.0f, 1.0f, 1.0f);
        Invoke(nameof(VibrateRight), 2.0f);
    }

}
