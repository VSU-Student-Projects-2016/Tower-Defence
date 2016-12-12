using UnityEngine;
using System;
using System.Collections;

public class BulletBehavior : MonoBehaviour
{
    /// <summary>
    /// Скорость полета пули
    /// </summary>
    public float Speed = 5000;
    /// <summary>
    /// Моб, в которого стреляем
    /// </summary>
    public string NameTower;
    /// <summary>
    /// Урон
    /// </summary>
    public int Damage = 100;
    /// <summary>
    /// Моб. В момент обнаружения моба башней в зоне поражения, она создает фаербол
    /// и указывает ему цель.
    /// </summary>
    GameObject target;
    Rigidbody _rigidBody;

    public GameObject Target
    {
        set { target = value; }
    }


    void Start()
    {

        if (target != null)                    //ДОБАВИЛ ТУТ ПРОВЕРКУ, ЧТОБ ЭКСЕПШЕНАМИ НЕ ПЛЕВАЛАСЬ
            Destroy(gameObject, 3.0f);
        else
        {
            Destroy(gameObject);
            return;
        }


        ///Тут и далее - попытка сделать физику полета снаряда
        _rigidBody = GetComponent<Rigidbody>();
        var heading = target.transform.position - this.transform.position; //вектор расстояния между мобом и снарядом
        var distance = heading.magnitude; //само расстояние
        var direction = heading / distance; //единичный вектор направления
        _rigidBody.AddForce(direction * Speed, ForceMode.VelocityChange);


    }


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
