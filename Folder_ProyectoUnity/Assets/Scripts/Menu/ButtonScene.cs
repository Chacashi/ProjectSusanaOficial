using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonScene : MonoBehaviour
{
    [SerializeField] string sceneName;
     Button myButton;


    private void Awake()
    {
        myButton = GetComponent<Button>();  
    }
    private void Start()
    {
        
        myButton.onClick.AddListener(ChangueScene);
        Time.timeScale = 1.0f;
    }
    

    void ChangueScene()
    {

        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }
}
