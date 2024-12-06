
using UnityEngine;
using UnityEngine.InputSystem;
using System;



public class InputReaderMenu : MonoBehaviour
{

    PlayerInput input;
    public static event Action OnPressedSpace;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

  

    public void TurnOnOff(InputAction.CallbackContext context)
    {
       
        if (context.performed)
        {
            OnPressedSpace.Invoke();
            input.enabled = false;
        }
    }
  

    

    
}

