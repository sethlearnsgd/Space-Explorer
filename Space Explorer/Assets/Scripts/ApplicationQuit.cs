using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
    private SpaceExplorer spaceExplorer;

    void Awake()
    {
        spaceExplorer = new SpaceExplorer();

        spaceExplorer.Enable();
    }

    
    void Update()
    {
        bool isEscapeKeyPressed = spaceExplorer.Player.Exit.ReadValue<float>() > 0.1f;

        if (isEscapeKeyPressed)
        {
            Debug.Log("Escape key is pressed");
            Application.Quit();
        }
    }
}
