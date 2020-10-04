using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cam;
    public GameObject player;
    Vector3 balance;
    private float xAxis = 0f;
    private float yAxis = 2.5f;
    public float distance = 4.0f;
    public float height = 1.0f;
    public float damping = 5.0f;
    public float rotationDamping = 10.0f;
    public float rotateSpeed = 5.0f;
    public bool isInverted;

    //Awake is called when the script instance is being loaded
    void Awake()
    {
        if (PlayerPrefs.GetInt("InvertY") == 0)
        {
            isInverted = true;
        }
        else
        {
            isInverted = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        balance = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 located;
        Quaternion turn;
        xAxis += Input.GetAxis("Mouse X");
        yAxis += Input.GetAxis("Mouse Y") * (isInverted ? 1 : -1);
        yAxis = Mathf.Clamp(yAxis, -50.0f, 50.0f);

        located = cam.TransformPoint(0, height, distance);
        transform.position = Vector3.Lerp(transform.position, located, Time.deltaTime * damping);

        turn = Quaternion.LookRotation(cam.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, turn, Time.deltaTime * rotationDamping);
    }

    // Called after all Update functions called
    private void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;

        player.transform.Rotate(0, horizontal, 0);
        float desiredAngle = player.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(yAxis, desiredAngle, 0);
        transform.position = player.transform.position - (rotation * balance);
        transform.LookAt(player.transform);
    }

}
