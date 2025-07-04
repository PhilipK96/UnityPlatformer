// +
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    void Start()
    {
        GetComponent<Image>().fillAmount = 0f;
    }

    void Update()
    {
        FillBar();
    }

    private void FillBar()
    {
        Image progressBar = GetComponent<Image>();

        if (progressBar.fillAmount < 1)
        {
            progressBar.fillAmount += 0.3f * Time.deltaTime;
        }
        else
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}