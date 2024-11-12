using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerProducer : MonoBehaviour
{
    [SerializeField] private GameObject pointerPrefab;
    private GameObject currentPointer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(currentPointer);
            currentPointer = Instantiate(pointerPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion(0f,0f,0f,0f));
        }
    }
}
