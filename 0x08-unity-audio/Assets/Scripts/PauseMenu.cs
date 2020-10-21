using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public Canvas pause;
    public GameObject cc;
    private Scene current;
    public AudioMixer master;
    public AudioMixerSnapshot unpaused;
    public AudioMixerSnapshot paused;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
            {
                Resume();
            }
    }
    public void Pause()
    {
        pause.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        cc.gameObject.GetComponent<CameraController>().enabled = false;
        master.ClearFloat("BGM");
        paused.TransitionTo(0.01f);
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        cc.gameObject.GetComponent<CameraController>().enabled = true;
        pause.gameObject.SetActive(false);
        unpaused.TransitionTo(0.01f);
        master.SetFloat("BGM", Mathf.Log10(PlayerPrefs.GetFloat("bgm", 1f)) * 20);
    }
    public void Restart()
    {
        Resume();
        current = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(current.buildIndex, LoadSceneMode.Single);
    }
    public void Options()
    {
        current = SceneManager.GetActiveScene();
        PlayerPrefs.SetString("Prev", current.name);
        Resume();
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Single);
    }
    public void MainMenu()
    {
        Resume();
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
}
