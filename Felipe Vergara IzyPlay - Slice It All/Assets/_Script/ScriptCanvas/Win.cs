using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [Header("Variaveis do HUD")]
    public GameObject winCanvas;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))//para o jogo se ganhar
        {
            Time.timeScale = 0;
            winCanvas.SetActive(true);
        }
    }

    public void ResetLevel()//reseta a fase
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}