using UnityEngine;

[System.Serializable]
public class Character
{
    public string name; // ��� ���������
    public string rank; // ���� ��������� ("S", "A", "B", "C", "D")
    public int hp;      // �������� ���������
    public int damage;  // ���� ���������

    // ����������� ��� �������� ���������
    public Character(string name, string rank, int hp, int damage)
    {
        this.name = name;
        this.rank = rank;
        this.hp = hp;
        this.damage = damage;
    }
}
