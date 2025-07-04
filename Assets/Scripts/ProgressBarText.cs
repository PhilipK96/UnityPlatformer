// +
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ProgressBarText : MonoBehaviour
{
    private TextMeshProUGUI MainMenuText;
    private Light2D LightSource;

    void Start()
    {
        MainMenuText = GetComponent<TextMeshProUGUI>();
        LightSource = GameObject.Find("BarEnd").GetComponent<Light2D>();
    }

    void Update()
    {

        MoveLightSource();
        if (GetFillAmount() > 0 & GetFillAmount() < 0.3) {
            MainMenuText.text = "World Loading ...";
        }

        if (GetFillAmount() > 0.31 & GetFillAmount() < 0.6)
        {
            MainMenuText.text = "Assets Loading ...";
        }

        if (GetFillAmount() > 0.61)
        {
            MainMenuText.text = "Loading ...";
        }

    }

    private float GetFillAmount()
    {
        return GameObject.Find("ProgressBar").GetComponent<Image>().fillAmount;
    }

    private void MoveLightSource()
    {
        LightSource.transform.localPosition = new Vector3(GetFillAmount()*100,0,0);
    }
}