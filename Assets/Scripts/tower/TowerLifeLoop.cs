using UnityEngine;
using System;


public class TowerLifeLoop : MonoBehaviour {

    #region Характеристики
    //Скорострельность турели
    public float SpeedLavel;
    #endregion



    /// <summary>
    /// body - часть турели
    /// </summary>
    private Transform body;
    /// <summary>
    /// Зона поражения Боевой Турели
    /// </summary>
    public float Radius;
    /// <summary>
    /// Цель
    /// </summary>
    public PigMove _target;

    public bool trigger;



    // Use this for initialization
    void Start () {
        //Получили дочерний элемент Боевой Турели
        body = transform.Find("Body");

        InvokeRepeating("createBullet", 1.0f, Time.deltaTime * 50);
    }

    /// <summary>
    /// Поворт пушки на указанный угол
    /// </summary>
    /// <param name="angle">угол</param>
    void towerRotation()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _target.transform.rotation, Time.deltaTime * 100);
    }

    /// <summary>
    /// Ф-ция проверки на то, попадает ли моб в зону поражения Боевой Турели
    /// </summary>
    /// <param name="x">Ox</param>
    /// <param name="z">Oz</param>
    /// <returns></returns>
    bool mobDetected(float x, float z, PigMove _target)
    {

        //координаты центра окружности(центр башни)
        float xCenter = transform.position.x;
        float zCenter = transform.position.z;

        //точка принадлежит окружности
        if (((x - xCenter) * (x - xCenter) + (z - zCenter)) < Radius * Radius)
            return true;
        //точка лежит на окружности
        if (((x - xCenter) * (x - xCenter) + (z - zCenter)) == Radius * Radius)
            return true;

        return false;
    }

    /// <summary>
    /// Метод создания снаряда
    /// </summary>
    void createBullet()
    {
          var bullet = Instantiate(Resources.Load("FireBall") as GameObject);
          bullet.transform.position = body.Find("Gun").Find("barrel").transform.position;
          bullet.GetComponent<BulletBehavior>().Speed = 30;
    }
	
	// Update is called once per frame
	void Update () {

        _target = FindObjectOfType<PigMove>();
        if (_target != null && !_target.IsDead)
        {
            towerRotation();
            trigger = mobDetected(_target.transform.position.x, _target.transform.position.z, _target);
        }
        else
            trigger = false;


 


    }
}
