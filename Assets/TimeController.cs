using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;

public class TimeController : MonoBehaviour
{
    private const string URL = "https://www.timeapi.io/api/Time/current/zone?timeZone=Europe/Moscow";
    public int minute;
    public int hour;
    public int seconds;

    public Vector3 alarmTime;

    public TMP_InputField minuteText;
    public TMP_InputField hourText;
    public TMP_InputField secondsText;
    public ClockController clock;
    public void SetTime()
    {
        StartCoroutine(ProcessRequest(URL));
    }
    public void SetAlarmTime(int seconds, int minutes, int hours)
    {
        alarmTime = new Vector3(hours, minutes, seconds);
    }
    public void SetUserTime(int seconds, int minutes, int hours)
    {
        this.seconds = seconds;
        hour = hours;
        minute = minutes;
        clock.SetSeconds(seconds);
        clock.SetMinutes(seconds, minutes);
        clock.SetHours(hours, minutes);
    }
    private IEnumerator ProcessRequest(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(request.error);
            }
            else
            {
                JSONNode itemsData = JSON.Parse(request.downloadHandler.text);
                minute = (int)itemsData["minute"];
                hour = (int)itemsData["hour"];
                seconds = (int)itemsData["seconds"];
                clock.SetSeconds(seconds);
                clock.SetMinutes(seconds, minute);
                clock.SetHours(hour, minute);
                DisplayTime();
            }
        }
    }
    public void DisplayTime()
    {
        minuteText.text = minute.ToString();
        hourText.text = hour.ToString();
        secondsText.text = seconds.ToString();
    }
    private void Start()
    {
        clock = GetComponent<ClockController>();
        InvokeRepeating("SetTime", 0, 1800);
    }
    private void Update()
    {
        if (alarmTime.x == hour && alarmTime.y == minute && alarmTime.z == seconds)
        {
            Debug.Log("ALARM");
        }
    }
}