using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoul
{
    void MoveToPoint(Vector3 point);
    void IdleMove();
    void ChangeColour(int packNumber);
    void MakeAvailable();
}
public abstract class Soul : MonoBehaviour, ISoul
{
    [SerializeField] protected float speed;
    [SerializeField] protected float turnSpeed;
    public abstract void ChangeColour(int packNumber);
    public abstract void IdleMove();
    public abstract void MoveToPoint(Vector3 point);
    public abstract Vector3 GetLocation();

    public abstract void MakeAvailable();
}
