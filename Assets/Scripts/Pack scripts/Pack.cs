using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pack : MonoBehaviour
{
    [SerializeField] private Soul[] soulsInPack;
    [SerializeField] private int packSize = 15;
    [SerializeField] private float roundingRadius = 0.25f; // allows system to determine 
    [SerializeField] private bool atPosition = false;

    private GameObject target = null;
    private bool full = false;
    public Color packColour = Color.red;
    public string packPointer;
    public void SetPackSize(int packSize)
    {
        this.packSize = packSize;
    }

    private void Start()
    {
        soulsInPack = new Soul[packSize];
    }
    private void Update()
    {
        bool targetexists = IsThereTarget(packPointer);
        
        if (targetexists)
        {
            atPosition = MovePackToPoint(target.transform.position);
            
        }
        if (atPosition)
        {
            
            Destroy(target);
        }
        //print(atPosition);
    }
    public void Empty()
    {
        soulsInPack = new Soul[packSize];
    }
    public void AddToPack(Soul soul)
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
    public void RemoveFromPack(Soul soul)
    {
        for (int i = 0; i < soulsInPack.Length; i++)
        {
            if (soulsInPack[i] == soul)
            {
                soulsInPack[i] = null;
            }
        }
    }
    public void ChangePackColor(int num)
    {
        for (int i = 0; i < soulsInPack.Length; i++)
        {
            if(soulsInPack[i]!= null)
            {
                soulsInPack[i].ChangeColour(num);
            }
            
        }
    }
    private bool MovePackToPoint(Vector3 point)
    {
        
        int withinRadiusCount = 0;
        int totalSoulsCount = 0;
        for (int i = 0; i < soulsInPack.Length; i++)
        {
            
            if (soulsInPack[i] != null) //this if statement checks if a soul is near enough its target point and if not it moves the soul
            {

                totalSoulsCount += 1;
                var difference = soulsInPack[i].GetLocation() - point;
                
                var xdif = Mathf.Abs(difference.x);
                var ydif = Mathf.Abs(difference.y);
                if (xdif < roundingRadius && ydif < roundingRadius)
                {
                    
                    withinRadiusCount++;

                }
                else
                {
                    soulsInPack[i].MoveToPoint(point);
                }
                
            }  
        }
        if (withinRadiusCount == totalSoulsCount) 
        {
            return true; 
        }
        else
        {
            print(withinRadiusCount);
            return false;
        }
    }
    private bool IsThereTarget(string tag)
    {

        if (tag != null && GameObject.FindGameObjectWithTag(tag) != null)
        {
            target = GameObject.FindGameObjectWithTag(tag);
            return true;
        }
        return false;
    }
    public Soul[] GetSoulsInPack()
    {
        return soulsInPack;
    }
}
