using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAllCharacters : MonoBehaviour
{

    public void StartGame()
    {
        // Загружаем сцену "Reception"
        SceneManager.LoadScene("AllCharacters");
    }
}

