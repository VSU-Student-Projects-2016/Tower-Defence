using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TowerAI : MonoBehaviour
{

    public GameObject[] targets; //массив всех целей
    public GameObject curTarget;
    public float towerPrice = 100.0f;
    public float attackMaximumDistance; //дистанция атаки
    public float attackMinimumDistance;
    public int attackDamage; //урон
    public float bulletSpeed; //скорость снаряда
    public float reloadTimer; //задержка между выстрелами, изменяемое значение
    public float reloadCooldown; //задержка между выстрелами, константа
    public bool Debuff = false;
    public string DebuffTitle;//название дебафа
    public float Debufftime;//продолжительность негативного эффекта
    float rotationSpeed = 1.5f; //множитель скорости вращения башни
    public string bulletType;
    Transform turretHead;
    
    public RaycastHit Hit;


    // Use this for initialization
    void Start()
    {
        turretHead = transform.FindChild("Head");
    }

    // Update is called once per frame
    void Update()
    {
        curTarget = SortTargets();
        if (curTarget != null && !curTarget.GetComponent<PigMove>().IsDead) //если переменная текущей цели не пустая
        {
            float distance = Vector3.Distance(turretHead.position, curTarget.transform.position); //меряем дистанцию до нее
            if (attackMinimumDistance < distance && distance < attackMaximumDistance) //если дистанция больше мертвой зоны и меньше дистанции поражения пушки
            {
                turretHead.rotation = Quaternion.Slerp(turretHead.rotation, Quaternion.LookRotation(curTarget.transform.position - turretHead.position), rotationSpeed * Time.deltaTime); //вращаем башню в сторону цели
                if (reloadTimer > 0) reloadTimer -= Time.deltaTime; //если таймер перезарядки больше нуля - отнимаем его
                if (reloadTimer < 0) reloadTimer = 0; //если он стал меньше нуля - устанавливаем его в ноль
                if (reloadTimer == 0) //став нулем
                {
                    //получаем цель
                    PigMove target = curTarget.GetComponent<PigMove>();
                    //создаем огненный шар(т.к. башня стихии огня).
                    var bullet = Instantiate(Resources.Load(bulletType) as GameObject);
                    bullet.transform.position = turretHead.transform.position;
                    //цель
                    var bulletComponent = bullet.GetComponent<BulletBehavior>();
                    bulletComponent.Target = curTarget;
                    bulletComponent.Speed = bulletSpeed;
                    bulletComponent.Damage = attackDamage;
                    bulletComponent.DebuffTitle = DebuffTitle;
                    bulletComponent.Debufftime = Debufftime;
                    bulletComponent.Debuff = Debuff;


                    reloadTimer = reloadCooldown; //возвращаем переменной задержки её первоначальное значение из константы

                }
            }

        }

    }

    /// <summary>
    /// Очень примитивный метод сортировки целей
    /// </summary>
    /// <returns></returns>
    public GameObject SortTargets()
    {
        float closestMobDistance = 0; //инициализация переменной для проверки дистанции до моба
        GameObject nearestmob = null; //инициализация переменной ближайшего моба
        GameObject[] sortingMobs = GameObject.FindGameObjectsWithTag("Monster"); //находим всех мобов с тегом Monster и создаём массив для сортировки


        foreach (var everyTarget in sortingMobs) //для каждого моба в массиве
        {
            //если дистанция до моба меньше, чем closestMobDistance или равна нулю
            if ((Vector3.Distance(everyTarget.transform.position, this.transform.position) < closestMobDistance) || closestMobDistance == 0)
            {
                closestMobDistance = Vector3.Distance(everyTarget.transform.position, turretHead.position); //Меряем дистанцию от моба до пушки, записываем её в переменную
                nearestmob = everyTarget;//устанавливаем его как ближайшего
            }
        }
        return nearestmob; //возвращаем ближайшего моба
    }
}

