//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/PlayerInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Inputs"",
            ""id"": ""9611e288-785b-45dd-9fe6-460e451888de"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""fe77544e-3c3d-44c4-96fb-7b3213330d22"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""caa2637e-0843-49c1-aeb9-207ff685692e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RollDice"",
                    ""type"": ""Button"",
                    ""id"": ""123679d1-497b-4fb0-9ec6-7d85feb49caf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""431dfc27-14cb-4be2-b7a5-46b911f7058b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Kick"",
                    ""type"": ""Button"",
                    ""id"": ""37f8f967-bab3-4a3f-ae66-7c2f28eb1e25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4d68e9b8-f4be-4f58-a6d9-5658799cc6e9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c375373f-ddde-478d-9484-d8feb54d9048"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3ee87e31-4252-4aa8-b2f9-708630be521a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f87d2810-02ac-430f-abd0-46cf5e2edbb6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f6382830-cf6a-43f2-ad73-0222a3f01426"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57450009-e18a-4a5e-bd88-a73adc7d8587"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollDice"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""674e91ce-aabc-4da7-96c7-b4bc1fed78bb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""855a917d-3bb0-4bbf-a199-41f9439c351e"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Inputs
        m_Inputs = asset.FindActionMap("Inputs", throwIfNotFound: true);
        m_Inputs_Move = m_Inputs.FindAction("Move", throwIfNotFound: true);
        m_Inputs_Jump = m_Inputs.FindAction("Jump", throwIfNotFound: true);
        m_Inputs_RollDice = m_Inputs.FindAction("RollDice", throwIfNotFound: true);
        m_Inputs_Start = m_Inputs.FindAction("Start", throwIfNotFound: true);
        m_Inputs_Kick = m_Inputs.FindAction("Kick", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Inputs
    private readonly InputActionMap m_Inputs;
    private IInputsActions m_InputsActionsCallbackInterface;
    private readonly InputAction m_Inputs_Move;
    private readonly InputAction m_Inputs_Jump;
    private readonly InputAction m_Inputs_RollDice;
    private readonly InputAction m_Inputs_Start;
    private readonly InputAction m_Inputs_Kick;
    public struct InputsActions
    {
        private @PlayerInputs m_Wrapper;
        public InputsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Inputs_Move;
        public InputAction @Jump => m_Wrapper.m_Inputs_Jump;
        public InputAction @RollDice => m_Wrapper.m_Inputs_RollDice;
        public InputAction @Start => m_Wrapper.m_Inputs_Start;
        public InputAction @Kick => m_Wrapper.m_Inputs_Kick;
        public InputActionMap Get() { return m_Wrapper.m_Inputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputsActions set) { return set.Get(); }
        public void SetCallbacks(IInputsActions instance)
        {
            if (m_Wrapper.m_InputsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnJump;
                @RollDice.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnRollDice;
                @RollDice.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnRollDice;
                @RollDice.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnRollDice;
                @Start.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnStart;
                @Kick.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnKick;
                @Kick.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnKick;
                @Kick.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnKick;
            }
            m_Wrapper.m_InputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @RollDice.started += instance.OnRollDice;
                @RollDice.performed += instance.OnRollDice;
                @RollDice.canceled += instance.OnRollDice;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
                @Kick.started += instance.OnKick;
                @Kick.performed += instance.OnKick;
                @Kick.canceled += instance.OnKick;
            }
        }
    }
    public InputsActions @Inputs => new InputsActions(this);
    public interface IInputsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRollDice(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnKick(InputAction.CallbackContext context);
    }
}
