using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour
{
    public Transform heroListContainer; // Контейнер для списка героев
    public GameObject heroListItemPrefab; // Префаб элемента списка героя
    public List<HeroData> allHeroes = new List<HeroData>(); // Список всех доступных героев

    void Start()
    {
        PopulateHeroList();
    }

    void PopulateHeroList()
    {
        foreach (HeroData heroData in allHeroes)
        {
            // Создаем новый элемент списка для каждого героя
            GameObject newHeroItem = Instantiate(heroListItemPrefab, heroListContainer);
            newHeroItem.transform.Find("HeroNameText").GetComponent<Text>().text = heroData.Name;
            newHeroItem.transform.Find("HeroRankText").GetComponent<Text>().text = heroData.rank;
            newHeroItem.transform.Find("HeroEnergyText").GetComponent<Text>().text = "Energy: " + heroData.energy;
            newHeroItem.transform.Find("HeroLevelText").GetComponent<Text>().text = "Level: " + heroData.level;
        }
    }
}
