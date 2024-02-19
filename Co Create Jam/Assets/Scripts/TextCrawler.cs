using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextCrawler : MonoBehaviour
{
    [SerializeField] bool _startAtPlay;
    [SerializeField] public string _textToWrite = "";
    [SerializeField] float _speedToWrite = 0.5f;
    TextMeshProUGUI _textBox;
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Assert(GetComponent<TextMeshProUGUI>(),"This object needs TMPU");
        _textBox = GetComponent<TextMeshProUGUI>();

        if(_startAtPlay)
        {
            CrawlText();
        }
    }

    public void CrawlText()
    {
        StartCoroutine(writeText(_textToWrite, _speedToWrite));
    }

    IEnumerator writeText(string _textToWrite, float _speedToWrite)
    {
        _textBox.text = "";
        for(int i = 0; i< _textToWrite.Length; i++)
        {
            _textBox.text += _textToWrite[i];
            yield return new WaitForSeconds(_speedToWrite);
        }

    }
}
