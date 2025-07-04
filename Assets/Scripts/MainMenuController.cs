// +
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "Levels.json");
        if (!File.Exists(path))
        {
            TextAsset textAsset = Resources.Load<TextAsset>("Levels"); 
            File.WriteAllText(path, textAsset.text); 
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level" + (FindLastOpenedLevel()+1).ToString());
    }

    public void ChooseLevel()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private int FindLastOpenedLevel()
    {
        string json = File.ReadAllText(Path.Combine(Application.persistentDataPath, "Levels.json"));

        int i = 0;
        foreach (level level in JsonUtility.FromJson<Levels>(json).levels)
        {
            i++;
            if (level.open == false) 
            {
                return i-2;
            }
        }
        return 1;
    }
}