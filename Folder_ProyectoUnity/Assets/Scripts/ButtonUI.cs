using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonUI : MonoBehaviour
{
    [SerializeField] Button myButton;
    [SerializeField] GameObject objectReference;
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
          objectReference.SetActive(true);  
    }





}
