using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalTimeDisplay : MonoBehaviour
{
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundrethDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = globalVariables.finishTime.ToString(timeFormats[TimerFormats.HundrethDecimal]);
    }

    public enum TimerFormats
    {
        Minute,
        Whole,
        TenthDecimal,
        HundrethDecimal
    }
}
