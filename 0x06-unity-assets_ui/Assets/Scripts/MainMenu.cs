using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>Handles Main Menu UI.</summary>
public class MainMenu : MonoBehaviour
{
    ///<summary>Handles level selection UI.</summary>
    public void LevelSelect(int level)
    {
        if (level == 1)
            SceneManager.LoadSceneAsync("Level01", LoadSceneMode.Single);
        if (level == 2)
            SceneManager.LoadSceneAsync("Level02", LoadSceneMode.Single);
        if (level == 3)
            SceneManager.LoadSceneAsync("Level03", LoadSceneMode.Single);
    }
    ///<summary>Handles game options UI.</summary>
    public void Options()
    {
        PlayerPrefs.SetString("Prev", SceneManager.GetActiveScene().name);
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Single);
    }
    ///<summary>Handles game exit UI.</summary>
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
