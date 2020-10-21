using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject cc;
    private Scene current;

    public void MainMenu()
    {
        cc.gameObject.GetComponent<CameraController>().enabled = true;
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
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
