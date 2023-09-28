using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab; // Монстр prefab
    public GameObject monsterPrefab2; // Монстр prefab
    public Transform[] spawnPoints; // Массив точек спавна
    public int numberOfMonsters = 3; // Количество монстров для спавна

    private void Start()
    {
        // Создаем монстров
        for (int i = 0; i < numberOfMonsters; i++)
        {
            // Генерируем случайную точку спавна из массива
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
            // Создаем монстра в этой точке
            
        }
    }
}