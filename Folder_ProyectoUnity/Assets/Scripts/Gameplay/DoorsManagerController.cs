using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsManagerController : MonoBehaviour
{
    [SerializeField] GameObject[] arrayDoors;




    private void OnEnable()
    {
        scheduleController.OnPressButtonCourse += ActiveDoor;
        scheduleController.OnPressButtonCourse += DesactiveDoor;
    }

    private void OnDisable()
    {
        scheduleController.OnPressButtonCourse -= ActiveDoor;
        scheduleController.OnPressButtonCourse -= DesactiveDoor;
    }

    void ActiveDoor(string tag)
    {
        
        for (int i = 0; i < arrayDoors.Length; i++)
        {

            if (arrayDoors[i].CompareTag(tag))
            {
                arrayDoors[i].SetActive(true);
            }
            
        }
    }

    void DesactiveDoor(string tag)
    {
        for (int i = 0; i < arrayDoors.Length; i++)
        {

            if (arrayDoors[i].tag!= tag)
            {
                arrayDoors[i].SetActive(false);
            }

        }
    }
}
