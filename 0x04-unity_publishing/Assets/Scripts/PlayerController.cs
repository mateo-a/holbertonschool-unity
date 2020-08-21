using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///<summary>Player Controller</summary>
public class PlayerController : MonoBehaviour
{
    public GameObject winlose;
    public Image winLoseBG;
    public Text winLoseText;
    public Text scoreText;
    public Text healthText;
    public float speed = 2500f;
    private int score = 0;
    public int health = 5;
    // Reference to the Rigidbody component called rb
    public Rigidbody rb;
    // Market as "Fixed"Update because we are
    // using it to mess with physics
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {   // Add forward force (float x, float y, float z, ForceMode mode = ForceMode.Force "Type of force to apply"))
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            // Debug.Log($"Score: {score}");
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health--;
            // Debug.Log($"Health: {health}");
            SetHealthText();
        }
        if (other.tag == "Goal")
        {
            // Debug.Log("You win!");
            winlose.SetActive(true);
            winLoseBG.color = Color.green;
            winLoseText.color = Color.black;
            winLoseText.text = "You win!";
            StartCoroutine(LoadScene(3));
        }
    }

    void Update()
    {
        if (health == 0)
        {
            // Debug.Log("Game Over!");
            winlose.SetActive(true);
            winLoseBG.color = Color.red;
            winLoseText.color = Color.white;
            winLoseText.text = "Game Over!";
            StartCoroutine(LoadScene(3));
            health = 5;
            score = 0;
        }
        
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu", LoadSceneMode.Single);
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("maze", LoadSceneMode.Single);
    }
}
