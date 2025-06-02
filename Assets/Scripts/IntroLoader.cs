using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroLoader : MonoBehaviour
{
    public string sceneName = "Klassenzimmer"; // Name meiner Zielszene

    void Start()
    {
        Debug.Log(" Video gestartet"); // <-- NEU
        GetComponent<VideoPlayer>().loopPointReached += LoadNextScene;
    }

    void LoadNextScene(VideoPlayer vp)
    {
        Debug.Log("Video fertig Szene wird geladen!"); // <-- NEU
        SceneManager.LoadScene(sceneName);
    }
}
