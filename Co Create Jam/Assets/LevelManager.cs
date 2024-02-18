using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject _activeCanvas;
    [SerializeField] public List<GameObject> ListCanvases;
    Dictionary<string, GameObject> _canvases = new Dictionary<string, GameObject>();
    // Get 5 canvases. Dictionary with name of scene "string" and canvases objects. To make dictionary, serialize a tuple and do a for to add [0] as keys and [1] as values, 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(ListCanvases != null, "No added Scenes");
        Debug.Assert(_activeCanvas != null, "No serialized active canvas");

        foreach (GameObject _canvas in ListCanvases)
        {
            _canvases.Add(_canvas.name, _canvas);
        }

    }

    public void ChangeCanvas(string _newCanvas)
    {
        Debug.Assert(_canvases.ContainsKey(_newCanvas), "There is no canvas found by that name. The string might be wrong or it hasnt been added to the list");
        if(_activeCanvas.name == _newCanvas)
        {
            Debug.Log("Tried to load the same canvas");
        }

        _activeCanvas.SetActive(false);
        _activeCanvas =_canvases[_newCanvas];
        _activeCanvas.SetActive(true);
    }

    public GameObject GetActiveCanvas()
    {
        return _activeCanvas;
    }


}
