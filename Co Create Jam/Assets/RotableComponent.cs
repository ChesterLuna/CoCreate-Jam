using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotableComponent : MonoBehaviour
{
    private void Start()
    {
        Debug.Assert(GetComponent<Collider>() != null, "This object must have a collider for dragging");
    }

    void OnMouseDrag()
    {
        // VECTORRRR
        Vector3 objectToMouse = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        float angle = Mathf.Atan2(objectToMouse.y, objectToMouse.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
