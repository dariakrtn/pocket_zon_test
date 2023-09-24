using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // ���������� ��� ������ ��������
    [Header("Health stats")]
    [SerializeField] private float healthMaxValue = 100; // ������������ �������� ��������
    private float currentHealth; // ������� �������� ��������

    public event Action<float> HealthUpdate;

    // �������� ���������� ��������
    [SerializeField] public const int damagePerSecond = 20; // ���� � �������

    private void Start()
    {
        currentHealth = healthMaxValue; // ������������� ��������� ��������
    }

    void Update()
    {
        // ��������� ��������, ���� �������� �������� ����
        /*if (currentHealth > 0)
        {
            currentHealth -= damagePerSecond * Time.deltaTime; // ��������� �������� ������ �������
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




    // ����� ��� ��������� �������� �������� ��������


    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // ����� ��� �������������� ��������
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

    // ����� ��� ���������� ��������
    public void Damage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // �����, ���������� ��� ������ ���������
    void Die()
    {
        HealthUpdate?.Invoke(0);
        Debug.Log("YOU ARE DEATH");
        Destroy(gameObject); // ���������� ������ ���������
    }
}
