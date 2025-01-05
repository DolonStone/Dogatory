using System.Collections.Generic;
using System;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    
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
    public event Action<Soul> soulDestruction = delegate { };
    public void SelectSoul(Soul soul)
    {
        if (!selectedSouls.Contains(soul))
        {
            soul.HighlighterSwitch(true);
            selectedSouls.Add(soul);
            
        }
            
    }
    public void RemoveSoul(Soul soul)
    {
        soul.HighlighterSwitch(false);
        selectedSouls.Remove(soul);
        
    }
    public void RemoveAll()
    {
        while (selectedSouls.Count>0)
        {
            RemoveSoul(selectedSouls[0]);
            
        }

        //selectedSouls.Clear();
    }
    public void AddToAvailable(Soul soul)
    {
        if (!availableSouls.Contains(soul))
        {
            availableSouls.Add(soul);
            
        }
        
    }
    public void RemoveFromAvailable(Soul soul)
    {
        availableSouls.Remove(soul);
        soulDestruction.Invoke(soul);
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
