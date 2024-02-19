using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaderScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    string sceneToFade;
    
    private void Start() 
    {
        animator = GetComponent<Animator>();
    }
    public void FadeToScene(string scene)
    {
        sceneToFade = scene;
        animator.SetTrigger("Fade Out");
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToFade);
    }
}
