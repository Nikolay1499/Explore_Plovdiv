using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoLandmark : MonoBehaviour {

    public GameObject found;

    public void LoadScene(int sceneindex)
    {
        if(found.activeInHierarchy==true)
        {
            PlayerPrefs.SetInt("LastScene", 6);
            SceneManager.LoadSceneAsync(sceneindex);
        }
    }
}
