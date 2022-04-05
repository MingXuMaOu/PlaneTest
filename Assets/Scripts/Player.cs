using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float m_speed = 1;
    protected Transform m_transform;
    public Transform m_rocket;
    public float m_rockTimer = 0;
    public float m_life = 3;
    public AudioClip m_shootClip;
    protected AudioSource m_audio;
    public Transform m_explosionFX;
    
    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.transform;
        m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveev = 0;
        float moveeh = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveev += m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveev -= m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveeh -= m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveeh += m_speed * Time.deltaTime;
        }
        m_transform.Translate(new Vector3(moveeh, 0, moveev));

        m_rockTimer -= Time.deltaTime;
        if (m_rockTimer <= 0)
        {
            m_rockTimer = 0.1f;
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                Instantiate(m_rocket, m_transform.position, m_transform.rotation);
                m_audio.PlayOneShot(m_shootClip);
            }

        }
  

        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "PlayerRocket")
        {
            m_life -= 1;
            if(m_life <= 0)
            {
                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

}
