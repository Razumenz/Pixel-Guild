[System.Serializable]
public class Hero
{
    public string Name;
    public string Rank;
    public int Energy;
    public int Level;

    public Hero(string name, string rank, int energy, int level)
    {
        Name = name;
        Rank = rank;
        Energy = energy;
        Level = level;
    }
}
