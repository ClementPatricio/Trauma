using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem.Editor;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{

    InputActions inputActions;
    GamepadVibrate gpVibrate;

    [SerializeField]
    GameObject playerEyes;

    [Space]

    [Range(0.0f, 10.0f)]
    [SerializeField]
    [Tooltip("La vitesse du personnage")]
    float speed = 2.0f;

    Vector2 mouvement;
    Vector2 lookMove;

    private bool interacting;
    private float interactTime;
    [SerializeField]
    [Range(1.0f,5.0f)]
    private float holdingTime;
    private bool canInteract;
    private bool willInteract;

    void Awake()
    {
        gpVibrate = GetComponent<GamepadVibrate>();
        inputActions = new InputActions();
        interacting = false;
        interactTime = 0.0f;
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

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            interacting = true;
        }
        if (context.performed)
        {
            willInteract = true;
        }
        //if (context.)
        {
            
        }
        Debug.Log("c");
    }

    public void OnInteract()
    {
        //Debug.Log("c");
    }

    void Update()
    {
        this.transform.Translate(new Vector3(mouvement.x, 0, mouvement.y)*speed*Time.deltaTime, Space.Self);
        this.transform.Rotate(new Vector3(0, lookMove.x));
        playerEyes.transform.Rotate(new Vector3(-lookMove.y,0));
        if (interacting)
        {
            interactTime += Time.deltaTime;
            if(interactTime > holdingTime)
            {
                willInteract = true;
                interacting = false;
            }
        }
    }
}


public class MyHoldInteraction : IInputInteraction
{
    public float duration = 2.0f;

    public void Process(ref InputInteractionContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Waiting:
                if (context.ReadValue<float>() == 1)
                {
                    context.Started();
                }
                break;

            case InputActionPhase.Started:
                if (context.ReadValue<float>() == 0)
                    if(context.time > duration)
                    {
                        context.Performed();
                    }
                    else
                    {
                        context.Canceled();
                    }
                break;
        }
    }

    // Unlike processors, Interactions can be stateful, meaning that you can keep
    // local state that mutates over time as input is received. The system might
    // ask Interactions to reset such state at certain points by invoking the `Reset()`
    // method.
    public void Reset()
    {
    }
}