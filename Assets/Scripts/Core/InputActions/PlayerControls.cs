//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Controls/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerMoving"",
            ""id"": ""4dca9928-ad99-4ef9-8a5c-c79d9817f411"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""526e7cb5-9769-4f15-8c5f-26fbab35041e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4a043e45-5dca-4383-adc5-1fa9323aed90"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PrepareAction"",
                    ""type"": ""Button"",
                    ""id"": ""1c9b5177-935f-48e5-8d0d-f711b6968b3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""226e30a9-72a2-479c-ae32-4f991015c8c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""da759d44-7312-4111-8bb3-cab9b0e60eef"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9627bd21-fb25-46ae-8987-ed2155bdcf89"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""06c80a7d-e2ef-4bdc-a7aa-8e04910f6abb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""261b46aa-7ec9-47c5-a2a1-0842b753e2fb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e2f336f1-c7bd-4030-8394-c6e78b779db9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e1e1bd20-63ae-4820-b101-3af3a3d9bb58"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""40c350fa-729c-4c7d-90ed-e58fc0a025a3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""740cb370-72c7-40dc-8c51-5504150b9b35"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2f3b67a-a971-44f5-ac09-47d4f6084459"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""PrepareAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ccd5d8a4-1c9c-4f30-a4f4-e9d15dc8ce57"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PrepareAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73179dc0-6736-4d4a-b22d-9925ce7691ef"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24727830-8176-46e8-829d-3cc401df5bee"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerPreparing"",
            ""id"": ""0ef95e12-1d57-428b-beda-d6dc2dab3c67"",
            ""actions"": [
                {
                    ""name"": ""PerformAction"",
                    ""type"": ""Button"",
                    ""id"": ""947daccf-f8fb-46c9-808d-55d5907b5aab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CancelAction"",
                    ""type"": ""Button"",
                    ""id"": ""f98bdd61-724c-42bb-aeb7-2f5ee387c819"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7503ac74-d213-4482-8ffa-0cc9548dac21"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""PerformAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78f50577-234d-444d-81e6-f78bedb88d1a"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PerformAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d9f4b04-bc5b-4847-9ae2-888fab3296f8"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""CancelAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e10748d7-22bb-47a8-b48c-799a71b9aa25"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CancelAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerBase"",
            ""id"": ""0b336798-b510-4df0-b902-cc3f918a41de"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""143e2a38-37e5-4a14-8716-1c2d984ee1ad"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SwitchActionRight"",
                    ""type"": ""Button"",
                    ""id"": ""7236c571-fa36-4725-a7e9-a29c6ce85822"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchActionLeft"",
                    ""type"": ""Button"",
                    ""id"": ""9942022d-96af-4d88-acb5-307f1c22dc19"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6b7c8863-3a91-4e37-bc5b-03d1424b3df8"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40d4d074-8b2f-4453-abc3-8f7c441d6990"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""003ed3ac-c350-486b-b09b-2811391e5dca"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SwitchActionRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0a64190-02f5-4bf7-8a6a-b94aaafdbd0c"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SwitchActionRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2aed6aa4-5ffa-43cb-af62-7f9c205bc9f3"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SwitchActionLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8619fc1b-e73f-465b-86a5-12988eb57617"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SwitchActionLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
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
        // PlayerMoving
        m_PlayerMoving = asset.FindActionMap("PlayerMoving", throwIfNotFound: true);
        m_PlayerMoving_Jump = m_PlayerMoving.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMoving_Move = m_PlayerMoving.FindAction("Move", throwIfNotFound: true);
        m_PlayerMoving_PrepareAction = m_PlayerMoving.FindAction("PrepareAction", throwIfNotFound: true);
        m_PlayerMoving_Cancel = m_PlayerMoving.FindAction("Cancel", throwIfNotFound: true);
        // PlayerPreparing
        m_PlayerPreparing = asset.FindActionMap("PlayerPreparing", throwIfNotFound: true);
        m_PlayerPreparing_PerformAction = m_PlayerPreparing.FindAction("PerformAction", throwIfNotFound: true);
        m_PlayerPreparing_CancelAction = m_PlayerPreparing.FindAction("CancelAction", throwIfNotFound: true);
        // PlayerBase
        m_PlayerBase = asset.FindActionMap("PlayerBase", throwIfNotFound: true);
        m_PlayerBase_Look = m_PlayerBase.FindAction("Look", throwIfNotFound: true);
        m_PlayerBase_SwitchActionRight = m_PlayerBase.FindAction("SwitchActionRight", throwIfNotFound: true);
        m_PlayerBase_SwitchActionLeft = m_PlayerBase.FindAction("SwitchActionLeft", throwIfNotFound: true);
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

    // PlayerMoving
    private readonly InputActionMap m_PlayerMoving;
    private IPlayerMovingActions m_PlayerMovingActionsCallbackInterface;
    private readonly InputAction m_PlayerMoving_Jump;
    private readonly InputAction m_PlayerMoving_Move;
    private readonly InputAction m_PlayerMoving_PrepareAction;
    private readonly InputAction m_PlayerMoving_Cancel;
    public struct PlayerMovingActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovingActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_PlayerMoving_Jump;
        public InputAction @Move => m_Wrapper.m_PlayerMoving_Move;
        public InputAction @PrepareAction => m_Wrapper.m_PlayerMoving_PrepareAction;
        public InputAction @Cancel => m_Wrapper.m_PlayerMoving_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMoving; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovingActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovingActions instance)
        {
            if (m_Wrapper.m_PlayerMovingActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerMovingActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovingActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovingActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_PlayerMovingActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMovingActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMovingActionsCallbackInterface.OnMove;
                @PrepareAction.started -= m_Wrapper.m_PlayerMovingActionsCallbackInterface.OnPrepareAction;
                @PrepareAction.performed -= m_Wrapper.m_PlayerMovingActionsCallbackInterface.OnPrepareAction;
                @PrepareAction.canceled -= m_Wrapper.m_PlayerMovingActionsCallbackInterface.OnPrepareAction;
                @Cancel.started -= m_Wrapper.m_PlayerMovingActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_PlayerMovingActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_PlayerMovingActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_PlayerMovingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @PrepareAction.started += instance.OnPrepareAction;
                @PrepareAction.performed += instance.OnPrepareAction;
                @PrepareAction.canceled += instance.OnPrepareAction;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public PlayerMovingActions @PlayerMoving => new PlayerMovingActions(this);

    // PlayerPreparing
    private readonly InputActionMap m_PlayerPreparing;
    private IPlayerPreparingActions m_PlayerPreparingActionsCallbackInterface;
    private readonly InputAction m_PlayerPreparing_PerformAction;
    private readonly InputAction m_PlayerPreparing_CancelAction;
    public struct PlayerPreparingActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerPreparingActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PerformAction => m_Wrapper.m_PlayerPreparing_PerformAction;
        public InputAction @CancelAction => m_Wrapper.m_PlayerPreparing_CancelAction;
        public InputActionMap Get() { return m_Wrapper.m_PlayerPreparing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerPreparingActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerPreparingActions instance)
        {
            if (m_Wrapper.m_PlayerPreparingActionsCallbackInterface != null)
            {
                @PerformAction.started -= m_Wrapper.m_PlayerPreparingActionsCallbackInterface.OnPerformAction;
                @PerformAction.performed -= m_Wrapper.m_PlayerPreparingActionsCallbackInterface.OnPerformAction;
                @PerformAction.canceled -= m_Wrapper.m_PlayerPreparingActionsCallbackInterface.OnPerformAction;
                @CancelAction.started -= m_Wrapper.m_PlayerPreparingActionsCallbackInterface.OnCancelAction;
                @CancelAction.performed -= m_Wrapper.m_PlayerPreparingActionsCallbackInterface.OnCancelAction;
                @CancelAction.canceled -= m_Wrapper.m_PlayerPreparingActionsCallbackInterface.OnCancelAction;
            }
            m_Wrapper.m_PlayerPreparingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PerformAction.started += instance.OnPerformAction;
                @PerformAction.performed += instance.OnPerformAction;
                @PerformAction.canceled += instance.OnPerformAction;
                @CancelAction.started += instance.OnCancelAction;
                @CancelAction.performed += instance.OnCancelAction;
                @CancelAction.canceled += instance.OnCancelAction;
            }
        }
    }
    public PlayerPreparingActions @PlayerPreparing => new PlayerPreparingActions(this);

    // PlayerBase
    private readonly InputActionMap m_PlayerBase;
    private IPlayerBaseActions m_PlayerBaseActionsCallbackInterface;
    private readonly InputAction m_PlayerBase_Look;
    private readonly InputAction m_PlayerBase_SwitchActionRight;
    private readonly InputAction m_PlayerBase_SwitchActionLeft;
    public struct PlayerBaseActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerBaseActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look => m_Wrapper.m_PlayerBase_Look;
        public InputAction @SwitchActionRight => m_Wrapper.m_PlayerBase_SwitchActionRight;
        public InputAction @SwitchActionLeft => m_Wrapper.m_PlayerBase_SwitchActionLeft;
        public InputActionMap Get() { return m_Wrapper.m_PlayerBase; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerBaseActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerBaseActions instance)
        {
            if (m_Wrapper.m_PlayerBaseActionsCallbackInterface != null)
            {
                @Look.started -= m_Wrapper.m_PlayerBaseActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerBaseActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerBaseActionsCallbackInterface.OnLook;
                @SwitchActionRight.started -= m_Wrapper.m_PlayerBaseActionsCallbackInterface.OnSwitchActionRight;
                @SwitchActionRight.performed -= m_Wrapper.m_PlayerBaseActionsCallbackInterface.OnSwitchActionRight;
                @SwitchActionRight.canceled -= m_Wrapper.m_PlayerBaseActionsCallbackInterface.OnSwitchActionRight;
                @SwitchActionLeft.started -= m_Wrapper.m_PlayerBaseActionsCallbackInterface.OnSwitchActionLeft;
                @SwitchActionLeft.performed -= m_Wrapper.m_PlayerBaseActionsCallbackInterface.OnSwitchActionLeft;
                @SwitchActionLeft.canceled -= m_Wrapper.m_PlayerBaseActionsCallbackInterface.OnSwitchActionLeft;
            }
            m_Wrapper.m_PlayerBaseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @SwitchActionRight.started += instance.OnSwitchActionRight;
                @SwitchActionRight.performed += instance.OnSwitchActionRight;
                @SwitchActionRight.canceled += instance.OnSwitchActionRight;
                @SwitchActionLeft.started += instance.OnSwitchActionLeft;
                @SwitchActionLeft.performed += instance.OnSwitchActionLeft;
                @SwitchActionLeft.canceled += instance.OnSwitchActionLeft;
            }
        }
    }
    public PlayerBaseActions @PlayerBase => new PlayerBaseActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerMovingActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnPrepareAction(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
    public interface IPlayerPreparingActions
    {
        void OnPerformAction(InputAction.CallbackContext context);
        void OnCancelAction(InputAction.CallbackContext context);
    }
    public interface IPlayerBaseActions
    {
        void OnLook(InputAction.CallbackContext context);
        void OnSwitchActionRight(InputAction.CallbackContext context);
        void OnSwitchActionLeft(InputAction.CallbackContext context);
    }
}
