using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class TowerSwitcher : MonoBehaviour
{

    //Стоимости башен, какие-то дефолтные значения
    public int FireTowerCost = 0;
    public int IceTowerCost = 0;
    public int DarkTowerCost = 0;

    //Пути к соответствующим башням. ПЕРЕДЕЛАТЬ ПРИ ПЕРЕМЕЩЕНИИ БАШЕН
    string _fireTowerPath = "Towers/FireTower";
    string _iceTowerPath = "Towers/IceTower";
    string _darkTowerPath = "Towers/DarkTower";

    TowerCreator tc;
    // Use this for initialization
    void Start()
    {
        tc = GameObject.FindObjectOfType<TowerCreator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Переключение ставимой башни на MagicTower
    /// </summary>
    public void SwitchTomagicTower()
    {

        tc.TowerCost = FireTowerCost;
        tc.TowerPath = _fireTowerPath;
    }

    /// <summary>
    /// Переключение ставимой башни на MagicTower
    /// </summary>
    public void SwitchTomagicTower2()
    {
        tc.TowerCost = IceTowerCost;
        tc.TowerPath = _iceTowerPath;
    }
    /// <summary>
    /// Переключение ставимой башни на MagicTower
    /// </summary>
    public void SwitchTomagicTower3()
    {
        tc.TowerCost = DarkTowerCost;
        tc.TowerPath = _darkTowerPath;
    }
}
