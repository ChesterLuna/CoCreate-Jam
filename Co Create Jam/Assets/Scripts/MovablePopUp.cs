using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePopUp : MonoBehaviour
{
    [SerializeField] GameObject _bounds;
    Vector3 offset;
    RectTransform rt;

    private void Start()
    {
        Debug.Assert(GetComponent<BoxCollider2D>() != null, "This pop up must have a collider for dragging");
        _bounds = GameObject.FindWithTag("Bounds");
        rt = GetComponent<RectTransform>();

    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        // Vector2 mousePos = GetMousePosition();


        // rt.anchoredPosition = mousePos;//FindPositionInsideBounds(mousePos);

        Vector2 movementPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = (movementPosition);
        rt.anchoredPosition = FindPositionInsideBounds(rt);

        //transform.position = FindPositionInsideBounds(rt);

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
        RectTransform bound = _bounds.GetComponent<RectTransform>();
        Vector2 popUpPosition = rt.anchoredPosition;//transform.TransformPoint(transform.position);

        float _boundedWidth = bound.rect.width;
        float _boundedHeight = bound.rect.height;
        float _boundedLeft = bound.offsetMin.x;//bound.rect.left;
        float _boundedBottom = bound.offsetMin.y;//bound.rect.bottom;


        float _newWidth = Mathf.Clamp(popUpPosition.x, _boundedLeft, _boundedLeft +_boundedWidth - rt.rect.width);
        float _newHeight = Mathf.Clamp(popUpPosition.y, _boundedBottom, _boundedBottom +_boundedHeight - rt.rect.height);


        Vector2 _newPopUpPosition = new Vector2(_newWidth, _newHeight);

        return _newPopUpPosition;
    }

}
