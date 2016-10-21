using UnityEngine;
using System;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
    /// <summary>
    /// Скорость полета пули
    /// </summary>
    public float Speed = 50;
    /// <summary>
    /// Моб, в которого стреляем
    /// </summary>
    bool trigger;
    PigMove _target;
    // Use this for initialization
    void Start () {


        trigger = FindObjectOfType<TowerLifeLoop>().trigger;
        _target = FindObjectOfType<TowerLifeLoop>()._target;
        Destroy(gameObject, 3.0f);

    }
	
	// Update is called once per frame
	void Update () {
        //Если есть враг
        if (trigger)
        {
            //пуляем во врага
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, Time.deltaTime * Speed);
            //Как только попадание засчитано, наносим дамаг и уничтожаем саму пулю
            if (Vector3.Distance(transform.position, _target.transform.position) < 0.5f)
            {
                _target.HP -= 100;
                Destroy(this.gameObject);
                Debug.Log(_target.HP);
            }
        }
        else
            Destroy(this.gameObject);
    }
}
