using UnityEngine;
using System;


public class TowerLifeLoop : MonoBehaviour {

    #region Характеристики
    //Скорость поворота турели
    public int RotationSpeed = 100;
    //Скорость спавна пуль
    public float SpeedLevel=50;
    #endregion



  
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
        if (((x - xCenter) * (x - xCenter) + (z - zCenter)) <= Radius * Radius)
            return true;


        return false;
    }

    /// <summary>
    /// Метод создания снаряда
    /// </summary>
    void createBullet()
    {
         var bullet = Instantiate(Resources.Load("FireBall") as GameObject);
       // if (bullet != null)
          //  bullet.transform.position = transform.FindChild("BulletSpawn").position;
          //bullet.GetComponent<BulletBehavior>().Speed = 50;
    }
	
	// Update is called once per frame
	void Update () {

        _target = FindObjectOfType<PigMove>();
        if (_target != null && !_target.IsDead)
        {
            if(mobDetected(_target.transform.position.x, _target.transform.position.z, _target))
            {
                var bullet = Instantiate(Resources.Load("FireBall") as GameObject);
                bullet.transform.position = transform.FindChild("BulletSpawn").position;
            }
        }
     

    }
}
