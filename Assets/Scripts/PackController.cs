using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackController : MonoBehaviour
{
    [SerializeField] 
    
    private int numPacks;
    [SerializeField]
    private int numInPack;
    [SerializeField]
    private Pack[] packs;
    [SerializeField]
    private int selectedPack;

    private void Start()
    {

        packs = new Pack[numPacks];

        for (int i = 0; i < packs.Length; i++)
        {
            GameObject PackHolder = new GameObject();
            PackHolder.AddComponent<Pack>();
            packs[i] = PackHolder.GetComponent<Pack>();
            packs[i].SetPackSize(numInPack);
            
        }
    }
    private void CreatePack(List<Soul> souls,int selectedPack)
    {
        for (int i = 0;i < souls.Count; i++)
        {
            packs[selectedPack-1].AddToPack(souls[i]);
        }
    }
    private void Update()
    {
        if (Input.inputString != "")
        {
            int number;
            bool is_a_number = Int32.TryParse(Input.inputString, out number);
            if (is_a_number && number >= 0 && number < numPacks)
            {
                selectedPack = number;
                CreatePack(SelectionManager.Instance.GetSelectedSouls(), selectedPack);
            }
        }
    }
}
