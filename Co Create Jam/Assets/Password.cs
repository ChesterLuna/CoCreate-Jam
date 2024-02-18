using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    [SerializeField] public string correctPassword = "RAPTO";


    public void CheckEntry()
    {
        string _givenPassword = GetComponent<TMP_InputField>().text;

        if(_givenPassword.ToUpper() == correctPassword.ToUpper())
        {
            Debug.Log("Congrats");
        }

    }
}
