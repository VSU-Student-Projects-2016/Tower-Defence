using UnityEngine;
using System.Collections;

public class TowerSwitcher : MonoBehaviour {

    //Стоимости башен, какие-то дефолтные значения
    public int Ak630Cost = 0;
    public int MagicTowerCost = 0;
    public int MagicTowerCost2 = 0;
    public int MagicTowerCost3 = 0;

    //Пути к соответствующим башням. ПЕРЕДЕЛАТЬ ПРИ ПЕРЕМЕЩЕНИИ БАШЕН
    string _magicTowerPath = "Towers/MagicTower";
    string _magicTowerPath2 = "Towers/MagicTower2";
    string _magicTowerPath3 = "Towers/MagicTower3";

    TowerCreator tc;
    // Use this for initialization
    void Start () {
        tc = GameObject.FindObjectOfType<TowerCreator>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Переключение ставимой башни на MagicTower
    /// </summary>
    public void SwitchTomagicTower()
    {
        tc.TowerCost = MagicTowerCost;
        tc.TowerPath = _magicTowerPath;
    }

    /// <summary>
    /// Переключение ставимой башни на MagicTower
    /// </summary>
    public void SwitchTomagicTower2()
    {
        tc.TowerCost = MagicTowerCost2;
        tc.TowerPath = _magicTowerPath2;
    }
    /// <summary>
    /// Переключение ставимой башни на MagicTower
    /// </summary>
    public void SwitchTomagicTower3()
    {
        tc.TowerCost = MagicTowerCost3;
        tc.TowerPath = _magicTowerPath3;
    }
}
