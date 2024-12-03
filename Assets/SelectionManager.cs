
using System.Collections.Generic;

public class SelectionManager 
{
    private static readonly object padlock = new object();
    private static SelectionManager instance = null;
    private SelectionManager() { }
    public static SelectionManager Instance
    {
        get
        {
            lock (padlock)
            {
                if(instance == null)
                {
                    instance = new SelectionManager();
                }
                return instance;
            }
        }
    }


    public static HashSet<Soul> availableSouls;
    public static List<Soul> selectedSouls;
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
    }
}
