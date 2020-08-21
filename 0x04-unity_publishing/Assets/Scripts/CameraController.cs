using UnityEngine;

public class CameraController : MonoBehaviour
{
    // public Transform player;
    public GameObject player;
    public Vector3 offset;

    void Start()
    {
        player = GameObject.Find("Player");
        offset = new Vector3(0, -30, 10);
    }
    // Update is called once per frame
    void Update()
    {
         transform.position = player.transform.position - offset;
         transform.eulerAngles = new Vector3(80, 0, 0);
    }
}
