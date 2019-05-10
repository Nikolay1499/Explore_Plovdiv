using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConnectionCheck : MonoBehaviour
{
    public Text MessageText;
	void Start ()
    {
        StartCoroutine(CheckConnection());
	}

    IEnumerator CheckConnection()
    {
        while (Application.internetReachability == NetworkReachability.NotReachable)
        {
            yield return new WaitForSeconds(2);
            MessageText.text = "Моля свържете се с Интернет!";
        }
        while (!Input.location.isEnabledByUser)
        {
            yield return new WaitForSeconds(3);
            MessageText.text = "Моля включете услугата за местоположение!";
        }
        if (PlayerPrefs.HasKey("userEmail"))
        {
            SceneManager.LoadSceneAsync("MapScene");
        }
        else
        {
            SceneManager.LoadSceneAsync("LoginScene");
        }
    }
	
}
