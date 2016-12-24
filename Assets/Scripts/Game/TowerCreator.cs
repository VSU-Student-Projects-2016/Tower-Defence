using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TowerCreator : MonoBehaviour {

    /// <summary>
    /// Какую башню ставим(путь к ней)
    /// </summary>
    public string TowerPath;
    /// <summary>
    /// Сколько эта башня стоит
    /// </summary>
    public int TowerCost;
    public GameObject UpgradeWindow;
    public bool OpenWindow = false;
    /// <summary>
    /// игрок, нужен, чтобы отнимать золото за поставленные башни
    /// </summary>
    public PlayerStats Player;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindObjectOfType<PlayerStats>();
	}
	
	/// <summary>
    /// Расстановка башни по клику (!!!!НЕ ХВАТАЕТ ВАЛИДАЦИИ МЕСТА!!!!!)
    /// </summary>
	void Update ()
    {
        if(!OpenWindow)
            if (Input.GetMouseButtonDown(0) || Input.touchCount != 0) //если произведен клик (либо тач, но тут не факт, что работает)
            {
                if (EventSystem.current.IsPointerOverGameObject()) //проверка на то, что мы находимся не над менюхой
                    return;

                RaycastHit hit; //Создаем луч
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) //если удалось скастить луч
                {
                    /*if (hit.collider.name != "Terrain")  //Если
                        return;*/
                    if (hit.collider.name.Contains("PlaceForTower") && Player.Gold>=TowerCost && TowerPath!="") //Если кликнули на 
                    {
                       
                        
                            Vector3 pointPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                            Quaternion q;
                            q = Quaternion.identity;
                            
                            GameObject tower = Instantiate(Resources.Load(TowerPath), pointPosition, q) as GameObject; //Загружаем нужную башню и ставим ее
                                                                                                                       //  if(tower.GetComponent<BoxCollider>().)

                            int towerPrice = (int)tower.transform.Find("MagicTower").GetComponent<TowerAI>().towerPrice;

                        if (Player.Gold >= towerPrice)
                            Player.Gold -= (int)tower.transform.Find("MagicTower").GetComponent<TowerAI>().towerPrice;
                        else
                            Destroy(tower);
                        
                    }
                    else if (hit.collider.tag.Contains("Tower")) //Если кликнули на 
                    {
                        //TowerAI tower = hit.collider.gameObject.transform.FindChild("MagicTower").GetComponent<TowerAI>();
                        //UpgradeWindow.GetComponent<UpgradeWinBehaviour>().Tower = tower;
                        UpgradeWindow.GetComponent<UpgradeBehaviour>().Tower = hit.collider.gameObject;
                        UpgradeWindow.SetActive(true);
                        Time.timeScale = 0;
                        OpenWindow = true;
                    }
                }
           
            }
	}
}
