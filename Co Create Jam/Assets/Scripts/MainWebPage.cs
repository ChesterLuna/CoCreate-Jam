using System;
using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SearchService;
using UnityEngine;

public class MainWebPage : MonoBehaviour
{
    LevelManager _levelManager;
    // Start is called before the first frame update
    void Awake()
    {
        _levelManager = GameObject.FindWithTag("GameController").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTab(string _tab)
    {
        _levelManager.ChangeCanvas(_tab);
    }
}
