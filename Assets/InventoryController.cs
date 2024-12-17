using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private GameObject inventorySlotPrefab;
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




}
