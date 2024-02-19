using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePopUp : MonoBehaviour
{
    Vector3 offset;
    private void Start()
    {
        Debug.Assert(GetComponent<Collider>() != null, "This pop up must have a collider for dragging");
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        // Vector2 mousePos = GetMousePosition();

        RectTransform rt = GetComponent<RectTransform>();

        // rt.anchoredPosition = mousePos;//FindPositionInsideBounds(mousePos);

        Vector2 movementPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = (movementPosition);
        rt.anchoredPosition = FindPositionInsideBounds(rt);


    }

    private void OnMouseUp()
    {
        
    }

    private Vector2 GetMousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return mousePos;
    }


    private Vector2 FindPositionInsideBounds(RectTransform rt)
    {
        Vector2 popUpPosition = rt.anchoredPosition;

        float _newWidth = Mathf.Clamp(popUpPosition.x, 0, Screen.width - popUpPosition.x / 2);
        float _newHeight = Mathf.Clamp(popUpPosition.y, 0, Screen.height - popUpPosition.y / 2);

        Vector2 _newPopUpPosition = new Vector2(_newWidth, _newHeight);

        return _newPopUpPosition;
    }

}
