using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        _mainCanvas = GameObject.FindWithTag("GameController").GetComponent<LevelManager>().GetActiveCanvas();
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
        if (_openedPopUp)
        {
            Debug.Log("The pop up for this button is already open");
            return;
        }
        Vector2 mousePos = Input.mousePosition;
        mousePos = _mainCamera.ScreenToWorldPoint(mousePos);
        GameObject _newPopUp = Instantiate(_popUp, mousePos, transform.rotation, _mainCanvas.transform);

        RectTransform rt = _newPopUp.GetComponent<RectTransform>();
        rt.anchoredPosition = FindPositionInsideBounds(rt);

        _openedPopUp = true;
        _newPopUp.GetComponent<DeletePopUpOnClick>().SetParent(gameObject);
    }

    private Vector2 FindPositionInsideBounds(RectTransform rt)
    {
        Vector2 popUpPosition = rt.anchoredPosition;

        float _newWidth = Mathf.Clamp(popUpPosition.x, 0, Screen.width - popUpPosition.x / 2);
        float _newHeight = Mathf.Clamp(popUpPosition.y, 0, Screen.height - popUpPosition.y / 2);

        Vector2 _newPopUpPosition = new Vector2(_newWidth, _newHeight);

        return _newPopUpPosition;
    }

    public void SetOpenedPopUp(bool value)
    {
        _openedPopUp = value;
    }
}
