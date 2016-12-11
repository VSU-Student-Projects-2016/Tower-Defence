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
            WaveNum = value;
            _maxMobCount = Spawn.WavesCount[value];
            MobCount = 0;
            WaveText.text = "Wave " + value.ToString() + "/"+_maxWave.ToString();
        }
    }

    public int MobCount
    {
        get { return _mobCount; }
        set
        {
            _mobCount = value;
            MobText.text = "Mobs: " + (_maxMobCount - _mobCount).ToString() + "/" + _maxMobCount.ToString();
        }
    }
    int _maxWave;
    int _maxMobCount = 0;
    public EnemySpawnScript Spawn;
	// Use this for initialization
	void Start () {
        _maxWave = Spawn.WavesCount.Length;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
