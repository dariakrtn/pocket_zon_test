using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab; // ������ prefab
    public GameObject monsterPrefab2; // ������ prefab
    public Transform[] spawnPoints; // ������ ����� ������
    public int numberOfMonsters = 3; // ���������� �������� ��� ������

    private void Start()
    {
        // ������� ��������
        for (int i = 0; i < numberOfMonsters; i++)
        {
            // ���������� ��������� ����� ������ �� �������
            Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            if (i == 0)
            {
                GameObject monster = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
                monster.name = "Monster " + i;
            }
            else
            {

                GameObject monster = Instantiate(monsterPrefab2, spawnPosition, Quaternion.identity);
                monster.name = "Monster " + i;
            }
            // ������� ������� � ���� �����
            
        }
    }
}