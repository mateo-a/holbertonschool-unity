using UnityEngine;

///<summary>Enable the Timer</summary>
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