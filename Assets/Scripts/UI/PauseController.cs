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
            }
            else {
                mainMenu.SetActive(true);
                mainMenu.GetComponent<MainMenuController>().HideOptionsView();
            }

        }
    }
}
