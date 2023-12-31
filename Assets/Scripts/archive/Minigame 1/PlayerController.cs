using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameWinText;

    private GameManager gameManager;
    public float movementSpeed = 5.0f;
    private float timeRemain = 20f;
    private bool gameEnded = false;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the player horizontally
        transform.Translate(Vector3.right * horizontalInput * movementSpeed * Time.deltaTime);
        timeRemain -= Time.deltaTime;
        // Check for win condition (example: reaching a certain position)
        if (timeRemain <= 0) // Example condition
        {
            WinGame1();
        }
        //if (gameEnded = true)
        //{
        // return;
        //}

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check for collision with an obstacle
        if (collision.gameObject.CompareTag("M1"))
        {
            // Destroy the player and the obstacle
            Destroy(collision.gameObject);
            Destroy(gameObject);

            // Trigger lose condition
            LoseGame1();
        }
    }


    void LoseGame1()
    {

        Debug.Log("destected--------------");
        //StopAllCoroutines();
        Debug.Log("destected-------------1");
        //gameEnded = true;
        Debug.Log("destected-------------1");
        // For now, we'll just reload the navigation scene
        GameManager.mini1Win = false;
        gameOverText.enabled = true;
        Debug.Log("destected-------------2");
        SceneManager.LoadScene("Navigation");
        Debug.Log("MiniGame 1 lose");

    }

    void WinGame1()
    {
        gameEnded = true;
        GameManager.mini1Win = true;
        gameOverText.enabled = true;
        //SceneManager.LoadScene("Navigation");
        Debug.Log("MiniGame 1 Win");
    }
}
