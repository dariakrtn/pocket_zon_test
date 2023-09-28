using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public GameObject m_projectilePrefabCannon;
    public Transform m_shootPointCannon;

    public void Exit_Game()
    {
        Application.Quit();
    }

    public void Attack_()
    {
        if (m_projectilePrefabCannon == null || m_shootPointCannon == null)
            return;

        Instantiate(m_projectilePrefabCannon, m_shootPointCannon.position, m_shootPointCannon.rotation);

    }
}
