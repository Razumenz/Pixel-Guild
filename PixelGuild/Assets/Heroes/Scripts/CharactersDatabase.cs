using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CharacterDatabase : MonoBehaviour
{
    public List<Character> allCharacters = new List<Character>(); // ������ ���� ����������

    private string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "characters.json");
        LoadCharacters();
    }

    // ���������� ���������� � ����
    public void SaveCharacters()
    {
        string json = JsonUtility.ToJson(this, true);
        File.WriteAllText(filePath, json);
    }

    // �������� ���������� �� �����
    public void LoadCharacters()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }
}
