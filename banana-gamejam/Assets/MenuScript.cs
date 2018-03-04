using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}