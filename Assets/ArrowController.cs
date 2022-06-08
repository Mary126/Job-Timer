using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public string type;
    public TimeController timeController;
    public ClockController clockController;
    public float angle;
    public GameObject arrowBody;
    public float rotationSpeed;

    private void OnMouseDrag()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        arrowBody.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (type == "seconds")
        {
            int seconds = (int)(angle / 6.0f);
            if (seconds > 0) seconds = 60 - seconds;
            else seconds = Mathf.Abs(seconds);
            timeController.seconds = seconds;
            clockController.SetMinutes(timeController.seconds, timeController.minute);
        }
        else if (type == "minutes")
        {
            int minutes = (int)((angle * 10 - timeController.seconds) / 60);
            if (minutes > 0) minutes = 60 - minutes;
            else minutes = Mathf.Abs(minutes);
            timeController.minute = minutes;
            clockController.SetHours(timeController.hour, minutes);
        }
        else if (type == "hours")
        {
            int hours = (int)((angle * 2 - timeController.minute) / 60);
            if (hours > 0) hours = 12 - hours;
            else hours = Mathf.Abs(hours);
            if (timeController.hour > 12) hours = 12 + hours;
            timeController.hour = hours;
        }
        timeController.DisplayTime();
    }
}
