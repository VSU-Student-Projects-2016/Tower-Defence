using UnityEngine;
using System.Collections;

public class FinishScript : MonoBehaviour
{
    /// <summary>
    /// Характеристики игрока, нужно, чтобы вытащить хп
    /// </summary>
    PlayerStats _player;

    EnemySpawnScript scr;
    // Use this for initialization
    void Start()
    {
        _player = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        scr = FindObjectOfType<EnemySpawnScript>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        Debug.Log(_player);
        if (other.GetComponent<PigMove>()!=null)
        {
            Destroy(other.gameObject, 2.0f);
            _player.ChangeLives--;
            scr.MobCount--;
        }
    }
}
