using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public string Name;

    public void LoadScene()
    {
        SceneManager.LoadScene(Name);
    }
}