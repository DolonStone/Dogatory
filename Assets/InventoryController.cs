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
    private void Start()
    {
        inventorySlots = new List<GameObject>();
        for(int i = 0; i < levelData.Instance.numPacks; i++)
        {
            GameObject temp = Instantiate(inventorySlotPrefab);
            temp.transform.SetParent(this.transform);
            temp.GetComponentInChildren<Animator>().runtimeAnimatorController = animatorControllers[i];
            inventorySlots.Add(temp);

        }
    }
    private void Update()
    {
        for(int i = 0;i<inventorySlots.Count;i++)
        {
            inventorySlots[i].GetComponentInChildren<SoulContainer>().updateContent(animatorControllers[i],i);
        }
    }


    
}
