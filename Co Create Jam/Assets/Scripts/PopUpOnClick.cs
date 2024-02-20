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
    [SerializeField] GameObject _bounds;

    // Start is called before the first frame update

    void Awake()
    {
        
        _mainCamera = Camera.main;
        // if(popUp == null)
        Debug.Assert(_popUp != null, "There is no popup added to this button");
        _bounds = GameObject.FindWithTag("Bounds");

    }
    void Start()
    {
        _mainCanvas = GameObject.FindWithTag("GameController").GetComponent<LevelManager>().GetActiveCanvas();

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
        Vector2 mousePos = GetMousePosition();

        GameObject _newPopUp = Instantiate(_popUp, mousePos, transform.rotation, _mainCanvas.transform);

        RectTransform rt = _newPopUp.GetComponent<RectTransform>();
        rt.anchoredPosition = FindPositionInsideBounds(rt);

        _openedPopUp = true;
        _newPopUp.GetComponent<DeletePopUpOnClick>().SetParent(gameObject);
    }

    public void OpenPoPup()
    {
        if (_openedPopUp)
        {
            Debug.Log("The pop up for this button is already open");
            return;
        }

        GameObject _newPopUp = Instantiate(_popUp, transform.position, transform.rotation, _mainCanvas.transform);

        _openedPopUp = true;
        _newPopUp.GetComponent<DeletePopUpOnClick>().SetParent(gameObject);
    }


    private Vector2 GetMousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        mousePos = _mainCamera.ScreenToWorldPoint(mousePos);
        return mousePos;
    }

    private Vector2 FindPositionInsideBounds(RectTransform rt)
    {
        RectTransform bound = _bounds.GetComponent<RectTransform>();
        Vector2 popUpPosition = rt.anchoredPosition;//transform.TransformPoint(transform.position);

        float _boundedWidth = bound.rect.width;
        float _boundedHeight = bound.rect.height;
        float _boundedLeft = bound.offsetMin.x;//bound.rect.left;
        float _boundedBottom = bound.offsetMin.y;//bound.rect.bottom;


        float _newWidth = Mathf.Clamp(popUpPosition.x, _boundedLeft, _boundedLeft + _boundedWidth - rt.rect.width);
        float _newHeight = Mathf.Clamp(popUpPosition.y, _boundedBottom, _boundedBottom + _boundedHeight - rt.rect.height);


        Vector2 _newPopUpPosition = new Vector2(_newWidth, _newHeight);

        return _newPopUpPosition;
    }

    public void SetOpenedPopUp(bool value)
    {
        _openedPopUp = value;
    }
}
