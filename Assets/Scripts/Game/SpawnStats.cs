using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnStats : MonoBehaviour {

    /// <summary>
    /// Текст текущей волны
    /// </summary>
    public Text WaveText;
    /// <summary>
    /// Текст количества оставшихся мобов
    /// </summary>
    public Text MobText;

    /// <summary>
    /// Номер волны
    /// </summary>
    int _waveNum;
    /// <summary>
    /// Количество оставшихся мобов
    /// </summary>
    int _mobCount;

    public int WaveNum
    {
        get
        {
            return _waveNum;
        }
        set
        {
            _waveNum = value;
            MobCount = 0;
            Debug.Log(_waveNum);
            Debug.Log("");
            Debug.Log(MaxWave);

            WaveText.text = "Wave " + _waveNum.ToString() + "/"+MaxWave.ToString();
        }
    }

    public int MobCount
    {
        get { return _mobCount; }
        set
        {
            if (MaxMobCount == 0)
                MobText.text = "Mobs: 0";

            _mobCount = value;
            MobText.text = "Mobs: " + (_maxMobCount - _mobCount).ToString() + "/" + _maxMobCount.ToString();
        }
    }

    public int MaxMobCount
    {
        get { return _maxMobCount; }
        set
        {
            _maxMobCount = value;
            MobText.text = "Mobs: " + (_maxMobCount - _mobCount).ToString() + "/" + _maxMobCount.ToString();
        }
    }
    public int  MaxWave;
    int _maxMobCount = 0;
    public EnemySpawnScript Spawn;
	// Use this for initialization
	void Start () {
        MaxWave = Spawn.WavesCount.Length;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
