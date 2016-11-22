using UnityEngine;
using System.Collections;

public class FinishScript : MonoBehaviour {
    /// <summary>
    /// Характеристики игрока, нужно, чтобы вытащить хп
    /// </summary>
    PlayerStats _player;

	// Use this for initialization
	void Start () {
        _player = FindObjectOfType<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        Debug.Log(_player);
        if (other.GetComponent<PigMove>())
        {
            Destroy(other.gameObject, 2.0f);
            _player.ChangeLives--;
        }
    }
}
