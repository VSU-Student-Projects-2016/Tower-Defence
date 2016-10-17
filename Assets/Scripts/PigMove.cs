using UnityEngine;
using System.Collections;

public class PigMove : MonoBehaviour {

    /// <summary>
    /// Путь движения моба
    /// </summary>
    public GameObject[] Targets;
    /// <summary>
    /// Скорость поворота
    /// </summary>
    public float RotationSpeed;
    /// <summary>
    /// Скорость движения
    /// </summary>
    public float MovingSpeed;
    /// <summary>
    /// Пункты жизни моба
    /// </summary>
    public float HP = 500f;

    /// <summary>
    /// индекс цели, к которой моб направляется в данный момент
    /// </summary>
    private int _currTarget = 0;
    /// <summary>
    /// Совершает ли моб в данный момент поворот
    /// </summary>
    private bool _rotating = false;
    /// <summary>
    /// Живой ли наш моб
    /// </summary>
    private bool _isDead = false;
	// Use this for initialization
	void Start () {
	
	}

    /// <summary>
    /// Поворот моба в сторону его цели
    /// </summary>
    void Rotate()
    {
        if (!_isDead)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Targets[_currTarget].transform.rotation, Time.deltaTime * RotationSpeed);
            MoveForward(0.7f);
        }
    }
    /// <summary>
    /// Движение вперед
    /// </summary>
    void MoveForward()
    {
        transform.position = Vector3.MoveTowards(transform.position, Targets[_currTarget].transform.position, Time.deltaTime * MovingSpeed);
    }
    /// <summary>
    /// Движение моба
    /// </summary>
    /// <param name="slow">на сколько замедляем</param>
    void MoveForward(float slow)
    {
        transform.position = Vector3.MoveTowards(transform.position, Targets[_currTarget].transform.position, Time.deltaTime * (MovingSpeed * slow));
    }

    /// <summary>
    /// Когда моб отъезжает
    /// </summary>
    void Die()
    {
        GetComponent<Animator>().SetBool("move-die", true);
        _isDead = true;
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update () {
        //Если не достиг цели и не поворачивает, движемся вперед
        if (!_isDead && _currTarget < Targets.Length && !_rotating)
            MoveForward();
        else
            //Если же поворачивает, совершаем поворот
            if (_rotating)
                if (Quaternion.Angle(transform.rotation, Targets[_currTarget].transform.rotation) > 0.5f) //до тех пор, пока моб не достигнет нужного угла
                    Rotate();
                else
                    _rotating = false; 

        //Когда достигаем триггера
        if (_currTarget < Targets.Length && Vector3.Distance(transform.position, Targets[_currTarget].transform.position) < 1.0f)
        {
            ++_currTarget; //говорим двигаться к следующему триггеру...
            if (_currTarget < Targets.Length)
                _rotating = true;//...при этом повернувшись в его сторону
        }

        //--HP;
        //Debug.Log(HP);


        //Как только хп кончились, пора подыхать
        if (!_isDead && HP<=0)
        {
            Die();
        }
    }

}
