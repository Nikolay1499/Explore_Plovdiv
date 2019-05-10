using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button accountButton;
    public Button landmarksButton;
    public Button achievementsButton;
    public Button logoutButton;

    public void ToggleMenu()
    {
        if (accountButton.gameObject.activeSelf == false)
        {
            accountButton.gameObject.SetActive(true);
            landmarksButton.gameObject.SetActive(true);
            achievementsButton.gameObject.SetActive(true);
            logoutButton.gameObject.SetActive(true);
        }
        else
        {
            accountButton.gameObject.SetActive(false);
            landmarksButton.gameObject.SetActive(false);
            achievementsButton.gameObject.SetActive(false);
            logoutButton.gameObject.SetActive(false);
        }
    }
}
