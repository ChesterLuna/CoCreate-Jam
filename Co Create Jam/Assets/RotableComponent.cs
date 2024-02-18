using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotableComponent : MonoBehaviour
{
    float _startAngle=0f;
    [SerializeField] bool _hourHand = false;
    [SerializeField] bool _minuteHand = false;
    string _time;

    private void Start()
    {
        Debug.Assert(GetComponent<Collider>() != null, "This object must have a collider for dragging");
        _startAngle = transform.rotation.z;
        _time = angleToTime(transform.rotation.z);
    }

    void OnMouseDrag()
    {
        // VECTORRRR
        Vector3 objectToMouse = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        float _angle = Mathf.Atan2(objectToMouse.y, objectToMouse.x) * Mathf.Rad2Deg;
        float _newAngle = _angle - _startAngle;
        transform.rotation = Quaternion.AngleAxis(_newAngle, Vector3.forward);

    }

    void OnMouseExit()
    {
        float _chosenAngle = transform.rotation.z;
        string _time = angleToTime(_chosenAngle);


    }

    string angleToTime(float _angle)
    {
        string _theTime = "";
        if(_minuteHand)
        {
            float angleF = _angle / (360f / 4f);
            _theTime = (15f * Mathf.Floor(angleF)).ToString();
            transform.parent.GetComponent<clockPuzzle>()._minutes = _theTime;

        }
        else if (_hourHand)
        {
            float angleF = _angle / (360f / 12f);
            _theTime = Mathf.Floor(angleF).ToString();
            transform.parent.GetComponent<clockPuzzle>()._hours = _theTime;
        }
        return _theTime;
    }
}
