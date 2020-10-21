using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer master;

    void Start()
    {
        master.SetFloat("BGM", Mathf.Log10(PlayerPrefs.GetFloat("bgm", 1f)) * 20);
        master.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("sfx", 1f)) * 20);
    }

    public void LevelSelect(int level)
    {
        if (level == 1)
            SceneManager.LoadSceneAsync("Level01", LoadSceneMode.Single);
        if (level == 2)
            SceneManager.LoadSceneAsync("Level02", LoadSceneMode.Single);
        if (level == 3)
            SceneManager.LoadSceneAsync("Level03", LoadSceneMode.Single);
    }
    public void Options()
    {
        PlayerPrefs.SetString("Prev", SceneManager.GetActiveScene().name);
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Single);
    }
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
