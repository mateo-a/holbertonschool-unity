using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///<summary>Handles Options Menu UI.</summary>
public class OptionsMenu : MonoBehaviour
{
    public Toggle why;
    private bool invertY;

    //Awake
    void Awake()
    {
        if (PlayerPrefs.GetInt("Y", 0) == 0)
            invertY = false;
        else
            invertY = true;
        why.isOn = invertY;
    }
    ///<summary>Returns without applying changes.</summary>
    public void Back()
    {
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("Prev", "MainMenu"), LoadSceneMode.Single);
    }
    ///<summary>Returns applying changes.</summary>
    public void Apply()
    {
        if (why.isOn)
            PlayerPrefs.SetInt("Y", 1);
        else
            PlayerPrefs.SetInt("Y", 0);
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("Prev", "MainMenu"), LoadSceneMode.Single);
    }
}
