using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePuzzle : MonoBehaviour
{
    [SerializeField] int numberOfPieces = 3;
    [SerializeField] int piecesFound = 0;
    // bool _allPiecesConnected = false;

    private void Start()
    {
        piecesFound++; //Takes into account itself as a piece
    }
    
    private void Update()
    {
        if(Input.GetMouseButtonUp(0) && piecesFound >= numberOfPieces)
            GetComponent<PopUpOnClick>().OpenPoPup();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("There is collision");
        if (other.tag == "Piece")
        {
            piecesFound++;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Piece")
        {
            piecesFound--;
        }

    }
}
