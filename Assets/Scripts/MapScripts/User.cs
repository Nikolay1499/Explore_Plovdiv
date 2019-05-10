using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Examples;

public class User : MonoBehaviour
{
    public AbstractMap map;
    public Material[] colours;

    private void Start()
    {
        Renderer[] renderers = this.gameObject.transform.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.material = colours[PlayerPrefs.GetInt("colourId")];
        }
    }

    public void Center()
    {
        Vector2d currentLocation = new Vector2d(Input.location.lastData.latitude, Input.location.lastData.longitude);
        map.SetCenterLatitudeLongitude(currentLocation);
    }
}
