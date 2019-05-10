using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAchievementStatus : MonoBehaviour
{
    public int id;
    public Image visited;
    public Image notVisited;

    private string url = "https://explore-plovdiv.000webhostapp.com/check_achievement.php";
    private string message;

    void Start()
    {
        StartCoroutine(CheckAchievement());
    }

    IEnumerator CheckAchievement()
    {
        WWWForm form = new WWWForm();
        form.AddField("userEmail", PlayerPrefs.GetString("userEmail"));
        form.AddField("achievementId", id);
        WWW www = new WWW(url, form);
        yield return www;
        message = www.text;
        if (message == "Постижението не е отключено!")
        {
            notVisited.gameObject.SetActive(true);
        }
        else
        {
            visited.gameObject.SetActive(true);
        }
    }
}
