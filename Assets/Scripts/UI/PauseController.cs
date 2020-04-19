using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject mainMenu;
    public bool menuOpened = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) {

            menuOpened = !menuOpened;
            if (menuOpened == false)
            {
                mainMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else {
                Time.timeScale = 0;
                mainMenu.SetActive(true);
                mainMenu.GetComponent<MainMenuController>().HideOptionsView();
            }

        }
    }
}
