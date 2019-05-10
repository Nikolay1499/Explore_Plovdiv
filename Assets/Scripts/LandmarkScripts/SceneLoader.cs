using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void LoadScene()
    {
        PlayerPrefs.SetInt("SceneNum", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("LastScene"));
    }

    public void LoadCamera()
    {
        PlayerPrefs.SetInt("SceneNum", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync("CameraScene");
    }
}
