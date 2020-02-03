using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.Interactions;
//using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    Image filledInteraction;
    [SerializeField]
    Image interactionButton;


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


    private GameObject focus;
    private bool interacting;
    private float interactTime;
    [SerializeField]
    [Range(1.0f,5.0f)]
    private float holdingTime;
    private bool canInteract;
    private bool willInteract;

    void Awake()
    {
        filledInteraction.fillClockwise = true;
        filledInteraction.fillAmount = 0.0f;
        interactionButton.fillAmount = 0.0f;
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
        if (!canInteract)
       {
            interacting = false;
            interactTime = 0.0f;
            filledInteraction.fillAmount = 0.0f;
            interactionButton.fillAmount = 0.0f;
            return;
       }
        if (context.started && !interacting && context.ReadValue<float>() == 1.0f)
        {
            interacting = true;
            interactionButton.fillAmount = 1.0f;

        }
        else
        {
            
            if (context.started && interacting && interactTime > holdingTime)
            {
                OnInteract();
                interacting = false;
                interactTime = 0.0f;
                filledInteraction.fillAmount = 0.0f;
                //interactionButton.fillAmount = 0.0f;

            }
            else
            {
                if (context.started && interacting && interactTime < holdingTime)
                {
                    interacting = false;
                    interactTime = 0.0f;
                    filledInteraction.fillAmount = 0.0f;
                    //interactionButton.fillAmount = 0.0f;

                }
            }
        }
    }

    public void OnInteract()
    {
        filledInteraction.fillAmount = 0.0f;
        interactionButton.fillAmount = 0.0f;
        GameManager.getInstance().setState(GameState.souvenir);
        Debug.Log("c");

    }

    void OnTriggerEnter(Collider other)
    {
        focus = other.gameObject;
        interacting = false;
        interactTime = 0.0f;
        filledInteraction.fillAmount = 0.0f;
        HapticSonar sonar = GameManager.getInstance().getHaptic();
        if (sonar.getTarget() == focus)
        {
            interactionButton.fillAmount = 1.0f;
            this.canInteract = true;
        }
        else
        {
            this.canInteract = false;
        }
        Debug.Log("c");

    }

    void OnTriggerExit(Collider other)
    {
        focus = null;
        interacting = false;
        interactTime = 0.0f;
        filledInteraction.fillAmount = 0.0f;
        interactionButton.fillAmount = 0.0f;
        this.canInteract = false;
    }

    void Update()
    {
        if(GameManager.getInstance().getState() == GameState.play)
        {
            this.transform.Translate(new Vector3(mouvement.x, 0, mouvement.y) * speed * Time.deltaTime, Space.Self);
            this.transform.Rotate(new Vector3(0, lookMove.x));
            playerEyes.transform.Rotate(new Vector3(-lookMove.y, 0));
            if (interacting)
            {
                interactTime += Time.deltaTime;
                filledInteraction.fillAmount = interactTime / holdingTime;
            }
        }
        
    }
}


