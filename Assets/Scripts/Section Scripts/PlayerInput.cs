using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject pointerPrefab;
    private GameObject currentPointer;
    [SerializeField] private RectTransform SelectionBox;
    private Vector2 StartMousePosition;
    Camera cam;

    private void Update()
    {
        PointerController();
        SelectionBoxController();
    }
    private void Start()
    {
        cam = FindAnyObjectByType<Camera>();
    }
    private void SelectionBoxController()
    {
        
        
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                SelectionManager.Instance.RemoveAll();
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
        float width = Input.mousePosition.x - StartMousePosition.x;
        float height = Input.mousePosition.y - StartMousePosition.y;  

        SelectionBox.anchoredPosition = StartMousePosition + new Vector2(width/2, height/2);
        SelectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        Bounds bounds = new Bounds(SelectionBox.anchoredPosition, SelectionBox.sizeDelta);

        foreach(Soul soul in SelectionManager.Instance.GetAvailableSouls())
        {
            if(IsInBounds(bounds,cam.WorldToScreenPoint(soul.transform.position)))
            {
                
                SelectionManager.Instance.SelectSoul(soul);
            }
            else
            {
                SelectionManager.Instance.RemoveSoul(soul);
            }
        }
    }
    
    private void PointerController()
    {
        if (Input.GetMouseButtonDown(1))
        {
            
            int pointerNumber = SelectionManager.Instance.selectedPack;
            if(GameObject.FindGameObjectWithTag("pointer" + pointerNumber))
            {
                Destroy(GameObject.FindGameObjectWithTag("pointer" + pointerNumber));
            }
            
            GameObject newpointer = Instantiate(pointerPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion(0f, 0f, 0f, 0f));
            newpointer.tag = "pointer" + pointerNumber;
        }
    }
    private bool IsInBounds(Bounds bounds, Vector2 position)
    {
        
        return bounds.Contains(position);
    }
}
