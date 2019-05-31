using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
