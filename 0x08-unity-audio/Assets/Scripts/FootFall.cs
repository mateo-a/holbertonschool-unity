using UnityEngine;

public class FootFall : MonoBehaviour
{
    public AudioClip grassStepSFX;
    public AudioClip rockStepSFX;
    public AudioClip grassPlantSFX;
    public AudioClip rockPlantSFX;
    public GameObject player;
    private string surface;

    public void FootstepSFX()
    {
        bool grounded = player.GetComponent<PlayerController>().onGround();
        print(grounded);
        if (grounded)
        {
            if (player.GetComponent<PlayerController>().surfaceType() == "Stone")
                GetComponent<AudioSource>().PlayOneShot(rockStepSFX);
            else
                GetComponent<AudioSource>().PlayOneShot(grassStepSFX);
        }
    }

    public void FaceplantSFX()
    {
        if (player.GetComponent<PlayerController>().surfaceType() == "Stone")
            GetComponent<AudioSource>().PlayOneShot(rockPlantSFX);
        else
            GetComponent<AudioSource>().PlayOneShot(grassPlantSFX);
    }
}
