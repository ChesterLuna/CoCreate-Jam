using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClocksLetterPuzzle : MonoBehaviour
{
    [SerializeField] GameObject[] clocks;

    [SerializeField] bool puzzleDone = false;

    // Update is called once per frame
    void Update()
    {
        // if(puzzleDone)
        //     return;
        puzzleDone = true;

        foreach (GameObject clock in clocks)
        {
            if (clock.GetComponent<clockPuzzle>()._foundCorrectTime == false)
            {
                puzzleDone =false;
            }
        }

        if(puzzleDone)
        {
            GetComponent<PopUpOnClick>().OpenPoPup();
            Debug.Log("OPEN");
            foreach (GameObject clock in clocks)
            {
                //if()
            }

        }

    }
}
