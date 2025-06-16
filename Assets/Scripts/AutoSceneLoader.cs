using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneLoader : MonoBehaviour
{
    public string sceneName = "LupenMenu";
    public float delayInSeconds = 7.3f;

    void Start()
    {
        Invoke("LoadScene", delayInSeconds);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}