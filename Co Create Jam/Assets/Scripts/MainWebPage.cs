using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainWebPage : MonoBehaviour
{
    [SerializeField] public String[] TabsScenesNames;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Assert(TabsScenesNames!= null, "No added Scenes");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTab(string _tab)
    {
        SceneManager.LoadScene(_tab);
    }
}
