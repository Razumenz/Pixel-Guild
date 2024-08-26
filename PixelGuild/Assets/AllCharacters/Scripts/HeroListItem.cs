using UnityEngine;
using UnityEngine.UI;

public class HeroListItem : MonoBehaviour
{
    private HeroData heroData;

    public void Setup(HeroData data)
    {
        heroData = data;
        // Предположим, что в вашем префабе есть компоненты Text
        transform.Find("HeroNameText").GetComponent<Text>().text = heroData.Name;
        transform.Find("HeroRankText").GetComponent<Text>().text = heroData.rank;
        transform.Find("HeroEnergyText").GetComponent<Text>().text = "Energy: " + heroData.energy;
        transform.Find("HeroLevelText").GetComponent<Text>().text = "Level: " + heroData.level;
    }

    public void OnItemClicked()
    {
        // Предполагаем, что у вас есть ссылка на AllHeroManager
        FindObjectOfType<AllHeroManager>().OnHeroSelected(heroData);
    }
}
