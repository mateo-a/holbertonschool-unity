using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float turn = 3f;
    public Transform player;
    private Transform tsf;
    private Vector3 offset;
    private Quaternion turnX;
    private Quaternion turnY;
    public bool isInverted;

    void Awake()
    {
        if (PlayerPrefs.GetInt("Y", 0) == 0)
            isInverted = false;
        else
            isInverted = true;
        tsf = GetComponent<Transform>();
    }

    void Start()
    {   
        offset = new Vector3(0, 1.25f, -6.25f);
    }

    void LateUpdate()
    {
        turnX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turn, Vector3.up);
        if (isInverted == true)
        {
            turnY = Quaternion.AngleAxis(-1 * (Input.GetAxis("Mouse Y") * turn), Vector3.left);
        }
        else
        {
            turnY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turn, Vector3.left);
        }
        offset = turnX * turnY * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position + new Vector3(0, 0.24f, 0));
    }
}
