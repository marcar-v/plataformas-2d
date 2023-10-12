using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject transition;
    [SerializeField] AudioSource clickSound;
    public void PlayGame()
    {
        transition.SetActive(true);
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlaySoundButton()
    {
        clickSound.Play();
    }
}
