using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class LevelDirector : MonoBehaviour, IObserver
{
    
    public int levelNum;
    private IObservable player;
    private IObservable spark;
    private IObservable door;
    private bool canFade = false;
    private string whichObservable;
    private float t;
    private GameObject toBlackFader;

    public void Start()
    {
        InitializeObservables();
        AttachObservers();
        toBlackFader = GameObject.Find("Fader");
    }

    public void Update()
    {
        if (canFade)
        {
            toBlackFader.GetComponent<RawImage>().color = new Color(0, 0, 0, t);
            t += Time.deltaTime;
            if (t > 1)
            {
                switch (whichObservable)
                {
                    case "HealthController":
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                        break;
                    case "LevelEndDoor":
                        LoadNextLevel(); 
                        break;
                }
                t = 0;
            }
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        OpenNextLevelAndRewriteToPersistentDataPath(levelNum + 1);
    }

    void FadeScreen(){
        canFade = true;
    }

    private void InitializeObservables()
    {
        player = GameObject.Find("Player").GetComponent<Player>().health;
        spark = GameObject.Find("Spark").GetComponent<FinalDoorOpener>();
        door = GameObject.Find("Level_end").GetComponent<LevelEndDoor>();
    }

    private void AttachObservers()
    {
        player.Attach(this);
        spark.Attach(this);
        door.Attach(this);
    }

    public void OpenNextLevelAndRewriteToPersistentDataPath(int num)
    {
        string json = File.ReadAllText(Path.Combine(Application.persistentDataPath, "Levels.json"));
        Levels levels = JsonUtility.FromJson<Levels>(json);
        levels.levels[num-1].open = true;
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "Levels.json"), JsonUtility.ToJson(levels, true));
    }


    public void OnNotification(IObservable observable)
    { 
        if (observable.GetType() == typeof(HealthController))
        {
            if ((observable as HealthController).GetHealth() <= 0)
            {
                whichObservable = "HealthController";
                FadeScreen();
            }
        }


        if (observable is FinalDoorOpener)
        {
            GameObject.Find("Level_end").GetComponent<LevelEndDoor>().allowDoorOpening(); 
        }

        if (observable is LevelEndDoor)
        {
            whichObservable = "LevelEndDoor";
            GameObject.Find("Player").GetComponent<Player>().enabled = false; 
            FadeScreen();
        }
    }
}