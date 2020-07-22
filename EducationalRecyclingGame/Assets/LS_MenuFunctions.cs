using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LS_MenuFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play() {
    	SceneManager.LoadScene(sceneName: "LS_Test_Scene");
    }

    public void Options() {
    	SceneManager.LoadScene(sceneName: "LS_Options_Scene");
    }

    public void Quit() {
    	Application.Quit();
    }
}
