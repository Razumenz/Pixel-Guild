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
        recruitButton.interactable = false; // Деактивируем кнопку "Завербовать" по умолчанию
        PopulateHeroList();
    }

    void PopulateHeroList()
    {
        foreach (HeroData heroData in allHeroes)
        {
            GameObject newHeroItem = Instantiate(heroListItemPrefab, heroListContainer);

            HeroListItem item = newHeroItem.GetComponent<HeroListItem>();
            if (item != null)
            {
                item.Setup(heroData);
            }
            else
            {
                Debug.LogError("HeroListItem component is missing on the prefab.");
            }
        }
    }

    public void OnHeroSelected(HeroData heroData)
    {
        selectedHero = heroData;
        recruitButton.interactable = true;
    }


    public void RecruitHero()
    {
        if (selectedHero != null)
        {
            // Получаем текущий список завербованных героев
            string recruitedHeroesJson = PlayerPrefs.GetString("RecruitedHeroes", "[]");
            ListWrapper<HeroData> recruitedHeroesWrapper = JsonUtility.FromJson<ListWrapper<HeroData>>(recruitedHeroesJson);

            // Добавляем нового завербованного героя в список
            recruitedHeroesWrapper.list.Add(selectedHero);

            // Сохраняем обновленный список
            PlayerPrefs.SetString("RecruitedHeroes", JsonUtility.ToJson(recruitedHeroesWrapper));
            PlayerPrefs.Save();

            // Перезагружаем сцену или обновляем интерфейс
            // SceneManager.LoadScene("RecruitedHeroesScene");
        }
    }
}

// Обертка для списка, необходимая для сериализации
[System.Serializable]
public class ListWrapper<T>
{
    public List<T> list = new List<T>();
}
