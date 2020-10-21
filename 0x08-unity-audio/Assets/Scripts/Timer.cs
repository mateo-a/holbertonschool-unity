using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private int min = 0;
    private float sec = 0.00f;
    private float thyme = 0f;
    private string text;
    public Canvas winCanvas;
    public Text winTime;
    public GameObject cc;
    public AudioSource bgm;
    public AudioSource sting;

    void Update()
    {
        thyme += Time.deltaTime;
        min = (int)(thyme / 60);
        sec = (thyme % 60f);
        text = min.ToString() + ":" + sec.ToString("00.00");
        timerText.text = text;
    }
    public void Win()
    {
        cc.gameObject.GetComponent<CameraController>().enabled = false;
        winTime.text = timerText.text;
        timerText.enabled = false;
        winCanvas.gameObject.SetActive(true);
        bgm.Stop();
        sting.Play();
    }
}
