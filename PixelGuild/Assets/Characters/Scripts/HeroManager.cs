using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour
{
    public Transform heroListContainer; // ��������� ��� ������ ������
    public GameObject heroListItemPrefab; // ������ �������� ������ �����
    public List<HeroData> allHeroes = new List<HeroData>(); // ������ ���� ��������� ������

    void Start()
    {
        PopulateHeroList();
    }

    void PopulateHeroList()
    {
        foreach (HeroData heroData in allHeroes)
        {
            // ������� ����� ������� ������ ��� ������� �����
            GameObject newHeroItem = Instantiate(heroListItemPrefab, heroListContainer);
            newHeroItem.transform.Find("HeroNameText").GetComponent<Text>().text = heroData.Name;
            newHeroItem.transform.Find("HeroRankText").GetComponent<Text>().text = heroData.rank;
            newHeroItem.transform.Find("HeroEnergyText").GetComponent<Text>().text = "Energy: " + heroData.energy;
            newHeroItem.transform.Find("HeroLevelText").GetComponent<Text>().text = "Level: " + heroData.level;
        }
    }
}
