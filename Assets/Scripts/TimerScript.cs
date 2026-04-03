using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI TimeIsUpText;
    float timeAvailable = 60f;
    bool timerRunning = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimeIsUpText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            timeAvailable -= Time.deltaTime;
            TimerText.text = FormatTime(timeAvailable);
        }

        if (timeAvailable <= 0)
        {
            timerRunning = false;
            TimeIsUp();
        }
    }
    string FormatTime(float time)
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        int milliseconds = (int)((time % 1) * 100);
        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }

    public void TimeIsUp()
    {
        TimeIsUpText.text = "Time Is Up";
    }

    public void PauseTimeToggle(bool toggle)
    {
        if (toggle)
            timerRunning = false;
        else if (toggle == false)
            timerRunning = true;
    }

}
