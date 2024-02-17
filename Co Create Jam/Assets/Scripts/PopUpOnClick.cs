using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpOnClick : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] GameObject _mainCanvas;
    [SerializeField] GameObject _popUp;
    [SerializeField] public bool _openedPopUp = false;
    // Start is called before the first frame update

    void Awake()
    {
        _mainCamera = Camera.main;
        _mainCanvas = GameObject.Find("Main Canvas");
        // if(popUp == null)
        Debug.Assert(_popUp != null, "There is no popup added to this button");

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerPopUp()
    {
        if(_openedPopUp)
        {
            Debug.Log("The pop up for this button is already open");
            return;
        }
        Vector2 mousePos = Input.mousePosition;
        // print(_mainCamera.WorldToScreenPoint(mousePos));
        // print(_mainCamera.WorldToViewportPoint(mousePos));
        // print(_mainCamera.ScreenToWorldPoint(mousePos));
        mousePos = _mainCamera.ScreenToWorldPoint(mousePos);
        // Vector2 playerPos = Camera.main.WorldToScreenPoint(transform.position);
        //mousePos = Input.mousePosition;
        // mousePos = transform.localPosition;
        print(mousePos);
        GameObject _newPopUp = Instantiate(_popUp, mousePos, transform.rotation, _mainCanvas.transform);
        // _newPopUp.GetComponent<RectTransform>().anchoredPosition = new Vector2(5f,5f);//mousePos;
        print("SCALE:");
        print(_newPopUp.transform.localScale);
        
        RectTransform rt = _newPopUp.GetComponent<RectTransform>();
        //rt.anchoredPosition = new Vector2(100f, 100f);
        //rt.offsetMin = rt.offsetMax = new Vector2(5f, 5f);

        _openedPopUp = true;
        _newPopUp.GetComponent<DeletePopUpOnClick>().SetParent(gameObject);

    }

    public void SetOpenedPopUp(bool value)
    {
        _openedPopUp = value;
    }
}
