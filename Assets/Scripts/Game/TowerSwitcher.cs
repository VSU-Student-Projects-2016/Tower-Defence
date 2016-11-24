using UnityEngine;
using System.Collections;

public class TowerSwitcher : MonoBehaviour {

    //Стоимости башен, какие-то дефолтные значения
    public int Ak630Cost = 0;
    public int MagicTowerCost = 0;

    //Пути к соответствующим башням. ПЕРЕДЕЛАТЬ ПРИ ПЕРЕМЕЩЕНИИ БАШЕН
    string _ak630Path = "Towers/AK630";
    string _magicTowerPath = "Towers/MagicTower";

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Переключение ставимой башни на AK630
    /// </summary>
    public void SwitchToAK630()
    {
        TowerCreator tc = GameObject.FindObjectOfType<TowerCreator>();
        tc.TowerCost = Ak630Cost;
        tc.TowerPath = _ak630Path;
    }

    /// <summary>
    /// Переключение ставимой башни на MagicTower
    /// </summary>
    public void SwitchTomagicTower()
    {
        TowerCreator tc = GameObject.FindObjectOfType<TowerCreator>();
        tc.TowerCost = MagicTowerCost;
        tc.TowerPath = _magicTowerPath;
    }
}
