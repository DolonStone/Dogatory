using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pack : MonoBehaviour
{
    [SerializeField] private Soul[] soulsInPack;
    [SerializeField] private int packSize = 15;
    [SerializeField] private int roundingRadius = 5; // allows system to determine 
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
        
        if (targetexists && !atPosition)
        {
            atPosition = MovePackToPoint(target.transform.position);
            
        }
        else
        {
            print("working");
            atPosition = false;
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
            
            if (soulsInPack[i] != null)
            {
                            var difference = soulsInPack[i].GetLocation() - point;
            
                var xdif = Mathf.Round(difference.x/2*roundingRadius);
                var ydif = Mathf.Round(difference.y/2*roundingRadius);
            

                if (xdif < 1 || ydif < 1)
                {
                    withinRadiusCount++;

                }
                
                soulsInPack[i].MoveToPoint(point);
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
