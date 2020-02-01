using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    InputActions inputActions;
    GamepadVibrate gpVibrate;
    [Range(0.0f, 10.0f)][SerializeField]
    float speed = 2.0f;

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

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 delta = context.ReadValue<Vector2>();
        this.transform.Translate(new Vector3(delta.x/10, 0, delta.y/10), Space.Self);
    }
}
