using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    [SerializeField] string sceneToFade = "Desktop";
    [SerializeField] GameObject _txtCrawlerBox;
    FaderScript fader;

    private void Start()
    {
        fader = FindObjectOfType<FaderScript>();
    }

    private void Update()
    {
        if (_txtCrawlerBox == null)
            return;

        if (_txtCrawlerBox.GetComponent<TextMeshProUGUI>().text == _txtCrawlerBox.GetComponent<TextCrawler>()._textToWrite
        || _txtCrawlerBox == null)
        {
            fader.FadeToScene(sceneToFade);
        }

    }

    public void StartTextCrawlIntro()
    {
        Debug.Assert(_txtCrawlerBox != null, "Txt crawler is not activated ebcasue there is no game object");
        if (_txtCrawlerBox == null)
        {
            fader.FadeToScene(sceneToFade);
        }
        _txtCrawlerBox.GetComponent<TextCrawler>().CrawlText();
        GetComponent<Button>().interactable = false;
    }

}
