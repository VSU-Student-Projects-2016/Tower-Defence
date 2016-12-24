using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeBehaviour : MonoBehaviour {

    GameObject tower;
    public GameObject Tower
    {
        set { tower = value; }
    }
    int countr = 1;
    public void Update()
    {
        if(tower != null)
        {
            if (tower.transform.FindChild("MagicTower").GetComponent<TowerAI>().Debuff)
                gameObject.transform.FindChild("AddDebuff").GetComponent<Button>().enabled = false;
            else
                gameObject.transform.FindChild("AddDebuff").GetComponent<Button>().enabled = true;
        }
    }

    public void addDebuff()
    {
        TowerAI towerAI = tower.transform.FindChild("MagicTower").GetComponent<TowerAI>();
        towerAI.Debuff = true;
        towerAI.gameObject.transform.Find("middleRing1").transform.Find("debuffUpdate").gameObject.SetActive(true);
    }
    /// <summary>
    /// Закрываем окно апгрейда
    /// </summary>
    public void CloseWindow()
    {
        gameObject.SetActive(false);
        FindObjectOfType<TowerCreator>().OpenWindow = false;
        Time.timeScale = 1;
    }


}
