// +
using UnityEngine;
using TMPro;

public class LevelLoadButton : MonoBehaviour

{
    public int LevelNum;
    private LevelMenuDirector lvdir;
    private Levels lvlist;

    private void Start()
    {
        lvdir = GameObject.Find("LevelMenuDirector").GetComponent<LevelMenuDirector>();
        lvlist = lvdir.GetLevelList();

        if (lvlist.levels[LevelNum-1].open == false)
        {
            GameObject.Find("Text" + LevelNum.ToString()).GetComponent<TextMeshProUGUI>().color = new Color(0.5f, 0.5f, 0.5f);
        } 
    }

    public void LoadLevel()
    {
        
        if (lvlist.levels[LevelNum - 1].open)
        {
            GameObject.Find("LevelMenuDirector").GetComponent<LevelMenuDirector>().LoadLevel(LevelNum);
        }
    }
}