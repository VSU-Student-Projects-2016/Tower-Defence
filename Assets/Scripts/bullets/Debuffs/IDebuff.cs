using UnityEngine;
using System.Collections;


public interface IDebuff {

    /// <summary>
    /// Применение дебафа к цели
    /// </summary>
    /// <param name="_target">цель</param>
    /// <param name="_time">время действия дебафа</param>
    void init(GameObject _target, float _time);

}
