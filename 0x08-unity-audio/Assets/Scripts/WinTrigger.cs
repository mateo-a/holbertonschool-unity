using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    private bool won = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && won == false)
        {
            won = true;
            other.gameObject.GetComponent<Timer>().Win();
        }
    }
}
