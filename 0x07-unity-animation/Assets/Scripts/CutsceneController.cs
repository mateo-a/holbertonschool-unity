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
        cutCamera.SetActive(false);
        timerCanvas.SetActive(true);
        player.gameObject.GetComponent<PlayerController>().enabled = true;
        
    }
}
