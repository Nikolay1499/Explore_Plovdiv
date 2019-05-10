using Facebook.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{
    private string url = "https://explore-plovdiv.000webhostapp.com/change_colour.php";


    public void LogOut()
    {
        StartCoroutine(SaveColour());
        PlayerPrefs.DeleteKey("userEmail");
        PlayerPrefs.DeleteKey("colourId");
        PlayerPrefs.Save();

        SceneManager.LoadSceneAsync("LoginScene");
        FB.LogOut();
    }

    IEnumerator SaveColour()
    {
        WWWForm form = new WWWForm();
        form.AddField("userEmail", PlayerPrefs.GetString("userEmail"));
        form.AddField("colourId", PlayerPrefs.GetInt("colourId"));
        WWW www = new WWW(url, form);
        yield return www;
    }
}
