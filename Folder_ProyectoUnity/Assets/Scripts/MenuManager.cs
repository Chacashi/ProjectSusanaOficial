using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCameraBase arrayVCcam;
    [SerializeField] Button[] arrayButtons;

    public void TurnOnOff(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            arrayVCcam.gameObject.SetActive(false);
            for (int i = 0; i < arrayButtons.Length; i++)
            {
                arrayButtons[i].GetComponent<Button>().interactable = true;
            }
        }
    }


}

