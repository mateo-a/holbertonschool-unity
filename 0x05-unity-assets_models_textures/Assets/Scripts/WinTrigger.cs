using UnityEngine;
using UnityEngine.UI;

///<summary>Stop timer and increase text size and change the color to green</summary>
public class WinTrigger : MonoBehaviour
{
    public Text TimerText;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.gameObject.GetComponent<Timer>().enabled = false;
            TimerText.color = Color.green;
            TimerText.fontSize = 100;
        }
    }
}