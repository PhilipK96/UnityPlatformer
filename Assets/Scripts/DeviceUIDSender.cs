// +
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DeviceUIDSender : MonoBehaviour
{
    public string ip = "localhost"; // Default IP
    public string port = "80";      // Default port

    void Start()
    {
        StartCoroutine(PostRequest());
    }

    IEnumerator PostRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("uid", SystemInfo.deviceUniqueIdentifier);

        string url = $"http://{ip}:{port}";
        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Error While Sending: {uwr.error}");
        }
        else
        {
            Debug.Log($"Received: {uwr.downloadHandler.text}");
        }
    }
}
