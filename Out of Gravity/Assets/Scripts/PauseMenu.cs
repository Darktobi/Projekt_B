using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public Canvas canvasPause;

    private bool isPaused;
    // Use this for initialization
    void Start () {
        GoOnFunktions();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                GoOnFunktions();
            }
            else
            {
                Pause();
                canvasPause.gameObject.SetActive(true);
            }

        }
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        isPaused = true;
    }

    public void GoOnFunktions()
    {
        canvasPause.gameObject.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    public void To_Main_Menu()
    {
        SceneManager.LoadScene("Hauptmenu");
    }
}
