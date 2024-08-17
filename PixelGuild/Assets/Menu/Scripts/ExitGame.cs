using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
    public void ExitGame()
    {
        // Вывод сообщения в консоль для отладки
        Debug.Log("Game is exiting...");

        // Завершаем игру
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
