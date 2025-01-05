using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PassiveSoul : Soul
{

    [SerializeField]
    private GameObject fire;
    private bool idleSwitch;
    private Quaternion idleRotation;
    private float idleLerpPercent = 0f;
    [SerializeField]
    private bool idleSwitch2 = false;
    [SerializeField]
    private float idleMoveCounter = 0f;
    private float idleMoveTimer = 0f;
    
    public override void ChangeColour(int packNumber)
    {
        FireSwitch(true);
        fire.GetComponent<Orienter>().ChangeColour(packNumber);
    }
    public override void FireSwitch(bool thisBool)
    {
        
        fire.SetActive(thisBool);
    }
    public override Vector3 GetLocation()
    {
        return gameObject.transform.position;
    }
    public void IdleRotate()
    {

        if (!idleSwitch)
        {
            idleMoveTimer -= Time.deltaTime; // Decrease timer.

            if (idleMoveTimer <= 0f)
            {
                idleRotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
                idleMoveTimer = Random.Range(0.5f, 10f); // Reset timer with random delay.
                idleSwitch = true;
            }
        }
        else
        {
            idleLerpPercent = Mathf.MoveTowards(idleLerpPercent, 1f, Time.deltaTime * 0.25f);
            transform.rotation = Quaternion.Slerp(transform.rotation, idleRotation, idleLerpPercent);
            if (idleLerpPercent >= 1f)
            {
                transform.position += speed * Time.deltaTime * transform.right;
                idleSwitch = false;
                idleLerpPercent = 0f;
            }

        }
        
        
    }
    public override void IdleMove()
    {
        if (!idleSwitch2)
        {
            idleMoveTimer -= Time.deltaTime; // Decrease timer.

            if (idleMoveTimer <= 0f)
            {
                idleMoveTimer = Random.Range(0.5f, 10f); // Reset timer with random delay.
                idleSwitch2 = true;
            }
        }
        else
        {
            transform.position += 0.5f * Time.deltaTime * transform.right;
            idleMoveCounter += 0.2f;

            if (idleMoveCounter >= 50f)
            {
                idleSwitch2 = false;
                idleMoveCounter = 0f;
            }
        }
    }



    public override void MoveToPoint(Vector3 point)
    {
        
        Vector2 vectorToTarget = (point - transform.position);
        float angleToTarget = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg; 
        Quaternion rotationToTarget = Quaternion.AngleAxis(angleToTarget, Vector3.forward); //Calculates the rotation needed to make the object face the point
        float roundedAngle = Mathf.Round(angleToTarget / 10) * 10;//rounds the rotation
        if (roundedAngle <= 0) { roundedAngle += 360; }//translates to quaternion

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, Time.deltaTime * turnSpeed); //breaks the rotation into a series of steps to make it smoother
        

        if (Mathf.Round(transform.rotation.eulerAngles.z / 10) * 10 == roundedAngle || Mathf.Round(transform.rotation.eulerAngles.z / 10) * 10 == 0 && roundedAngle ==360) //Compares the rounded current roation to the rounded requiered roatation so the object can start moving towards the point when it is "near enough" to facing the point
        {
            
            transform.position += speed * Time.deltaTime * transform.right; //Moves the object forwards
        }
        
    }
    private void OnEnable()
    {
        MakeAvailable();
        fire = GetComponentInChildren<Orienter>().gameObject;
        FireSwitch(false);
        highlighter = GetComponentInChildren<Highlighter>();
        highlighter.gameObject.SetActive(false);
        //highlighter = gameObject.GetComponentInChildren<SpriteRenderer>();
    }
    private void OnDestroy()
    {
        MakeUnAvailable();
    }

    private void Update()
    {
        if (!fire.activeSelf)
        {
            IdleMove();
            IdleRotate();
        }

            
    }
}
