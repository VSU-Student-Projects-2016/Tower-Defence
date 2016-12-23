﻿using UnityEngine;
using System.Collections;

public class ShadowStroke : MonoBehaviour,IDebuff {

    float time;//время действия
    PigMove target;//цель
    GameObject deubugView;

    void Start()
    {
        deubugView = Instantiate(Resources.Load("Debuffs/ShadowStroke") as GameObject);
        deubugView.transform.position = target.transform.position;
        deubugView.transform.parent = target.transform;
    }
    
    // Use this for initialization
    void Update()
    {

        time -= Time.deltaTime;


        if (time < 0 || target.IsDead)
        {
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
