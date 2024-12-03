using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private static readonly object padlock = new object();
    private static SelectionManager instance;
    
    public static SelectionManager Instance {  get { return instance; } }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        availableSouls = new HashSet<Soul>();
        selectedSouls = new List<Soul>();
    }
    [SerializeField] private HashSet<Soul> availableSouls;
    
    [SerializeField] private List<Soul> selectedSouls;
    
    public void SelectSoul(Soul soul)
    {
        selectedSouls.Add(soul);
    }
    public void RemoveSoul(Soul soul)
    {
        selectedSouls.Remove(soul);
    }
    public void RemoveAll()
    {
        selectedSouls.Clear();
    }
    public void AddToAvailable(Soul soul)
    {
        availableSouls.Add(soul);
        Debug.Log(availableSouls.Count);
    }
    public HashSet<Soul> GetAvailableSouls()
    {
        return availableSouls;
    }
    public List<Soul> GetSelectedSouls()
    {
        return selectedSouls;
    }
}
