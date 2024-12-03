
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonScene : ButtonController
{
    [SerializeField] private string _sceneName;


    protected override void Interactue()
    {
        SceneManager.LoadScene(_sceneName);
    }


}
