using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneCharacters : MonoBehaviour
{


    public void LoadScene()
    {
        SceneManager.LoadScene("HeroShop");
    }
}