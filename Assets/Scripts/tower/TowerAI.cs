using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerAI : MonoBehaviour {

    public GameObject[] targets; //массив всех целей
    public GameObject curTarget;
    public float towerPrice = 100.0f;
    public float attackMaximumDistance = 50.0f; //дистанция атаки
    public float attackMinimumDistance = 5.0f;
    public float attackDamage = 10.0f; //урон
    public float reloadTimer = 0.5f; //задержка между выстрелами, изменяемое значение
    public float reloadCooldown = 2.5f; //задержка между выстрелами, константа
    public float rotationSpeed = 1.5f; //множитель скорости вращения башни
    public int FiringOrder = 1; //очередность стрельбы для стволов (у нас же их 2)
    public Transform turretHead;

    public RaycastHit Hit;


    // Use this for initialization
    void Start () {
        turretHead = transform.FindChild("Head");
    }
	
	// Update is called once per frame
	void Update () {
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
                    var bullet = Instantiate(Resources.Load("FireBall") as GameObject);
                    bullet.transform.position = turretHead.transform.position;
                    //bullet.GetComponent<BulletBehavior>().Speed = 50;
                    Debug.Log("Выстрел!");

                    Debug.Log("Переменная distance = " + distance.ToString());
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

