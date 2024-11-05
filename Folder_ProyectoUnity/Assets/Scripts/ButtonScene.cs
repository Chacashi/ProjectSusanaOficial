using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] Button myButton;


    private void Awake()
    {
        myButton = GetComponent<Button>();  
    }
    private void Start()
    {
        
        myButton.onClick.AddListener(OnClick);
        Time.timeScale = 1.0f;
    }
    

    void OnClick()
    {

        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }
}
