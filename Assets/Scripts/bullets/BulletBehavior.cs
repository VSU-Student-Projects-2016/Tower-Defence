using UnityEngine;
using System;
using System.Collections;

public class BulletBehavior : MonoBehaviour
{
    
    /// <summary>
    /// Скорость полета пули
    /// </summary>
    float speed;
    /// <summary>
    /// Урон
    /// </summary>
    int damage;
    /// <summary>
    /// Моб. В момент обнаружения моба башней в зоне поражения, она создает фаербол
    /// и указывает ему цель.
    /// </summary>
    /// 
    string debuffTitle;//название дебафа
    float debufftime;//продолжительность -1 - пока не умрет
    GameObject target;
    Rigidbody _rigidBody;

    public GameObject Target
    {
        set { target = value; }
    }
    public float Speed
    {
        set { speed = value; }
    }

    public int Damage
    {
        set { damage = value; }
    }
    public string DebuffTitle
    {
        set { debuffTitle = value; }
    }
    public float Debufftime
    {
        set { debufftime = value; }
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
        _rigidBody.AddForce(direction * speed, ForceMode.VelocityChange);


    }

    /// <summary>
    /// проверка на негативный эффект у моба
    /// </summary>
    /// <param name="_debuffName">Название дебафа</param>
    /// <param name="_target">носитель</param>
    /// <returns></returns>
    bool isDebuff(string _debufName, GameObject _target)
    {
        if (_target.GetComponent(_debufName) != null)
            return true;
        return false;
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

            
            if (!mob.IsDead)
            {

                switch (debuffTitle)
                {
                    case "Burn":
                        {
                            if(!isDebuff(debuffTitle, target))
                            {
                                mob.gameObject.AddComponent<Burn>();
                                mob.gameObject.GetComponent<Burn>().init(target,debufftime);
                            }
                            break;
                        }
                    case "Freeze":
                        {
                            if (!isDebuff(debuffTitle, target))
                            {
                                mob.gameObject.AddComponent<Freeze>();
                                mob.gameObject.GetComponent<Freeze>().init(target, debufftime);
                            }
                            break;
                        }
                    case "ShadowStroke":
                        {
                            if (!isDebuff(debuffTitle, target))
                            {
                                mob.gameObject.AddComponent<ShadowStroke>();
                                mob.gameObject.GetComponent<ShadowStroke>().init(target, debufftime);
                            }
                            else
                                damage *= 2;
                            break;
                        }
                    default:  break;
                }

            }

            mob.HP -= damage;
            Debug.Log(mob.HP);
        }
        Destroy(gameObject);
    }


}
