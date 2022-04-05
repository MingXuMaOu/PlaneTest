using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemy : Enemy
{
    public Transform m_rocket;
    protected float m_fireTimer = 0.5f;
    protected Transform m_player;
 

    protected override void UpdateMove()
    {
        m_fireTimer -= Time.deltaTime;
        if(m_fireTimer <= 0)
        {
            m_fireTimer = 0.5f;
            if (m_player != null)
            {
                Vector3 relatvicePos = m_player.position - transform.position;
                Instantiate(m_rocket, transform.position, Quaternion.LookRotation(relatvicePos));
            }
            else
            {
                GameObject obj = GameObject.FindGameObjectWithTag("Player");
                if(obj != null)
                {
                    m_player = obj.transform;
                }
            }
        }




        transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }
}
