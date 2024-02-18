using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockPuzzle : MonoBehaviour
{
    [SerializeField] string _correctTime = "";
    [SerializeField] bool _foundCorrectTime = false;
    public string _hours;
    public string _minutes;
    string _time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time = _hours + ":" + _minutes;

        if(_time == _correctTime)
            _foundCorrectTime = true;
        else
            _foundCorrectTime = false;
            

    }
}