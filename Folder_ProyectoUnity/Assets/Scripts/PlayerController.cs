using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody _compRigidbody;
    [SerializeField] GameObject objectiveUI;
    float horizontal;
    float vertical;
    public float speed;


    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }


    public void AxisX(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<float>();
    }
   

    public void AxisZ(InputAction.CallbackContext context)
    {
        vertical = context.ReadValue<float>();
    }


    public void ButtonEsc(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(objectiveUI.activeSelf)
            {

                objectiveUI.SetActive(false);
                Time.timeScale = 1.0f;
            }
            else
            {
                objectiveUI.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }

    private void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector3(speed * horizontal,_compRigidbody.velocity.y ,vertical*speed);
    }

}
