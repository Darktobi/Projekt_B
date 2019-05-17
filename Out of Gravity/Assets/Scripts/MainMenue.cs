﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenue : MonoBehaviour {

    public void LoadScene(string sceneName)
    {
        if (sceneName == "Prototype")
        {
            SceneManager.LoadScene("Prototype");
        }
       else if (sceneName == "Demo")
        {
            SceneManager.LoadScene("Demo");
        }

        else if (sceneName == "Level1")
        {
            SceneManager.LoadScene("Level1");
        }
    }

    public void ExtitGame()
    {
        Application.Quit();
    }
}
