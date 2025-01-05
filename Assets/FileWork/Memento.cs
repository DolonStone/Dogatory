
using System;

[Serializable]
public class Memento
{
    public int starScore;
    public bool completed;
    public int numPacks;
    public int numInPacks;
    public Memento(int starScore, bool completed,int numPacks, int numInPacks)
    {
        this.starScore = starScore;
        this.completed = completed;
        this.numPacks = numPacks;
        this.numInPacks = numInPacks;
    }
}
