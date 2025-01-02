using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private GameObject inventorySlotPrefab;
    [SerializeField]
    private GameObject fire;
    private List<GameObject> inventorySlots;
    [SerializeField] private List<RuntimeAnimatorController> animatorControllers;
    private PackController PackController;
    private void Start()
    {
        PackController = GameObject.Find("PackController").GetComponent<PackController>();
        PackController.PackCreation += UpdateSoulContainer;
        inventorySlots = new List<GameObject>();
        for(int i = 0; i < levelData.Instance.numPacks; i++) //makes UI slots for the number of packs for this level
        {
            GameObject temp = Instantiate(inventorySlotPrefab);
            temp.transform.SetParent(this.transform);
            temp.GetComponentInChildren<Animator>().runtimeAnimatorController = animatorControllers[i];
            inventorySlots.Add(temp);

        }
    }
    private void Update()
    {
        //for(int i = 0;i<inventorySlots.Count;i++) //updates the number of souls in every inventory slot
        //{
        //    inventorySlots[i].GetComponentInChildren<SoulContainer>().updateContent(animatorControllers[i]);
        //}
    }

    public void UpdateSoulContainer(int packnumber,int soulNum)
    {
        inventorySlots[packnumber-1].GetComponentInChildren<SoulContainer>().SetSoulCount(soulNum);
        inventorySlots[packnumber-1].GetComponentInChildren<SoulContainer>().updateContent(animatorControllers[packnumber-1]);
    }
    
}
