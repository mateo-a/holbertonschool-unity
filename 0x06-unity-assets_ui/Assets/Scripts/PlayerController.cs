using UnityEngine;

///<summary>Player Controller</summary>
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction = Vector3.zero;
    private Transform point;
    public Transform charCam;
    public float speed = 10f;
    public float jump = 15f;
    private float elevation;
    public Canvas pause;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        point = GetComponent<Transform>();
    }

    void Update()
    {
        elevation = direction.y;
        direction = Vector3.zero;
        if (Input.GetKey("w"))
            direction = Vector3.forward + direction;
        if (Input.GetKey("s"))
            direction = Vector3.back + direction;
        if (Input.GetKey("d"))
            direction = Vector3.right + direction;
        if (Input.GetKey("a"))
            direction = Vector3.left + direction;
        direction = ((charCam.right * direction.x) + (charCam.forward * direction.z)) * speed;
        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
                elevation = jump;
            else
                elevation = 0;
        }
        direction.y = elevation;
        direction.y = direction.y - (20 * Time.deltaTime);
        if (point.position.y < -20.0f)
            direction = Vector3.zero;
        controller.Move(direction * Time.deltaTime);
        if (point.position.y < -20.0f)
            point.position = new Vector3(0, 10, 0);
        if (Input.GetKey("escape"))
            //Application.Quit();
            pause.GetComponent<PauseMenu>().Pause();
    }
}
