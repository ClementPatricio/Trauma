// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputSystem/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Movements"",
            ""id"": ""c8591720-ea4c-4bae-b8e5-ff90e8aed879"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""cf3c79b8-4a13-4096-b7d4-7c864ead6ba6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""b3e99992-0c63-4c46-aff7-3e447cf3346f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookAround"",
                    ""type"": ""Button"",
                    ""id"": ""9a985f35-83df-431c-90e7-7b8e6992f1c9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6e571658-791f-4c01-b77e-4cf96bad6948"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63b12f25-cc48-43b8-991b-89ae684be8c2"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fd75e6c-ee85-402b-8949-5a17e3bd2dc7"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movements
        m_Movements = asset.FindActionMap("Movements", throwIfNotFound: true);
        m_Movements_Interact = m_Movements.FindAction("Interact", throwIfNotFound: true);
        m_Movements_Move = m_Movements.FindAction("Move", throwIfNotFound: true);
        m_Movements_LookAround = m_Movements.FindAction("LookAround", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Movements
    private readonly InputActionMap m_Movements;
    private IMovementsActions m_MovementsActionsCallbackInterface;
    private readonly InputAction m_Movements_Interact;
    private readonly InputAction m_Movements_Move;
    private readonly InputAction m_Movements_LookAround;
    public struct MovementsActions
    {
        private @InputActions m_Wrapper;
        public MovementsActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Movements_Interact;
        public InputAction @Move => m_Wrapper.m_Movements_Move;
        public InputAction @LookAround => m_Wrapper.m_Movements_LookAround;
        public InputActionMap Get() { return m_Wrapper.m_Movements; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementsActions set) { return set.Get(); }
        public void SetCallbacks(IMovementsActions instance)
        {
            if (m_Wrapper.m_MovementsActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_MovementsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_MovementsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_MovementsActionsCallbackInterface.OnInteract;
                @Move.started -= m_Wrapper.m_MovementsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementsActionsCallbackInterface.OnMove;
                @LookAround.started -= m_Wrapper.m_MovementsActionsCallbackInterface.OnLookAround;
                @LookAround.performed -= m_Wrapper.m_MovementsActionsCallbackInterface.OnLookAround;
                @LookAround.canceled -= m_Wrapper.m_MovementsActionsCallbackInterface.OnLookAround;
            }
            m_Wrapper.m_MovementsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @LookAround.started += instance.OnLookAround;
                @LookAround.performed += instance.OnLookAround;
                @LookAround.canceled += instance.OnLookAround;
            }
        }
    }
    public MovementsActions @Movements => new MovementsActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IMovementsActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnLookAround(InputAction.CallbackContext context);
    }
}
