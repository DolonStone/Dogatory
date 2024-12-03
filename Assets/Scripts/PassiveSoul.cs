using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSoul : Soul
{

    public override void ChangeColour(Color newColour)
    {
        throw new System.NotImplementedException();
    }

    public override Vector3 GetLocation()
    {
        return gameObject.transform.position;
    }

    public override void IdleMove()
    {
        throw new System.NotImplementedException();
    }

    public override void MoveToPoint(Vector3 point)
    {
        
        Vector2 vectorToTarget = (point - transform.position);
        float angleToTarget = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg; 
        Quaternion rotationToTarget = Quaternion.AngleAxis(angleToTarget, Vector3.forward); //Calculates the rotation needed to make the object face the point
        float roundedAngle = Mathf.Round(angleToTarget / 10) * 10;//rounds the rotation
        if (roundedAngle < 0) { roundedAngle += 360; }//translates to quaternion

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, Time.deltaTime * turnSpeed); //breaks the rotation into a series of steps to make it smoother
        if (Mathf.Round(transform.rotation.eulerAngles.z / 10) * 10 == roundedAngle) //Compares the rounded current roation to the rounded requiered roatation so the object can start moving towards the point when it is "near enough" to facing the point
        {
            transform.position += speed * Time.deltaTime * transform.right; //Moves the object forwards
        }
        
    }
    private void Awake()
    {
        MakeAvailable();
    }
    public override void MakeAvailable()
    {
        SelectionManager.Instance.AddToAvailable(this);
    }
}
