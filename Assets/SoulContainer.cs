using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulContainer : MonoBehaviour
{
    [SerializeField]
    private int soulCount;
    [SerializeField]
    private GameObject firePrefab;
    
    public void updateContent(RuntimeAnimatorController runtimeAnimatorController) // changes the number of contained soul sprites in this slot
    {
        if (this.transform.childCount!=soulCount)
        {
            foreach(Animator children in transform.GetComponentsInChildren<Animator>())
            {
                Destroy(children.gameObject);
            }
            for (int i = 1; i <= soulCount; i++)
            {
                GameObject tempSoul = Instantiate(firePrefab);
                tempSoul.transform.SetParent(this.transform);
                tempSoul.GetComponent<Animator>().runtimeAnimatorController = runtimeAnimatorController;

            }
        }


    }
    public void SetSoulCount(int count) { soulCount = count; }
}