using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public void PlayGame(){
        SceneFade.LoadScene("Game");
    }

    public void GoToMainMenu()
    {
        SceneFade.LoadScene("Main");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
