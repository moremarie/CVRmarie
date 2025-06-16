using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SzeneWechsler : MonoBehaviour
{
    [Tooltip("Name der Zielszene (muss exakt mit Build Settings übereinstimmen)")]
    public string szenenName;

    public void LadeSzene()
    {
        if (!string.IsNullOrEmpty(szenenName))
        {
            SceneManager.LoadScene(szenenName);
        }
        else
        {
            Debug.LogWarning("Szenenname ist leer! Szene wird nicht geladen.");
        }
    }
}
