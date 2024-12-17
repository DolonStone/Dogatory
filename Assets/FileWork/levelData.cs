using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class levelData : MonoBehaviour
{
    private static levelData instance;
    public static levelData Instance { get { return instance; } }
    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        Initialize(starScore, completed);
    }

    private Memento state;
    [SerializeField] public int starScore = 0;
    [SerializeField] public bool completed = false;
    [SerializeField] public int numPacks;
    [SerializeField] public int numInPacks;
    

    public void Initialize(int starScore, bool completed)
    {
        state = new Memento(starScore,completed);
    }
    public string Save()
    {
        return JsonUtility.ToJson(state);
    }
    public void Load(string savedData)
    {
        state = JsonUtility.FromJson<Memento>(savedData);
        starScore = state.starScore;
        completed = state.completed;
    }

}
