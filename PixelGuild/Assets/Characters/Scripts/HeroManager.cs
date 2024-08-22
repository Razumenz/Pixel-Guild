using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour
{
    public Transform heroListContainer; // ��������� ��� ������ ������
    public GameObject heroListItemPrefab; // ������ �������� ������ �����
    public List<HeroData> allHeroes = new List<HeroData>(); // ������ ���� ��������� ������
    public List<Hero> recruitedHeroes = new List<Hero>(); // ������ ������������� ������

    // ����� �������� �����
    public void RecruitHero()
    {
        if (allHeroes.Count > 0)
        {
            // �������� ���������� ����� �� ������ ���������
            int randomIndex = Random.Range(0, allHeroes.Count);
            HeroData heroData = allHeroes[randomIndex];

            // ������� ����� ��������� ����� � ��������� ��� � ������ �������������
            Hero newHero = new Hero(heroData.Name, heroData.rank, heroData.energy, heroData.level);
            recruitedHeroes.Add(newHero);

            // ������� ����� ������� ������
            GameObject newHeroItem = Instantiate(heroListItemPrefab, heroListContainer);
            newHeroItem.transform.Find("HeroNameText").GetComponent<Text>().text = newHero.Name;
            newHeroItem.transform.Find("HeroRankText").GetComponent<Text>().text = newHero.Rank;
            newHeroItem.transform.Find("HeroEnergyText").GetComponent<Text>().text = "Energy: " + newHero.Energy;
            newHeroItem.transform.Find("HeroLevelText").GetComponent<Text>().text = "Level: " + newHero.Level;

            // ������� ����� ����� �� ������ ��������� ��� ��������
            allHeroes.RemoveAt(randomIndex);
        }
        else
        {
            Debug.Log("No more heroes to recruit." + allHeroes.Count);
        }
    }
}
