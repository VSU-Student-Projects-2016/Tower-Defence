using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
    /// <summary>
    /// Скорость полета пули
    /// </summary>
    public float Speed = 50;

    /// <summary>
    /// Моб, в которого стреляем
    /// </summary>
    PigMove _target;
	// Use this for initialization
	void Start () {
        _target = FindObjectOfType<PigMove>();
        Destroy(gameObject, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
        //Если есть враг
        if (_target != null)
        {
            //пуляем во врага
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, Time.deltaTime * Speed);
            //Как только попадание засчитано, наносим дамаг и уничтожаем саму пулю
            if (Vector3.Distance(transform.position, _target.transform.position) < 0.5f)
            {
                _target.HP -= 100;
                Destroy(gameObject);
                Debug.Log(_target.HP);
            }
        }
	}
}
