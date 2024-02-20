using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCollider : MonoBehaviour
{
    [SerializeField] GameObject clock;
    [SerializeField] string timeNum;
    [SerializeField] bool _hour = false;
    [SerializeField] bool _minute = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    //void OnTriggerStay2D(Collider other) 
    {
        if(_hour && other.name == "HourCollider")
        {
            clock.GetComponent<clockPuzzle>()._hours = timeNum;
        }
        else if (_minute && other.name == "MinuteCollider")
        {
            clock.GetComponent<clockPuzzle>()._minutes = timeNum;
        }
    }
}
