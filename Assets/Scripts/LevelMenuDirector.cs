// +
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelMenuDirector : MonoBehaviour
{

    private Levels levelsList;

    private void Start() {
        SaveFromResourcesToPersistentDataPath();
        ReadFromPersistentDataPath();
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level.ToString());
    }

    public Levels GetLevelList()
    {
        ReadFromPersistentDataPath();
        return levelsList;
    }
    public void ReadFromPersistentDataPath() 
    {
        string json = File.ReadAllText(Path.Combine(Application.persistentDataPath, "Levels.json"));
        levelsList = JsonUtility.FromJson<Levels>(json); 
    }


    public void SaveFromResourcesToPersistentDataPath()
    {
        string path = Path.Combine(Application.persistentDataPath, "Levels.json");
        //File.Delete(path);
        if (!File.Exists(path))
        {
            TextAsset textAsset = Resources.Load<TextAsset>("Levels"); 
            File.WriteAllText(path, textAsset.text); 
        }
    }
}