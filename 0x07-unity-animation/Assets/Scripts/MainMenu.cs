using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>Pushing buttons.</summary>
public class MainMenu : MonoBehaviour
{
    ///<summary>Loads the corresponding scene.</summary>
    public void LevelSelect(int level)
    {
        if (level == 1)
            SceneManager.LoadSceneAsync("Level01", LoadSceneMode.Single);
        if (level == 2)
            SceneManager.LoadSceneAsync("Level02", LoadSceneMode.Single);
        if (level == 3)
            SceneManager.LoadSceneAsync("Level03", LoadSceneMode.Single);
    }
    ///<summary>Loads the Options scene.</summary>
    public void Options()
    {
        PlayerPrefs.SetString("Prev", SceneManager.GetActiveScene().name);
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Single);
    }
    ///<summary>Close the game and Exited is printed to the console.</summary>
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
