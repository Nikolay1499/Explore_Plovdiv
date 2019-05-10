using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetData : MonoBehaviour
{
    public Text text;
    public string url;

    private string message;

    void Start()
    {
        StartCoroutine(RecieveData());
    }

    IEnumerator RecieveData()
    {
        WWWForm form = new WWWForm();
        form.AddField("userEmail", PlayerPrefs.GetString("userEmail"));
        WWW www = new WWW(url, form);
        yield return www;
        message = www.text;
        text.text = text.text + message;
    }
}
