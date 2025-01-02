using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoul
{
    void MoveToPoint(Vector3 point);
    void IdleMove();
    void ChangeColour(int packNumber);
    void MakeAvailable();
    void MakeUnAvailable();
    void HighlighterSwitch(bool thisBool);
    void FireSwitch(bool thisBool);
}
public abstract class Soul : MonoBehaviour, ISoul
{
    [SerializeField] protected float speed;
    [SerializeField] protected float turnSpeed;
    protected Highlighter highlighter;
    public abstract void ChangeColour(int packNumber);
    public abstract void IdleMove();
    public abstract void MoveToPoint(Vector3 point);
    public abstract Vector3 GetLocation();

    public void MakeAvailable()
    {
        SelectionManager.Instance.AddToAvailable(gameObject.GetComponent<Soul>());
    }
        
    public void MakeUnAvailable()
    {
        SelectionManager.Instance.RemoveFromAvailable(gameObject.GetComponent<Soul>());
        
    }
        
    public  void HighlighterSwitch(bool thisBool)
    {
        if (thisBool)
        {
            highlighter.gameObject.SetActive(true);
        }
        else
        {
            highlighter.gameObject.SetActive(false);
        }
    }
    public abstract void FireSwitch(bool thisBool);

}
