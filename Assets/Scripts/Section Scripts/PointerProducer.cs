using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerProducer : MonoBehaviour
{
    [SerializeField] private GameObject pointerPrefab;
    private GameObject currentPointer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(currentPointer);
            currentPointer = Instantiate(pointerPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion(0f,0f,0f,0f));
        }
    }
}
