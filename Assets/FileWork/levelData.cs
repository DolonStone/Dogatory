using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class levelData : MonoBehaviour
{
    private Memento state;
    [SerializeField] private int starScore = 0;
    [SerializeField] private bool completed = false;
    

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
    private void Start()
    {
        Initialize(starScore, completed);
    }
}
