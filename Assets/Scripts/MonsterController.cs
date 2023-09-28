using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField]
    float leftLimit;

    [SerializeField]
    float rightLimit;

    [SerializeField]
    float bottomLimit;

    [SerializeField]
    float upperLimit;



    public float moveSpeed = 10f; // �������� �����������
    private Transform target; // �����

    Rigidbody m_Rigidbody;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // �������� �� ��������� ������  
   /*     if (Vector3.Distance(transform.position, target.position) < 2)
        {
            // ���� ����� ��������� � ���� ���������, ������ �������� ��������� � ����  
            transform.LookAt(target);
            Vector3 moveDir = transform.forward * moveSpeed * Time.deltaTime;
            m_Rigidbody.MovePosition(transform.position + moveDir);
        }*/
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, upperLimit), new Vector2(rightLimit, bottomLimit));

    }
}