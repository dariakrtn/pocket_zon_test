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
    public int damagePerSecond = 20; // ���� � �������

    [SerializeField] GameObject shmot;

    [SerializeField] GameObject g_over;

    private void Start()
    {
        currentHealth = healthMaxValue; // ������������� ��������� ��������
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


    // �����, ���������� ��� ������ ���������
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
