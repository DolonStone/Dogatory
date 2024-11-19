
using System;

[Serializable]
public class Memento
{
    public int starScore;
    public bool completed;
    public Memento(int starScore, bool completed)
    {
        this.starScore = starScore;
        this.completed = completed;
    }
}
