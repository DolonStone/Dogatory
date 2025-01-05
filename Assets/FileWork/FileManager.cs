using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    [SerializeField] private levelData[] levels;
    
    public void SaveLevelStates()
    {
        string[] levelStates = new string[levels.Length];

        for (int i = 0; i < levels.Length; i++)
        {
            //Debug.Log(levels[i].Save());
            //levelStates[i] = levels[i].Save();
            
        }
        
        File.WriteAllLines("LevelSave.txt", levelStates);    
    }
    private void Start()
    {
        SaveLevelStates();
    }
    public void LoadLevelStates() 
    { 

    }
}
