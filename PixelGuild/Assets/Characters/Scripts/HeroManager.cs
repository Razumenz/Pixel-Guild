using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour
{
    public Transform heroListContainer; // Контейнер для списка героев
    public GameObject heroListItemPrefab; // Префаб элемента списка героя
    public List<HeroData> allHeroes = new List<HeroData>(); // Список всех доступных героев
    public List<Hero> recruitedHeroes = new List<Hero>(); // Список завербованных героев

    // Метод вербовки героя
    public void RecruitHero()
    {
        if (allHeroes.Count > 0)
        {
            // Выбираем случайного героя из списка доступных
            int randomIndex = Random.Range(0, allHeroes.Count);
            HeroData heroData = allHeroes[randomIndex];

            // Создаем новый экземпляр героя и добавляем его в список завербованных
            Hero newHero = new Hero(heroData.Name, heroData.rank, heroData.energy, heroData.level);
            recruitedHeroes.Add(newHero);

            // Создаем новый элемент списка
            GameObject newHeroItem = Instantiate(heroListItemPrefab, heroListContainer);
            newHeroItem.transform.Find("HeroNameText").GetComponent<Text>().text = newHero.Name;
            newHeroItem.transform.Find("HeroRankText").GetComponent<Text>().text = newHero.Rank;
            newHeroItem.transform.Find("HeroEnergyText").GetComponent<Text>().text = "Energy: " + newHero.Energy;
            newHeroItem.transform.Find("HeroLevelText").GetComponent<Text>().text = "Level: " + newHero.Level;

            // Удаляем этого героя из списка доступных для вербовки
            allHeroes.RemoveAt(randomIndex);
        }
        else
        {
            Debug.Log("No more heroes to recruit." + allHeroes.Count);
        }
    }
}
