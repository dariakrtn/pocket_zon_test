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
    [SerializeField] public const int damagePerSecond = 20; // Урон в секунду

    private void Start()
    {
        currentHealth = healthMaxValue; // Устанавливаем начальное здоровье
    }

    void Update()
    {
        // Уменьшаем здоровье, если персонаж получает урон
        /*if (currentHealth > 0)
        {
            currentHealth -= damagePerSecond * Time.deltaTime; // Уменьшаем здоровье каждую секунду
        }*/

        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeHealth(-damagePerSecond);
        }
    }

    private void ChangeHealth(int value)
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




    // Метод для получения текущего значения здоровья


    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // Метод для восстановления здоровья
    public void Heal(float amount)
    {
        if (currentHealth < healthMaxValue)
        {
            currentHealth += amount;
            if (currentHealth > healthMaxValue)
            {
                currentHealth = healthMaxValue;
            }
        }
    }

    // Метод для уменьшения здоровья
    public void Damage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Метод, вызываемый при смерти персонажа
    void Die()
    {
        HealthUpdate?.Invoke(0);
        Debug.Log("YOU ARE DEATH");
        Destroy(gameObject); // Уничтожаем объект персонажа
    }
}
