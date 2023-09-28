using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Переменные для полосы здоровья
    [Header("Health stats")]
    [SerializeField] private float healthMaxValue = 100; // Максимальное значение здоровья
    private float currentHealth; // Текущее значение здоровья

    public event Action<float> HealthUpdate;

    // Скорость уменьшения здоровья
    public int damagePerSecond = 20; // Урон в секунду

    [SerializeField] GameObject shmot;

    [SerializeField] GameObject g_over;

    private void Start()
    {
        currentHealth = healthMaxValue; // Устанавливаем начальное здоровье
    }

    void Update()
    {


       /* if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeHealth(-damagePerSecond);
        }*/
    }

    public void ChangeHealth(int value)
    {
        currentHealth += value;

        if (currentHealth <= 0)
        {
            Die();

        }
        else
        {
            float currentHealthAsPercantage = (float)currentHealth / healthMaxValue;
            HealthUpdate?.Invoke(currentHealthAsPercantage);
        }
    }


    // Метод, вызываемый при смерти персонажа
    void Die()
    {
        if (gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
            g_over.SetActive(true);


        }
        else
        {
            Destroy(gameObject);
            GameObject items = Instantiate(shmot, transform.position, Quaternion.identity);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Cannon" )
        {
            ChangeHealth(-damagePerSecond);

        }

    }


    /*void OnCollisionEnter3D(Collision coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);

        }
        else
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
            GameObject items = Instantiate(shmot, coll.transform.position, Quaternion.identity);
        }
    }*/
}
