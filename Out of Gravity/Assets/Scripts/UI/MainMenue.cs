using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MainMenue : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene(1);
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
