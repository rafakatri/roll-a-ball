using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonBack : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
