﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Rigidbody m_rigid;
    float m_fRandMin = -7;
    float m_fRandMax = 7;
    public float m_fReward = 0;

    void Awake() {
        m_rigid = gameObject.GetComponent<Rigidbody>();
    }	

    void Init() {
        transform.position = Vector3.up * 8;
        m_rigid.velocity = Vector3.zero;
        Vector3 v = new Vector3(Random.Range(m_fRandMin, m_fRandMax), Random.Range(m_fRandMin, m_fRandMax), Random.Range(m_fRandMin, m_fRandMax));
        m_rigid.AddForce(v, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
        if( transform.position.y < -1) {
            Init();
            if(m_fReward <= 0)
            {
                m_fReward = -0.01f;
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Paddle"))
            m_fReward = 1;
    }
}
