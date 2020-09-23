using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>Handles Win Menu UI.</summary>
public class WinMenu : MonoBehaviour
{
    public GameObject camController;
    private Scene currentScene;

    ///<summary>Takes the player to the MainMenu Scene..</summary>
    public void MainMenu()
    {
        camController.gameObject.GetComponent<CameraController>().enabled = true;
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
    ///<summary>Loads the next level</summary>
    public void Next()
    {
        camController.gameObject.GetComponent<CameraController>().enabled = true;
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Level03")
            SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        else
            SceneManager.LoadSceneAsync(currentScene.buildIndex + 1, LoadSceneMode.Single);
    }
}
