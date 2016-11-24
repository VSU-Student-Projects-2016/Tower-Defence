using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

    /// <summary>
    /// Кого и сколько спавним
    /// </summary>
    public GameObject[] Enemies;

    /// <summary>
    /// С какой частотой спавним
    /// </summary>
    public float SpawnRate;

    /// <summary>
    /// Текущий номер моба, которого спавним
    /// </summary>
    private int _index;

    const float _radius = 7.0f;

    /// <summary>
    /// Спавним следующего моба
    /// </summary>
    void SpawnNext()
    {
        if (_index < Enemies.Length)
        {
            Vector3 pos = new Vector3(transform.position.x + Random.Range(-_radius, _radius), transform.position.y, transform.position.z);
            GameObject enemy = Instantiate(Enemies[_index], pos, Quaternion.identity) as GameObject; 
            enemy.transform.rotation = transform.rotation;
            ++_index;
        }
    }

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnNext", 3, SpawnRate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
