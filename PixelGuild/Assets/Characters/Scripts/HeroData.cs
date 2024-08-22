using UnityEngine;

[CreateAssetMenu(fileName = "NewHero", menuName = "Hero")]
public class HeroData : ScriptableObject
{
    public string Name;
    public string rank;
    public int energy;
    public int level;
}
