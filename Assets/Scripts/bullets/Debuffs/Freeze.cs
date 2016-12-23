using UnityEngine;
using System.Collections;

public class Freeze : MonoBehaviour,IDebuff {

    float time;//время действия
    PigMove target;//цель
    float oldSpeed;//старая скорость
    GameObject deubugView;

    void Start()
    {
        oldSpeed = target.MovingSpeed;
        target.MovingSpeed /= 2;
        deubugView = Instantiate(Resources.Load("Debuffs/freeze") as GameObject);
        deubugView.transform.position = target.transform.position;
        deubugView.transform.parent = target.transform;
    }

    // Use this for initialization
    void Update()
    {

        time -= Time.deltaTime;


        if (time < 0 || target.IsDead)
        {
            target.MovingSpeed = oldSpeed;
            Destroy(deubugView, 0.2f);
            Destroy(this);
        }

    }

    public void init(GameObject _target, float _time)
    {
        target = _target.gameObject.GetComponent<PigMove>();
        time = _time;
    }
}
