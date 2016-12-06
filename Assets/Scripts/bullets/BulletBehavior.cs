using UnityEngine;
using System;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
    /// <summary>
    /// Скорость полета пули
    /// </summary>
    public float Speed = 5000;
    /// <summary>
    /// Моб, в которого стреляем
    /// </summary>


    public int Damage=100;

    GameObject _target;
    Rigidbody _rigidBody;
    // Use this for initialization
    void Start () {


 
        _target = FindObjectOfType<TowerAI>().curTarget;
        if (_target != null)                    //ДОБАВИЛ ТУТ ПРОВЕРКУ, ЧТОБ ЭКСЕПШЕНАМИ НЕ ПЛЕВАЛАСЬ
            Destroy(gameObject, 3.0f);
        else
        {
            Destroy(gameObject);
            return;
        }


        ///Тут и далее - попытка сделать физику полета снаряда
        _rigidBody = GetComponent<Rigidbody>();
        var heading = _target.transform.position - this.transform.position; //вектор расстояния между мобом и снарядом
        var distance = heading.magnitude; //само расстояние
        var direction = heading/distance; //единичный вектор направления
        _rigidBody.AddForce(direction * Speed, ForceMode.VelocityChange);
        //transform.rotation = Quaternion.RotateTowards();

    }
	


    //ВЕРСИЯ БЕЗ ФИЗИКИ. РАССКОМЕНТИРУЙ, ЧТОБЫ ВЕРНУТЬ, КАК БЫЛО
    /*
	// Update is called once per frame
	void Update () {
        //Если есть враг
        if (trigger && _target!=null)
        {
            //пуляем во врага
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, Time.deltaTime * Speed);
            //Как только попадание засчитано, наносим дамаг и уничтожаем саму пулю
            if (Vector3.Distance(transform.position, _target.transform.position) < 0.5f)
            {
                _target.HP -= damage;
                Destroy(this.gameObject);
                Debug.Log(_target.HP);
            }
        }
        else
            Destroy(this.gameObject);
    } */

    void Update()
    {

    }

    /// <summary>
    /// Когда наша пуля во что-то попадает
    /// </summary>
    /// <param name="collision">Все сведения о попадании</param>
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider);
        PigMove mob = collision.gameObject.GetComponent<PigMove>(); //Ищем у того, куда попали, компонент моба
        Debug.Log(mob);

        if (mob != null) //если не нашли, уничтожаем пулю
        {
            mob.HP -= Damage;
            Debug.Log(mob.HP);
        }
        Destroy(gameObject);
    }


}
