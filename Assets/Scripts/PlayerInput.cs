using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject pointerPrefab;
    private GameObject currentPointer;
    private RectTransform SelectionBox;
    private Vector2 StartMousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(currentPointer);
            currentPointer = Instantiate(pointerPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion(0f, 0f, 0f, 0f));
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SelectionBox.sizeDelta = Vector2.zero;
            SelectionBox.gameObject.SetActive(true);
            StartMousePosition = Input.mousePosition;
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            ResizeSelectionBox();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            SelectionBox.sizeDelta = Vector2.zero;
            SelectionBox.gameObject.SetActive(false);
        }
    }
    private void ResizeSelectionBox()
    {

    }
    
}
