using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLandmarkStatus : MonoBehaviour
{
    public int id;
    public Image visited;
    public Image notVisited;

    private string url = "https://explore-plovdiv.000webhostapp.com/check_landmark.php";
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
        if (message == "Забележителността не е посетена!")
        {
            notVisited.gameObject.SetActive(true);
        }
        else
        {
            visited.gameObject.SetActive(true);
        }
    }
}
