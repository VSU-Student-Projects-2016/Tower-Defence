using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerStats : MonoBehaviour {

    #region Статы
    /// <summary>
    /// Количество денег
    /// </summary>
    public int Gold;
    /// <summary>
    /// Сколько денег прибавляется в секунду
    /// </summary>
    public int IncomeSpeed;
    /// <summary>
    /// Где отображаются деньги
    /// </summary>
    public Text MoneyText;
    /// <summary>
    /// Количество жизней
    /// </summary>
    public int Lives;
    /// <summary>
    /// где отображаются жизни
    /// </summary>
    public Text LiveText;
    /// <summary>
    /// Текст, отображающийся при проигрыше. ДУмаю, стоит сделать отдельную сцену для этого, но пока так.
    /// </summary>
    public Text GameOverText;
    #endregion;


    /// <summary>
    /// Действия при проигрыше
    /// </summary>
    void GameOver()
    {
        GameOverText.enabled = true;
        Time.timeScale = 0; //Останавливает время
    }
    /// <summary>
    /// Свойство помогает изменит отображение жизней
    /// </summary>
    public int ChangeLives
    {
        get { return Lives; }
        set
        {
            Lives = value;
            LiveText.text = "Lives: " +Lives.ToString();
            if (Lives <= 0)
                GameOver();
        }
    }

    /// <summary>
    /// Свойство помогает изменит отображение жизней
    /// </summary>
    public int ChangeGold
    {
        get { return Gold; }
        set
        {
            Gold = value;
            try
            {
                MoneyText.text = "Gold: " + Gold.ToString();
            }
            catch (NullReferenceException e)
            { }
        }
    }

    /// <summary>
    /// Прибавляем деньги каждую единицу времени
    /// </summary>
    void IncreaseGold()
    {
        ChangeGold++;
    }

    // Use this for initialization
    void Start () {
        try
        {
            GameOverText.enabled = false; //Почему-то тут иногда надпись в нулл, чет странно. Поэтому обернул в try/catch
        }
        catch (NullReferenceException) { }
        InvokeRepeating("IncreaseGold", 0, Time.deltaTime * IncomeSpeed);
	}
	
	// Update is called once per frame
	void Update () {

    }
}
