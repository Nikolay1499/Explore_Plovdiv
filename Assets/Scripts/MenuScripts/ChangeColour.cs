using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColour : MonoBehaviour
{
    public Image selectedImage;
    public Sprite lockedImage;
    public int colourId;

    private string url;
    private string message;

    void Start()
    {
        StartCoroutine(GetColour());
    }

    public void ChooseColour()
    {
        GameObject.Find("Selected").SetActive(false);
        PlayerPrefs.SetInt("colourId", colourId);
        PlayerPrefs.Save();
        selectedImage.gameObject.SetActive(true);
    }

    IEnumerator GetColour()
    {
        if (colourId != 0)
        {
            url = "https://explore-plovdiv.000webhostapp.com/check_achievement.php";

            WWWForm form = new WWWForm();
            form.AddField("userEmail", PlayerPrefs.GetString("userEmail"));
            form.AddField("achievementId", colourId - 1);
            WWW www = new WWW(url, form);
            yield return www;
            message = www.text;

            if (message == "Постижението не е отключено!")
            {
                this.GetComponent<Button>().enabled = false;
                this.GetComponent<Image>().sprite = lockedImage;
                this.GetComponent<Image>().color = Color.white;
            }          
        }
        if (colourId == PlayerPrefs.GetInt("colourId"))
        {
            selectedImage.gameObject.SetActive(true);
        }
    }
}
