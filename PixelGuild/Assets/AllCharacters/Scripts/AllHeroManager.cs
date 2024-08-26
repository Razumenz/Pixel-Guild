using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AllHeroManager : MonoBehaviour
{
    public Transform heroListContainer;
    public GameObject heroListItemPrefab;
    public List<HeroData> allHeroes = new List<HeroData>();
    public Button recruitButton;
    private HeroData selectedHero;

    void Start()
    {
        recruitButton.interactable = false; // ������������ ������ "�����������" �� ���������
        PopulateHeroList();
    }

    void PopulateHeroList()
    {
        foreach (HeroData heroData in allHeroes)
        {
            GameObject newHeroItem = Instantiate(heroListItemPrefab, heroListContainer);
            newHeroItem.transform.Find("HeroNameText").GetComponent<Text>().text = heroData.Name;
            newHeroItem.transform.Find("HeroRankText").GetComponent<Text>().text = heroData.rank;
            newHeroItem.transform.Find("HeroEnergyText").GetComponent<Text>().text = "Energy: " + heroData.energy;
            newHeroItem.transform.Find("HeroLevelText").GetComponent<Text>().text = "Level: " + heroData.level;

            newHeroItem.GetComponent<Button>().onClick.AddListener(() => OnHeroSelected(heroData));
        }
    }

    void OnHeroSelected(HeroData heroData)
    {
        selectedHero = heroData;
        recruitButton.interactable = true;
    }

    public void RecruitHero()
    {
        if (selectedHero != null)
        {
            // �������� ������� ������ ������������� ������
            string recruitedHeroesJson = PlayerPrefs.GetString("RecruitedHeroes", "[]");
            ListWrapper<HeroData> recruitedHeroesWrapper = JsonUtility.FromJson<ListWrapper<HeroData>>(recruitedHeroesJson);

            // ��������� ������ �������������� ����� � ������
            recruitedHeroesWrapper.list.Add(selectedHero);

            // ��������� ����������� ������
            PlayerPrefs.SetString("RecruitedHeroes", JsonUtility.ToJson(recruitedHeroesWrapper));
            PlayerPrefs.Save();

            // ������������� ����� ��� ��������� ���������
            // SceneManager.LoadScene("RecruitedHeroesScene");
        }
    }
}

// ������� ��� ������, ����������� ��� ������������
[System.Serializable]
public class ListWrapper<T>
{
    public List<T> list = new List<T>();
}
