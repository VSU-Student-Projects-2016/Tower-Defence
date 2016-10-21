using UnityEngine;
using System.Collections;
using System;


public class BulletSpawn : MonoBehaviour {

    /// <summary>
    /// Скорость стрельбы
    /// </summary>
    public float SpawnSpeed=3.0f;
    

    /// <summary>
    /// Чем стреляем
    /// </summary>
    private GameObject Bullet;
	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("RespawnBullet", 1.0f, Time.deltaTime*SpawnSpeed);
        
    }

    // Update is called once per frame
    void Update ()
    {
	}
    
    //Готовим новый выстрел
    void RespawnBullet()
    {
       // Bullet = Instantiate(Resources.Load("FireBall") as GameObject);  
    }
}
