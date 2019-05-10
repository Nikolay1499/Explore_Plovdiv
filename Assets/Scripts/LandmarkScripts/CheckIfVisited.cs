using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckIfVisited : MonoBehaviour
{
    public int id;
    public Text infoText;
    public Text lockText;
    public Button cameraButton;

    private string url= "https://explore-plovdiv.000webhostapp.com/check_landmark.php";
    private string message;

    void Start()
    {
        StartCoroutine(CheckLandmark());
    }

    IEnumerator CheckLandmark()
    {
        WWWForm form = new WWWForm();
        form.AddField("userEmail", PlayerPrefs.GetString("userEmail"));
        form.AddField("landmarkId", id);
        WWW www = new WWW(url, form);
        yield return www;
        message = www.text;
        if(message== "Забележителността не е посетена!")
        {
            lockText.gameObject.SetActive(true);
            cameraButton.gameObject.SetActive(true);
        }
        else
        {
            infoText.gameObject.SetActive(true);
        }
    }
}
