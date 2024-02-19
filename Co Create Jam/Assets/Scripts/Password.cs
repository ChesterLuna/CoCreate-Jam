using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    [SerializeField] public string correctPassword = "RAPTO";


    public void CheckEntry()
    {
        string _givenPassword = GetComponent<TMP_InputField>().text;

        if(_givenPassword.ToUpper() == correctPassword.ToUpper())
        {
            ChangeScene("Good Ending");
        }
        else
        {
            AddToTimer(-60f);
        }
    }

    public void CheckCost()
    {
        string _givenPassword = GetComponent<TMP_InputField>().text;

        if (_givenPassword.ToUpper() == correctPassword.ToUpper())
        {
            GetComponent<PopUpOnClick>().OpenPoPup();
        }
        else
        {
            AddToTimer(-60f);
        }

    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void AddToTimer(float seconds)
    {
        GameObject.FindWithTag("GameController").GetComponent<LevelManager>().AddTimer(seconds);

    }


}
