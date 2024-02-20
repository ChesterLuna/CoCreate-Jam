using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClocksLetterPuzzle : MonoBehaviour
{
    [SerializeField] GameObject[] _pieces;

    [SerializeField] bool puzzleDone = false;

    // Update is called once per frame
    void Update()
    {
        // if(puzzleDone)
        //     return;
        puzzleDone = true;

        foreach (GameObject _piece in _pieces)
        {
            if (_piece.GetComponent<clockPuzzle>()._foundCorrectTime == false)
            {
                puzzleDone =false;
            }
        }

        if(puzzleDone)
        {
            GetComponent<PopUpOnClick>().OpenPoPup();
            Debug.Log("OPEN");
            foreach (GameObject clock in _pieces)
            {
                //if()
            }

        }

    }
}
