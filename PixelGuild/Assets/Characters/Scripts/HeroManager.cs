using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecruitedHeroesManager : MonoBehaviour
{
    public Transform recruitedHeroListContainer;
    public GameObject heroListItemPrefab;

    void Start()
    {
        PopulateRecruitedHeroList();
    }

    void PopulateRecruitedHeroList()
    {
        string recruitedHeroesJson = PlayerPrefs.GetString("RecruitedHeroes", "[]");
        ListWrapper<HeroData> recruitedHeroesWrapper = JsonUtility.FromJson<ListWrapper<HeroData>>(recruitedHeroesJson);

        foreach (HeroData heroData in recruitedHeroesWrapper.list)
        {
            GameObject newHeroItem = Instantiate(heroListItemPrefab, recruitedHeroListContainer);
            newHeroItem.transform.Find("HeroNameText").GetComponent<Text>().text = heroData.Name;
            newHeroItem.transform.Find("HeroRankText").GetComponent<Text>().text = heroData.rank;
            newHeroItem.transform.Find("HeroEnergyText").GetComponent<Text>().text = "Energy: " + heroData.energy;
            newHeroItem.transform.Find("HeroLevelText").GetComponent<Text>().text = "Level: " + heroData.level;
        }
    }
}
