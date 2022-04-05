using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    internal Renderer m_renderer;
    internal bool m_isActive = false;
    public float m_speed = 1;
    public float m_life = 10;
    public float m_rotSpeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
    }

    private void OnBecameVisible()
    {
        m_isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
        if(m_isActive && !this.m_renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }
    protected virtual void UpdateMove()
    {
        float rx = Mathf.Sin(Time.time) * Time.deltaTime;
        transform.Translate(new Vector3(rx, 0, -m_speed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("≤‚ ‘");
        if (other.tag == "PlayerRocket")
        {
            
            Rocket rocket = other.GetComponent<Rocket>();
            if(rocket != null)
            {
                m_life -= rocket.m_power;
                if(m_life <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }else if(other.tag == "Player")
        {
            m_life = 0;
            Destroy(gameObject);
        }
    }
}
