using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotableComponent : MonoBehaviour
{
    float _startAngle=0f;
    [SerializeField] bool _hourHand = false;
    [SerializeField] bool _minuteHand = false;
    string _time;
    RectTransform rt;

    private void Start()
    {
        Debug.Assert(GetComponent<Collider>() != null, "This object must have a collider for dragging");
        rt = GetComponent<RectTransform>();
        _startAngle = rt.eulerAngles.z;
        //_time = angleToTime(transform.rotation.z);
    }

    private void Update()
    {
        Debug.Log(rt.eulerAngles.z);
    }

    void OnMouseDrag()
    {
        // VECTORRRR
        Vector3 objectToMouse = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        float _angle = Mathf.Atan2(objectToMouse.y, objectToMouse.x) * Mathf.Rad2Deg;
        float _newAngle = _angle - _startAngle;
        transform.rotation = Quaternion.AngleAxis(_newAngle, Vector3.forward);

    }

    void OnMouseUp()
    {
        float _chosenAngle = rt.eulerAngles.z;
        Debug.Log(rt.eulerAngles.z);
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
            Debug.Log(_angle);
            Debug.Log(angleF);
            Debug.Log(_theTime);
            transform.parent.GetComponent<clockPuzzle>()._hours = _theTime;
        }
        return _theTime;
    }
}
