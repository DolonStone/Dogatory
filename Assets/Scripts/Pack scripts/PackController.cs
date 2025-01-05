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
    public event Action<int,int> PackCreation = delegate { };

    private void Start()
    {
        numPacks = levelData.Instance.numPacks;
        numInPack = levelData.Instance.numInPacks;
        SelectionManager.Instance.soulDestruction += RefreshAll;
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
        
        CheckForDupes(souls,selectedPack);
        PackCreation.Invoke(selectedPack, souls.Count);
        for (int i = 0;i < souls.Count; i++)
        {
            if (i <= numInPack)
            {
                packs[selectedPack-1].AddToPack(souls[i]); //adds the new pack to the packs array
            }
            
        }
        packs[selectedPack - 1].packPointer = "pointer" + selectedPack.ToString();
        packs[selectedPack - 1].ChangePackColor(selectedPack);
    }
    private void EmptyPack(int selectedPack)
    {
        
        packs[selectedPack - 1].Empty();
        
    }
    private void Update()
    {
        GetSelectedPack();
    }
    private void GetSelectedPack()
    {

        if (Input.inputString != "")
        {
            bool isANumber = Int32.TryParse(Input.inputString, out int number);//tests if the input is a number
            if (isANumber && number >= 0 && number <= numPacks)
            {

                selectedPack = number;
                SelectionManager.Instance.selectedPack = selectedPack;

                if (SelectionManager.Instance.GetSelectedSouls().Count > 0) //if souls are selected it makes a new pack, if not it just sets the selected pack
                {

                    EmptyPack(selectedPack);
                    CreatePack(SelectionManager.Instance.GetSelectedSouls(), selectedPack);
                }
                SelectionManager.Instance.RemoveAll();

            }
        }

    }
    private void RefreshAll(Soul soul)
    {
        for(int i=0; i < numPacks; i++)
        {
            packs[i].RemoveFromPack(soul);
            
            PackCreation.Invoke(i + 1, packs[i].GetNumberOfSouls()); //FIX THIS IT DONT WORK
                
        }
    }
    private void CheckForDupes(List<Soul> souls,int selectedPack)
    {
        for (int k = 0; k < souls.Count; k++)
        {
            for (int i = 0; i < packs.Length; i++)
            {
                for (int j = 0; j < packs[i].GetSoulsInPack().Length; j++)
                {
                    Soul tempSoul = packs[i].GetSoulsInPack()[j];
                    if (souls[k] == tempSoul)
                    {
                        
                        packs[i].RemoveFromPack(tempSoul);
                        PackCreation.Invoke(i+1, packs[i].GetNumberOfSouls());
                    }
                }
            }
        }
    }
}
