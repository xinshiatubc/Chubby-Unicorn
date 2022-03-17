using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject panel;
    public GameObject unicorn;
    private Animator anim;

    void Start()
    {
        anim = unicorn.GetComponent<Animator>();
    }


    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeIn(sceneName));
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartHighlighted()
    {
        anim.SetTrigger("Start");
        FindObjectOfType<AudioManager>().PlayAudio("Highlight");
    }

    public void QuitHighlighted()
    {
        anim.SetTrigger("Quit");
        FindObjectOfType<AudioManager>().PlayAudio("Highlight");

    }

    public void NoHighlighted()
    {
        anim.SetTrigger("Default");
    }
    IEnumerator FadeIn(string sceneName)
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);

    }
}
