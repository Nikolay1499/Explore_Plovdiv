using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBack : MonoBehaviour {

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("SceneNum"));
    }
}
