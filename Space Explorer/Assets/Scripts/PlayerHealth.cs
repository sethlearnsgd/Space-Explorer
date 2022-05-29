using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameOverHandler gameOverHandler;
    [SerializeField] private GameObject pauseMenu;
    public void Crash()
    {
        pauseMenu.SetActive(false);
        gameObject.SetActive(false);
        gameOverHandler.EndGame();
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        pauseMenu.SetActive(true);
    }
}
