using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class levelData : MonoBehaviour
{
    private static levelData instance;
    public static levelData Instance { get { return instance; } }
    private void Start()
    {
        Load(0);
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        
    }

    private AllLevelData state;
    public int starScore = 0;
    public bool completed = false;
    public int numPacks;
    public int numInPacks;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private TextAsset levelDataTextFile;


    public void Save()
    {
        File.WriteAllText(Application.dataPath+ "/FileWork/TextLevelData.txt",JsonUtility.ToJson(state));
    }
    public void Load(int level) //loads the level data from inputted level
    {
        
        state = JsonUtility.FromJson<AllLevelData>(levelDataTextFile.text);
        starScore = state.LevelDataList[level].starScore;
        completed = state.LevelDataList[level].completed;
        numPacks = state.LevelDataList[level].numPacks;
        numInPacks = state.LevelDataList[level].numInPacks;
    }
    public void OpenCloseMenu()
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }
    public void LoadLevel(int level)
    {

        Load(level);
        menu.SetActive(false);
        SceneManager.LoadScene(level);

    }
    
}
