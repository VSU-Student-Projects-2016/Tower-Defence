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
        tower.transform.FindChild("MagicTower").GetComponent<TowerAI>().Debuff = true;
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
