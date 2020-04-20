using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLoseMenuController : MonoBehaviour
{
    public void GoToMainMenu ()
    {
        SceneManager.LoadScene (0);
    }
}
