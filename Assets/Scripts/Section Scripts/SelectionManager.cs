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
    public int selectedPack = 0;
    
    public void SelectSoul(Soul soul)
    {
        if (!selectedSouls.Contains(soul))
        {
            selectedSouls.Add(soul);
        }
            
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
        if (!availableSouls.Contains(soul))
        {
            availableSouls.Add(soul);
        }
        
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
