using UnityEngine;

public class ButtonExit : ButtonController
{

    protected override void Interactue()
    {
        print("Saliste");
        Application.Quit();
    }

}
