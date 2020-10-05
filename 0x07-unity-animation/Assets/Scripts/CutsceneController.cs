using UnityEngine;
using System.Collections;
public class CutsceneController : MonoBehaviour
{
    private Animator intro01;
    public GameObject[] sceneStart;
    void Start()
    {
        intro01 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (intro01.GetCurrentAnimatorStateInfo(0).IsName("Intro01") && intro01.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            StartCoroutine(transitions());
        }
    }

    IEnumerator transitions()
    {
        foreach (GameObject go in sceneStart)
        {
            if (go.activeInHierarchy == false)
            {
                go.SetActive(true);
            }
            if (go.GetComponent<PlayerController>() != null)
            {
                go.GetComponent<PlayerController>().enabled = true;
            }
            else
            {
                continue;
            }
        }
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
    }
}
