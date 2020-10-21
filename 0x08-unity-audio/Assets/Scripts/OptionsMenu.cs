using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle why;
    private bool invertY;
    public AudioMixer master;
    private float bgm;
    private float sfx;
    private float bgmStore;
    private float sfxStore;
    public Slider BGMSlider;
    public Slider SFXSlider;

    void Awake()
    {
        if (PlayerPrefs.GetInt("Y", 0) == 0)
            invertY = false;
        else
            invertY = true;
        bgm = PlayerPrefs.GetFloat("bgm", 1f);
        bgmStore = bgm;
        sfx = PlayerPrefs.GetFloat("sfx", 1f);
        sfxStore = sfx;
        BGMSlider.value = bgm;
        SFXSlider.value = sfx;
        why.isOn = invertY;
    }

    public void Back()
    {
        master.SetFloat("SFX", Mathf.Log10(sfxStore) * 20);
        master.SetFloat("BGM", Mathf.Log10(bgmStore) * 20);
        PlayerPrefs.SetFloat("bgm", bgmStore);
        PlayerPrefs.SetFloat("sfx", sfxStore);
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("Prev", "MainMenu"), LoadSceneMode.Single);
    }
    public void Apply()
    {
        if (why.isOn)
            PlayerPrefs.SetInt("Y", 1);
        else
            PlayerPrefs.SetInt("Y", 0);
        PlayerPrefs.SetFloat("bgm", bgm);
        PlayerPrefs.SetFloat("sfx", sfx);
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("Prev", "MainMenu"), LoadSceneMode.Single);
    }

    public void SetSFXLevel()
    {
        sfx = SFXSlider.value;
        master.SetFloat("SFX", Mathf.Log10(sfx) * 20);
    }

    public void SetBGMLevel()
    {
        bgm = BGMSlider.value;
        master.SetFloat("BGM", Mathf.Log10(bgm) * 20);
    }
}
