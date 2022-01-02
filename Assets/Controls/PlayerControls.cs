// GENERATED AUTOMATICALLY FROM 'Assets/Controls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""4f8d9adf-0ca6-4cce-900b-0b0decdd2e5c"",
            ""actions"": [
                {
                    ""name"": ""MoveKeys"",
                    ""type"": ""Value"",
                    ""id"": ""f397a0a3-38c2-4c17-a0e7-d215735d8158"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""MoveVec"",
                    ""id"": ""0acbb5d2-2722-4464-8a10-268608848447"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeys"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""700fac9f-1cf0-4564-b41b-b8a8aff662d5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""01c1c107-9be5-4027-bd28-a5cdffccf511"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6bfe3c6f-575d-4871-aea2-e5c2b8f788a6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0dd17474-483d-4d57-9085-7a5a9dd4b8f0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_MoveKeys = m_Keyboard.FindAction("MoveKeys", throwIfNotFound: true);
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

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_MoveKeys;
    public struct KeyboardActions
    {
        private @PlayerControls m_Wrapper;
        public KeyboardActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveKeys => m_Wrapper.m_Keyboard_MoveKeys;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @MoveKeys.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveKeys;
                @MoveKeys.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveKeys;
                @MoveKeys.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveKeys;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveKeys.started += instance.OnMoveKeys;
                @MoveKeys.performed += instance.OnMoveKeys;
                @MoveKeys.canceled += instance.OnMoveKeys;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface IKeyboardActions
    {
        void OnMoveKeys(InputAction.CallbackContext context);
    }
}
