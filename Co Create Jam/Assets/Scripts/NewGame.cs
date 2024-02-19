using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    [SerializeField] string introScene = "Desktop";
    [SerializeField] GameObject _txtCrawlerBox;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (_txtCrawlerBox == null)
            return;

        if (_txtCrawlerBox.GetComponent<TextMeshProUGUI>().text == _txtCrawlerBox.GetComponent<TextCrawler>()._textToWrite
        || _txtCrawlerBox == null)
        {
            ChangeScene(introScene);
        }

    }

    public void StartTextCrawlIntro()
    {
        Debug.Assert(_txtCrawlerBox != null, "Txt crawler is not activated ebcasue there is no game object");
        if (_txtCrawlerBox == null)
        {
            ChangeScene(introScene);
        }
        _txtCrawlerBox.GetComponent<TextCrawler>().CrawlText();
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
