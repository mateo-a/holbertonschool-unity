using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        string seconds = (time % 60).ToString("00.00");
        string minutes = Mathf.Floor((time % 3600) / 60).ToString();
        TimerText.text = minutes + ":" + seconds;
    }
}