using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//using UnityEngine.UI;

public class GeneralButton : MonoBehaviour
{



    public void DisplayMenu(bool display)
    {
        Transform theCanvas = gameObject.transform.root.gameObject.transform;
        theCanvas.Find("Menu HUD").GameObject().SetActive(display);
        theCanvas.Find("Credits").GameObject().SetActive(!display);
    }

    // public void SaveGame()
    // {
    //     var writer = QuickSaveWriter.Create("Quick");
    //     writer.Write("LastScene", SceneManager.GetActiveScene().name);

    //     writer.Write("Session", GameSession.Instance);
    //     writer.Write("NameQueue", FindObjectOfType<DialogueManager>().names);
    //     writer.Write("DialogueQueue", FindObjectOfType<DialogueManager>().dialogues);
    //     writer.Commit();
    // }

    // public void LoadGame()
    // {

    //     // Here we read the data we saved in the section above
    //     var reader = QuickSaveReader.Create("Quick");
    //     SceneManager.LoadScene(reader.Read<string>("LastScene"));

    //     //DELETE GAME OBJECT FROM THE NEW SCENE
    //     GameObject.FindObjectOfType<GameSession>().resetGame();
    //     //CREATE A NEW GAME SESSION
    //     Instantiate(reader.Read<GameSession>("Session"));

    //     //GameSession.Instance
    //     FindObjectOfType<DialogueManager>().names = reader.Read<Queue<string>>("NameQueue");
    //     FindObjectOfType<DialogueManager>().dialogues = reader.Read<Queue<string>>("DialogueQueue");

    // }


    public void LoadMainMenu()
    {
        GameSession.Instance.resetGame();
        GameSession.Instance = null;
        SceneManager.LoadScene("Main Menu");

    }

    public void AddToTimer(float seconds)
    {
        GameObject.FindWithTag("GameController").GetComponent<LevelManager>().AddTimer(seconds);

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
        
    }

    public void ChangeSceneFading(string sceneToFade)
    {
        FindObjectOfType<FaderScript>().FadeToScene(sceneToFade);
    }


}
