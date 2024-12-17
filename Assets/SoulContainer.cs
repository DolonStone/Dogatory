using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulContainer : MonoBehaviour
{
    private int soulCount;
    [SerializeField]
    private GameObject firePrefab;
    private int invSlot;
    public void updateContent(RuntimeAnimatorController runtimeAnimatorController, int invSlot)
    {
        if (this.transform.childCount!=soulCount)
        {
            foreach(Transform children in transform.GetComponentsInChildren<Transform>())
            {
                Destroy(children);
            }
            for (int i = 1; i < soulCount; i++)
            {
                GameObject tempSoul = Instantiate(firePrefab);
                tempSoul.transform.SetParent(this.transform);
                tempSoul.GetComponent<Animator>().runtimeAnimatorController = runtimeAnimatorController;

            }
        }


    }
}