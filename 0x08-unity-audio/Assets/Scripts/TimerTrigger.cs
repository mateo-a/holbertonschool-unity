using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            other.gameObject.GetComponent<Timer>().enabled = true;
        }
    }
}
