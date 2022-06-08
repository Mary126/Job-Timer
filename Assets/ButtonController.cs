using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public TimeController timeController;
    public UnityEngine.UI.Button buttn;

    void ButtnClick()
    {
        if (tag == "Set Time Button")
        {
            timeController.SetUserTime(int.Parse(timeController.secondsText.text), int.Parse(timeController.minuteText.text), int.Parse(timeController.hourText.text));
        }
        else if (tag == "Set Alarm Button")
        {
            timeController.SetAlarmTime(int.Parse(timeController.secondsText.text), int.Parse(timeController.minuteText.text), int.Parse(timeController.hourText.text));
        }
    }
    private void Start()
    {
        buttn.onClick.AddListener(ButtnClick);
    }

}
