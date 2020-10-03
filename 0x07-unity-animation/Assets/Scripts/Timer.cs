using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    float time;
    public Canvas winCanvas;
    public Text finalTime;
    public GameObject camController;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        string seconds = (time % 60).ToString("00.00");
        string minutes = Mathf.Floor((time % 3600) / 60).ToString();
        TimerText.text = minutes + ":" + seconds;
    }
    /// <summary>Displays player’s finish time in FinalTime in WinCanvas</summary>
    public void Win()
    {
        TimerText.enabled = false;
        finalTime.text = TimerText.text;
        camController.GetComponent<CameraController>().enabled = false;
        winCanvas.gameObject.SetActive(true);
    }
}