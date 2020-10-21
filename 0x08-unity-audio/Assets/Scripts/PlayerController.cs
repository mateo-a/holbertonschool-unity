using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController pc;
    private Transform p2;
    public Transform cam;
    private Vector3 moveYou = Vector3.zero;
    private Vector3 faceYou = Vector3.zero;
    private Quaternion faceRot;
    public float speed = 10f;
    public float jump = 13f;
    private float vert;
    public Canvas pause;
    private Transform ty;
    private Animator anim;
    private float fall = 0f;
    private string surface;

    void Awake()
    {
        pc = GetComponent<CharacterController>();
        p2 = GetComponent<Transform>();
        ty = p2.Find("ty");
        anim = ty.GetComponent<Animator>();
    }
    void OnCollisionStay(Collision other)
    {
        if (other.collider.tag == "Stone")
            surface = "Stone";
        else
            surface = "Grass";
    }

    void Update()
    {
        vert = moveYou.y;
        moveYou = Vector3.zero;
        if (Input.GetKey("w"))
            moveYou = Vector3.forward + moveYou;
        if (Input.GetKey("s"))
            moveYou = Vector3.back + moveYou;
        if (Input.GetKey("d"))
            moveYou = Vector3.right + moveYou;
        if (Input.GetKey("a"))
            moveYou = Vector3.left + moveYou;
        moveYou = ((cam.right * moveYou.x) + (cam.forward * moveYou.z)) * speed;
        if (pc.isGrounded)
        {
            fall = 0;
            anim.SetBool("Grounded", true);
            if (Input.GetKeyDown("space"))
            {
                vert = jump;
                anim.SetTrigger("Jump");
            }
            else
            {
                vert = 0;
            }
        }
        else
        {
            fall += Time.deltaTime;
            anim.SetBool("Grounded", false);
            surface = "";
        }
        if (moveYou != Vector3.zero)
        {
            faceYou = new Vector3(moveYou.x, 0, moveYou.z);
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
        moveYou.y = vert;
        moveYou.y = moveYou.y - (20 * Time.deltaTime);
        pc.Move(new Vector3(moveYou.x, moveYou.y, moveYou.z) * Time.deltaTime);
        if (moveYou != Vector3.zero)
        {
            faceRot = Quaternion.LookRotation(faceYou);
            ty.rotation = faceRot;
        }
        anim.SetFloat("Fall", fall);
        if (p2.position.y < -50.0f)
            p2.position = new Vector3(0, 10, 0);
        if (Input.GetKeyDown("escape"))
        {
            pause.GetComponent<PauseMenu>().Pause();
        }
    }

    public string surfaceType()
    {
        return surface;
    }

    public bool onGround()
    {
        return pc.isGrounded;
    }
}
