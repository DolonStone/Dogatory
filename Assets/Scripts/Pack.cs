using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pack : MonoBehaviour
{
    [SerializeField] private Soul[] soulsInPack;
    [SerializeField] private int packSize = 15;
    [SerializeField] private float roundingRadius = 0.5f; // allows system to determine 
    [SerializeField] private bool atPosition = false;
    GameObject target = null;
    bool full = false;
    Color packColour = Color.red;

    private void Start()
    {
        //soulsInPack = new Soul[packSize];
    }
    private void Update()
    {
        bool targetexists = IsThereTarget("Pointer");
        
        if (targetexists)
        {
            atPosition = MovePackToPoint(target.transform.position);
            print(target.transform.position);
        }
        
        
    }
    private void AddToPack(Soul soul)
    {
        full = true;
        int topEmpty = 0;
        for (int i = 0; i < soulsInPack.Length; i++)
        {
            if (soulsInPack[i] == null)
            {
                topEmpty = i;
                full = false;
                break;
            }
        }
        if (!full)
        {
            soulsInPack[topEmpty] = soul;
        }
    }
    private void RemoveFromPack(Soul soul)
    {
        for (int i = 0; i < soulsInPack.Length; i++)
        {
            if (soulsInPack[i] == soul)
            {
                soulsInPack[i] = null;
            }
        }
    }
    private bool MovePackToPoint(Vector3 point)
    {
        
        int withinRadiusCount = 0;
        for (int i = 0; i < soulsInPack.Length; i++)
        {
            
            if (soulsInPack[i] != null) //this if statement checks if a soul is near enough its target point and if not it moves the soul
            {
                

                var difference = soulsInPack[i].GetLocation() - point;
                
                var xdif = Mathf.Abs(difference.x);
                var ydif = Mathf.Abs(difference.y);
                if (xdif < roundingRadius && ydif < roundingRadius)
                {
                    print(xdif);
                    withinRadiusCount++;

                }
                else
                {
                    soulsInPack[i].MoveToPoint(point);
                }
                
            }  
        }
        if (withinRadiusCount == soulsInPack.Count()) 
        {
            return true; 
        }
        else
        {
            return false;
        }
    }
    private bool IsThereTarget(string tag)
    {
        if (GameObject.FindGameObjectWithTag(tag) != null)
        {
            target = GameObject.FindGameObjectWithTag(tag);
            return true;
        }
        return false;
    }
}
