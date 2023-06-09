//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Input/GameInput.inputactions
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

public partial class @GameInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Drawing"",
            ""id"": ""04817efe-877a-4ed7-b538-5740297e4395"",
            ""actions"": [
                {
                    ""name"": ""Draw"",
                    ""type"": ""Button"",
                    ""id"": ""7a37d19f-62e2-438d-a716-b34ae8a8cd10"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""80d33297-bcc1-44ba-af9c-8c6f44d4e9c7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f2ce2af1-5790-4829-85ed-af640c8dbddd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Draw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a981bab-0976-4380-89c8-628e414994c9"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Draw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67115130-7cb9-46fc-815e-a62ba95e36b3"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5c32d29-f308-4189-b3cb-6efefa996920"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Drawing
        m_Drawing = asset.FindActionMap("Drawing", throwIfNotFound: true);
        m_Drawing_Draw = m_Drawing.FindAction("Draw", throwIfNotFound: true);
        m_Drawing_MousePosition = m_Drawing.FindAction("MousePosition", throwIfNotFound: true);
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

    // Drawing
    private readonly InputActionMap m_Drawing;
    private List<IDrawingActions> m_DrawingActionsCallbackInterfaces = new List<IDrawingActions>();
    private readonly InputAction m_Drawing_Draw;
    private readonly InputAction m_Drawing_MousePosition;
    public struct DrawingActions
    {
        private @GameInput m_Wrapper;
        public DrawingActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Draw => m_Wrapper.m_Drawing_Draw;
        public InputAction @MousePosition => m_Wrapper.m_Drawing_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Drawing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DrawingActions set) { return set.Get(); }
        public void AddCallbacks(IDrawingActions instance)
        {
            if (instance == null || m_Wrapper.m_DrawingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DrawingActionsCallbackInterfaces.Add(instance);
            @Draw.started += instance.OnDraw;
            @Draw.performed += instance.OnDraw;
            @Draw.canceled += instance.OnDraw;
            @MousePosition.started += instance.OnMousePosition;
            @MousePosition.performed += instance.OnMousePosition;
            @MousePosition.canceled += instance.OnMousePosition;
        }

        private void UnregisterCallbacks(IDrawingActions instance)
        {
            @Draw.started -= instance.OnDraw;
            @Draw.performed -= instance.OnDraw;
            @Draw.canceled -= instance.OnDraw;
            @MousePosition.started -= instance.OnMousePosition;
            @MousePosition.performed -= instance.OnMousePosition;
            @MousePosition.canceled -= instance.OnMousePosition;
        }

        public void RemoveCallbacks(IDrawingActions instance)
        {
            if (m_Wrapper.m_DrawingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDrawingActions instance)
        {
            foreach (var item in m_Wrapper.m_DrawingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DrawingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DrawingActions @Drawing => new DrawingActions(this);
    public interface IDrawingActions
    {
        void OnDraw(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
