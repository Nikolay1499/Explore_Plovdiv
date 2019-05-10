using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLandmarkScene : MonoBehaviour
{
    void OnMouseDown()
    {
        PlayerPrefs.SetInt("LastScene", 2);
        this.gameObject.transform.parent.GetComponentInParent<SpawnLandmarks>().OnSphereClick();
    }
}
