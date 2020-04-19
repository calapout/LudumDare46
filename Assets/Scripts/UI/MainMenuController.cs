using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Transform mainMenu;
    public Transform options;

    public GameObject playBtn;
    public GameObject pauseController;
    public GameObject pauseMenuHint;

    public TutorialsManager tutos;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void ChangeAll(bool v) {
        mainMenu.gameObject.SetActive(v);
        options.gameObject.SetActive(v);
    }

    public void OpenOptionsView() {
        mainMenu.gameObject.SetActive(false);
        options.gameObject.SetActive(true);
    }
    public void HideOptionsView() {
        mainMenu.gameObject.SetActive(true);
        options.gameObject.SetActive(false);
    }

    public void PlayGame() {
        playBtn.SetActive(false);
        ChangeAll(false);
        this.gameObject.SetActive(false);
        this.pauseController.SetActive(true);
        this.pauseMenuHint.SetActive(true);
        Time.timeScale = 1;

        tutos.PlaySunChanAnim();
    }
    public void QuitGame() {
        Application.Quit();
    }
}
