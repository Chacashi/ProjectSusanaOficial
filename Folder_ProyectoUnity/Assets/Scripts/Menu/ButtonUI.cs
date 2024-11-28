using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonUI : MonoBehaviour
{
    Button myButton;
    [SerializeField] GameObject[] objectReferences;
    [SerializeField] GameObject[] objectButtons;
    private void Awake()
    {
        myButton = GetComponent<Button>();
    }

    private void Start()
    {
        myButton.onClick.AddListener(Interactue);
    }

    void Interactue()
    {
        for (int i = 0; i < objectReferences.Length; i++)
        {
            if (objectReferences[i].activeSelf)
            {
                
                objectReferences[i].SetActive(false);
                //Time.timeScale = 1.0f;
            }
            else
            {
                objectReferences[i].SetActive(true);
                //Time.timeScale = 0.0f;
            }
        }


        for(int i = 0;i < objectButtons.Length; i++)
        {
            if (objectButtons[i].GetComponent<Button>().interactable)
            {
                objectButtons[i].GetComponent<Button>().interactable = false;
            }
            else
            {
                objectButtons[i].GetComponent<Button>().interactable = true;
            }
        }
        
          
    }





}
