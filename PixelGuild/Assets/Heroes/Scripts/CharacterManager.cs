using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDatabase; // ������ �� ���� ������ ����������
    public GameObject characterListContainer;  // ��������� ��� ����������� ������ ����������
    public GameObject characterPrefab;         // ������ ��� ����������� ���������

    private List<Character> recruitedCharacters = new List<Character>(); // ������ ������������� ����������

    void Start()
    {
        RefreshUI();
    }

    // ���������� ������ ���������
    public void RecruitCharacter()
    {
        // ��������, �������� ���������� ��������� �� ���� ������
        int randomIndex = Random.Range(0, characterDatabase.allCharacters.Count);
        Character newCharacter = characterDatabase.allCharacters[randomIndex];

        // ��������� ��������� � �������������
        recruitedCharacters.Add(newCharacter);
        RefreshUI();
    }

    // �������� ���������
    public void DismissCharacter(int index)
    {
        recruitedCharacters.RemoveAt(index);
        RefreshUI();
    }

    // ���������� UI
    void RefreshUI()
    {
        foreach (Transform child in characterListContainer.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < recruitedCharacters.Count; i++)
        {
            GameObject characterItem = Instantiate(characterPrefab, characterListContainer.transform);
            Character character = recruitedCharacters[i];

            characterItem.transform.Find("NameText").GetComponent<Text>().text = character.name;
            characterItem.transform.Find("RankText").GetComponent<Text>().text = character.rank;
            characterItem.transform.Find("HPText").GetComponent<Text>().text = "HP: " + character.hp;
            characterItem.transform.Find("DamageText").GetComponent<Text>().text = "Damage: " + character.damage;

            int index = i;
            characterItem.transform.Find("DismissButton").GetComponent<Button>().onClick.AddListener(() => DismissCharacter(index));
        }
    }
}
