using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;

public class SetZoomInterval : MonoBehaviour
{

    public AbstractMap map;
    public float minZoom;
    public float maxZoom;

    void Update()
    {
        if (map.Zoom < minZoom)
        {
            map.SetZoom(minZoom);
        }
        else if (map.Zoom > maxZoom)
        {
            map.SetZoom(maxZoom);
        }
    } 
}
