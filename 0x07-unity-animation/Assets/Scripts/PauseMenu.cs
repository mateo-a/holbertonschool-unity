using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>Es-ca-pé.</summary>
public class PauseMenu : MonoBehaviour
{
    public Canvas pause;
    public GameObject cameraController;
    private Scene current;

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
            {
                Resume();
            }
    }
    ///<summary>Pause and show PauseCanvas.</summary>
    public void Pause()
    {
        pause.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        cameraController.gameObject.GetComponent<CameraController>().enabled = false;
    }
    ///<summary>Resume the game where the player left off.</summary>
    public void Resume()
    {
        Time.timeScale = 1.0f;
        cameraController.gameObject.GetComponent<CameraController>().enabled = true;
        pause.gameObject.SetActive(false);
    }
    ///<summary>Reloads the level scene that the player is currently on.</summary>
    public void Restart()
    {
        Resume();
        current = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(current.buildIndex, LoadSceneMode.Single);
    }
    ///<summary>Load the MainMenu scene.</summary>
    public void MainMenu()
    {
        Resume();
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
    ///<summary>Load the Options scene.</summary>
    public void Options()
    {
        current = SceneManager.GetActiveScene();
        PlayerPrefs.SetString("Prev", current.name);
        Resume();
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Single);
    }

}
