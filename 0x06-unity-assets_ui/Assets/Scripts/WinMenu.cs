using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>Handles Win Menu UI.</summary>
public class WinMenu : MonoBehaviour
{
    public GameObject cc;
    private Scene current;

    ///<summary>Return to main menu.</summary>
    public void MainMenu()
    {
        cc.gameObject.GetComponent<CameraController>().enabled = true;
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
    ///<summary>Next stage.</summary>
    public void Next()
    {
        cc.gameObject.GetComponent<CameraController>().enabled = true;
        current = SceneManager.GetActiveScene();
        if (current.name != "Level03")
            SceneManager.LoadSceneAsync(current.buildIndex + 1, LoadSceneMode.Single);
        else
            SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
}
