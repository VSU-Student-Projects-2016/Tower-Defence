using UnityEngine;
using System.Collections;

public class BulletSpawn : MonoBehaviour {

    /// <summary>
    /// Скорость стрельбы
    /// </summary>
    public float SpawnSpeed=3.0f;

    /// <summary>
    /// Чем стреляем
    /// </summary>
    public GameObject Bullet;
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
        Instantiate(Bullet, transform.position, Quaternion.identity);
    }
}
