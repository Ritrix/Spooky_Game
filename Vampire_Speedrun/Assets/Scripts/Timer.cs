using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Image nightFilter;

    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerlimit;

    [Header("Format Settings")]
    public bool HasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();
    public float percentageDay;

    // Start is called before the first frame update
    void Start()
    {
        var tempColor = nightFilter.color;
        tempColor.a = 0.85f;
        nightFilter.color = tempColor;
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundrethDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        float temp = currentTime / timerlimit;
        percentageDay = 1f - temp;

        if (hasLimit && ((countDown && currentTime <= timerlimit) || (!countDown && currentTime >= timerlimit)))
        {
            currentTime = timerlimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }
        
        
        SetTimerText();

        if(percentageDay < 0.75f && percentageDay > 0.01f)
        {
            var tempColor = nightFilter.color;
            tempColor.a = percentageDay + 0.1f;
            nightFilter.color = tempColor;
        }

        if (percentageDay < 0.01f)
        {
            SceneManager.LoadScene(4);
        }
        if (globalVariables.isFinishedGame)
        {
            captureTime();
        }
    }

    private void SetTimerText()
    {
        timerText.text = HasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
    }
    
    public void captureTime()
    {
        globalVariables.finishTime = currentTime;
        SceneManager.LoadScene(5);
    }

}

public enum TimerFormats
{
    Minute,
    Whole,
    TenthDecimal,
    HundrethDecimal
}
