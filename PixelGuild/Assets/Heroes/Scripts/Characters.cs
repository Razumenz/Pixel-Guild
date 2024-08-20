using UnityEngine;

[System.Serializable]
public class Character
{
    public string name; // Имя персонажа
    public string rank; // Ранг персонажа ("S", "A", "B", "C", "D")
    public int hp;      // Здоровье персонажа
    public int damage;  // Урон персонажа

    // Конструктор для создания персонажа
    public Character(string name, string rank, int hp, int damage)
    {
        this.name = name;
        this.rank = rank;
        this.hp = hp;
        this.damage = damage;
    }
}
