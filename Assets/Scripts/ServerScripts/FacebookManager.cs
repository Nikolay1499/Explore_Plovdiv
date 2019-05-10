using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using System.Collections;
using System.Collections.Generic;
using Facebook.MiniJSON;
using UnityEngine.SceneManagement;

public class FacebookManager : MonoBehaviour
{
    AccessToken token;
    private string url = "https://explore-plovdiv.000webhostapp.com/register.php";
    private int landmarksCount = 27;
    private int achievementsCount = 13;

    private void Start()
    {
        if (!FB.IsInitialized)
        {
            FB.Init();
        }
        else {
            FB.ActivateApp();
        }
        DealWithFBMenus(FB.IsLoggedIn);
    }

    public void Login()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            FB.LogInWithReadPermissions(callback: OnLogIn);
        }
        else
        {
            //StartCoroutine(NoInternet());
        }
    }
    /*IEnumerator NoInternet()
    {
        obj3.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        obj3.SetActive(false);
    }*/
    private void OnLogIn(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            token = AccessToken.CurrentAccessToken;
        }
        else
        {
            Debug.Log("Inable to log");
        }
        DealWithFBMenus(FB.IsLoggedIn);
    }
    void DealWithFBMenus(bool isLoggedIn)
    {
        if(isLoggedIn==true)
        FB.API("/me?fields=first_name,last_name", HttpMethod.GET, DisplayUsername);

    }

    void DisplayUsername(IResult result)
    {

        if (result.Error == null)
        {

            WWWForm form = new WWWForm();
            form.AddField("firstName", (string)result.ResultDictionary["first_name"]);
            form.AddField("familyName", (string)result.ResultDictionary["last_name"]);
            form.AddField("email", token.UserId);
            form.AddField("password", "");
            form.AddField("landmarksCount", landmarksCount);
            form.AddField("achievementsCount", achievementsCount);
            WWW www = new WWW(url, form);
            PlayerPrefs.SetString("userEmail", token.UserId);
            PlayerPrefs.SetInt("colourId", 0);
            PlayerPrefs.Save();
            SceneManager.LoadSceneAsync("MapScene");

        }
    }
    public void Share()
    {
        FB.ShareLink(contentTitle: "Google Page message",
            contentURL: new System.Uri("https://www.google.bg/"),
            contentDescription: "Link to Google",
            callback: OnShare);
    }

    private void OnShare(IShareResult result)
    {
        if (result.Cancelled|| string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Share link error");
        }
        else if (!string.IsNullOrEmpty(result.PostId))
        {
            Debug.Log(result.PostId);
        }
        else
        {
            Debug.Log("Share succeed");
        }
    }

    public void Loggingout()
    {
        FB.LogOut();
    }
}

