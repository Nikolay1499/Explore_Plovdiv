using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnLandmarks : MonoBehaviour
{
    public Material visitedMaterial;

    private static LandmarkInformation script;
    private static int count;
    private int maxCount = 27;
    private static bool isInisialized;
    private int id;
    private string url = "https://explore-plovdiv.000webhostapp.com/check_landmark.php";
    private string message;

    void Start()
    {
        if (!isInisialized)
        {
            count = 1;
            script = this.GetComponent<LandmarkInformation>();
            isInisialized = true;
        }
        if (count > maxCount)
        {
            count = 1;
        }
        id = count - 1;
        count++;
        this.gameObject.name = script.GetLandmarkName(id);
        GameObject landmarksObject = GameObject.Find("Landmarks");
        this.transform.parent = landmarksObject.transform;
        StartCoroutine(CheckLandmarkStatus());
    }

    IEnumerator CheckLandmarkStatus()
    {
        WWWForm form = new WWWForm();
        form.AddField("userEmail", PlayerPrefs.GetString("userEmail"));
        form.AddField("landmarkId", id);
        WWW www = new WWW(url, form);
        yield return www;
        message = www.text;
        if (message != "Забележителността не е посетена!")
        {
            Renderer[] renderers = this.gameObject.transform.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                renderer.material = visitedMaterial;
            }
        }
    }

    public void OnSphereClick()
    {
        string sceneName = "Landmark" + id + "Scene";
        SceneManager.LoadSceneAsync(sceneName);
    }
}
