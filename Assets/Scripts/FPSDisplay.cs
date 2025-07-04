// +
using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    private TextMeshProUGUI fpsText;
    private const float POLLING_INTERVAL = 1f;
    private int frameCount;
    private float elapsedTime;

    void Start()
    {
        fpsText = GetComponent<TextMeshProUGUI>();
        Application.targetFrameRate = 120;
    }

    void Update()
    {
        IncrementFrameCounter();

        if (elapsedTime >= POLLING_INTERVAL)
        {
            DisplayFPS();
            ResetFrameCount();
        }
    }

    private void IncrementFrameCounter()
    {
        elapsedTime += Time.deltaTime;
        frameCount++;
    }

    private void DisplayFPS()
    {
        int averageFps = Mathf.RoundToInt(frameCount / elapsedTime);
        fpsText.text = $"{averageFps}к/с";
    }

    private void ResetFrameCount()
    {
        elapsedTime -= POLLING_INTERVAL;
        frameCount = 0;
    }
}
