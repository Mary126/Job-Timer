using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationController : MonoBehaviour
{
    public GameObject Clock;

    void Update()
    {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            Clock.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            Clock.transform.localScale = new Vector3(1f, 1f, 1);
        }
    }
}
