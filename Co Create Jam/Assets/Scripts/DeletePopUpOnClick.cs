using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeletePopUpOnClick : MonoBehaviour
{
    [SerializeField] GameObject _parentButton;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Assert(_parentButton != null, "This popup was instantiated without a parent or the parent disappeared.");
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void ClosePopUp()
    {
        Debug.Log("Deleted one PopUp in location: " + transform.position);

        _parentButton.GetComponent<PopUpOnClick>().SetOpenedPopUp(false);
        Destroy(this.gameObject);

    }

    public void SetParent(GameObject _newParent)
    {
        _parentButton = _newParent;
    }

}
