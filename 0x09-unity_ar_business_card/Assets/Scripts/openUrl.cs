using UnityEngine;

public class openUrl : MonoBehaviour
{
    void Start(){}
    void Update(){}
    public void twitter()
    {
        Application.OpenURL("https://twitter.com/mateo_a");
    }

    public void github()
    {
        Application.OpenURL("https://github.com/mateo-a");
    }

    public void linkedin()
    {
        Application.OpenURL("https://www.linkedin.com/in/john-alexander-urrego/");
    }

    public void email()
    {
        Application.OpenURL("mailto:1220@holbertonschool.com");
    }
}
