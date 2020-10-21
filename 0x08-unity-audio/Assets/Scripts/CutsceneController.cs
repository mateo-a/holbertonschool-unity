using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    Animator anim;
    public GameObject mainCamera;
    public GameObject player;
    public GameObject timerCanvas;
    public GameObject cutCamera;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void transition()
    {
        mainCamera.SetActive(true);
        timerCanvas.SetActive(true);
        player.gameObject.GetComponent<PlayerController>().enabled = true;
        cutCamera.SetActive(false);
    }
}
