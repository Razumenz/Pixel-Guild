using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAllCharacters : MonoBehaviour
{

    public void StartGame()
    {
        // ��������� ����� "Reception"
        SceneManager.LoadScene("AllCharacters");
    }
}

