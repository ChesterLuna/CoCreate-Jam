using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject _activeCanvas;
    [SerializeField] public List<GameObject> ListCanvases;
    Dictionary<string, GameObject> _canvases = new Dictionary<string, GameObject>();
    [SerializeField] TextMeshProUGUI _score;
    [SerializeField] GameObject _scoreObject;
    [SerializeField] float _maxTimer = 600f;
    [SerializeField] float _timeLeft = 600f;
    // Get 5 canvases. Dictionary with name of scene "string" and canvases objects. To make dictionary, serialize a tuple and do a for to add [0] as keys and [1] as values, 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(ListCanvases != null, "No added Scenes");
        Debug.Assert(_activeCanvas != null, "No serialized active canvas");

        _timeLeft = _maxTimer;
        _timeLeft = _maxTimer;

        foreach (GameObject _canvas in ListCanvases)
        {
            _canvases.Add(_canvas.name, _canvas);
        }

    }

    private void Update()
    {
        _timeLeft -= Time.deltaTime;
        UpdateScore(_timeLeft);

        if(_timeLeft<=0)
        {
            QuitGame();
        }

    }

    void UpdateScore(float _timeLeft)
    {
        float _minutes = Mathf.Floor(_timeLeft / 60);
        float _seconds = Mathf.RoundToInt(_timeLeft % 60.1f);
        // if(_seconds == 60)
        //     _seconds = 59;

        string _timer;
        if(_minutes >= 10)
        {
            _timer = _minutes.ToString();
        }
        else
        {
            _timer = "0" + _minutes.ToString();
        }
        _timer += ":";
        if (_seconds >= 10)
        {
            _timer += _seconds.ToString();
        }
        else
        {
            _timer += "0" + _seconds.ToString();
        }

        _score.text = _timer;
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

    public void AddTimer(float seconds)
    {
        _timeLeft += seconds;
        _scoreObject.GetComponent<Animator>().SetTrigger("Glitching");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");

    }


}
