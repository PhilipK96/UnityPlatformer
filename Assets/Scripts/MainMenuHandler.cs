using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject panel;
    public GameObject joystick;
    public GameObject pauseButton;
    public GameObject jumpButton;

    private bool isPaused = false;

    void Start()
    {
        Resume();
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
        SetUIState(true);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        SetUIState(false);
    }

    private void SetUIState(bool isActive)
    {
        panel.SetActive(isActive);
        joystick.SetActive(!isActive);
        pauseButton.SetActive(!isActive);
        jumpButton.SetActive(!isActive);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Resume();
        GameObject.Find("Player").GetComponent<Player>().health.SubtractHealth(1);
    }
}
