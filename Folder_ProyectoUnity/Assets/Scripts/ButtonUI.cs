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
    private void Awake()
    {
        myButton = GetComponent<Button>();
    }

    private void Start()
    {
        myButton.onClick.AddListener(OnClick);
    }

    void OnClick()
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
        
          
    }





}
