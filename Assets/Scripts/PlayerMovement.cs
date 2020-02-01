using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    InputActions inputActions;
    GamepadVibrate gpVibrate;
    [SerializeField]
    GameObject camera;
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField]
    [Tooltip("La vitesse du personnage")]
    float speed = 2.0f;

    Vector2 mouvement;
    Vector2 lookMove;

    void Awake()
    {
        gpVibrate = GetComponent<GamepadVibrate>();
        inputActions = new InputActions();
    }

    public void VibrateRight(float intensity, float timeout)
    {
        gpVibrate.Vibrate(intensity, 0.0f, timeout);
    }
    public void VibrateLeft(float intensity, float timeout)
    {
        gpVibrate.Vibrate(0.0f, intensity, timeout);
    }

    public void Vibrate(float leftIntensity, float rightIntensity, float timeout)
    {
        gpVibrate.Vibrate(leftIntensity, rightIntensity, timeout);
    }

    public void Move(InputAction.CallbackContext context)
    {
        mouvement = context.ReadValue<Vector2>();
    }

    public void LookAround(InputAction.CallbackContext context)
    {
        lookMove = context.ReadValue<Vector2>();
    }


    void Update()
    {
        this.transform.Translate(new Vector3(mouvement.x, 0, mouvement.y)*speed*Time.deltaTime, Space.Self);
        this.transform.Rotate(new Vector3(0, lookMove.x));
        camera.transform.Rotate(new Vector3(-lookMove.y,0));
    }
}
