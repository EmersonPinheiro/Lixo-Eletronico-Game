using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }


    public void StartGame()
    {

#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel(1);
#pragma warning restore CS0618 // Type or member is obsolete

    }

    public void Quit()
    {
        Application.Quit();
    }
}
