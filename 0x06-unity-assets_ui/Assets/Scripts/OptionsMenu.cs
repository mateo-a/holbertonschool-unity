using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///<summary>Pushing buttons of Optins scene.</summary>
public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;
    private bool invertY;

    //Awake is called when the script instance is being loaded
    void Awake()
    {
        if (PlayerPrefs.GetInt("InvertY") == 0)
        {
            invertY = true;
        }
        else
        {
            invertY = false;
        }
        invertYToggle.isOn = invertY;
    }
    ///<summary>Load the previous scene without changes.</summary>
    public void Back()
    {
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("Prev", "MainMenu"), LoadSceneMode.Single);
    }
    ///<summary>Load the previous scene with changes.</summary>
    public void Apply()
    {
        if (invertYToggle.isOn)
            PlayerPrefs.SetInt("InvertY", 0);
        else
            PlayerPrefs.SetInt("InvertY", 1);
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("Prev", "MainMenu"), LoadSceneMode.Single);
    }
}

