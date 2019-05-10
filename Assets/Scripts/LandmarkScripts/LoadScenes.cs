using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void LoadScene(int sceneindex)
    {
        PlayerPrefs.SetInt("SceneNum",SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(sceneindex);
    }

}
