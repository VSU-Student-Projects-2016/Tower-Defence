using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnScript : MonoBehaviour {

    /// <summary>
    /// Кого спавним
    /// </summary>
    public GameObject[] Enemies;

    /// <summary>
    /// По сколько мобов в волне
    /// </summary>
    public int[] WavesCount;

    /// <summary>
    /// С какой частотой спавним
    /// </summary>
    public float SpawnRate;

    /// <summary>
    /// Сколько мобов находится на карте на данный момент
    /// </summary>
    public int MobCount;

    /// <summary>
    /// Текущий номер моба, которого спавним
    /// </summary>
    private int _index;

    /// <summary>
    /// Радиус, в котором спавнятся мобы
    /// </summary>
    const float _radius = 7.0f;

    #region Волны
    /// <summary>
    /// Количестов мобов за одну волну
    /// </summary>
    public int MobsPerWave = 3;

    /// <summary>
    /// Номер волны
    /// </summary>
    public int WaveNumber = 0;
    /// <summary>
    /// Время между волнами
    /// </summary>
    public float TimeBetweenWaves = 3000.0f;
    /// <summary>
    /// Переменная для сброса таймера
    /// </summary>
    public float WaveCooldown = 3000.0f;

    /// <summary>
    /// Время между спавнами моба
    /// </summary>
    public float TimeBetweenMobSpawns=100.0f;
    float _timeBetweenMobSpawns; 
    /// <summary>
    /// для загрузки префаба
    /// </summary>
    public Transform Mob;
    /// <summary>
    /// Массив точек спавна
    /// </summary>
    public GameObject[] SpawnPoints;

    /// <summary>
    /// Индекс текущей волны
    /// </summary>
    public int CurrentWaveIndex=0;

    #endregion

    public SpawnStats Stats;
    /// <summary>
    /// Надпись о завершении уровня
    /// </summary>
    public GameObject CompletePanel;

    /// <summary>
    /// Спавним следующего моба
    /// </summary>
    void SpawnNext()
    {
        Vector3 pos = new Vector3(transform.position.x + Random.Range(-_radius, _radius), transform.position.y, transform.position.z);
        _index = Random.Range(0, Enemies.Length); //TODO: Переделать, когда появятся еще мобы
        GameObject enemy = Instantiate(Enemies[_index], pos, Quaternion.identity) as GameObject; 
        enemy.transform.rotation = transform.rotation; //чтобы моб смотрел туда, куда смотрит спавн
        ++MobCount;
        Stats.MobCount++;
    }

    // Use this for initialization
    void Start()
    {
        MobCount = 0;
        Stats.WaveText.text = "Wave 0/" + WavesCount.Length.ToString();
        Stats.MaxWave = WavesCount.Length;
        Stats.MobText.text = "";
        _timeBetweenMobSpawns = TimeBetweenMobSpawns;
        TimeBetweenMobSpawns = 0;
        CurrentWaveIndex = -1; //до начала 1-й волны
        SpawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
    }

	// Update is called once per frame
	void Update ()
    {
        if (CurrentWaveIndex < WavesCount.Length)
            WaveSpawnLoop();
        else //if (MobCount <= 0)
            Invoke("LevelCompleted", 2);            
	}

    /// <summary>
    /// Действия, когда волны не закончились
    /// </summary>
    void WaveSpawnLoop ()
    {
        if (TimeBetweenWaves <= 0) //Если идет волна
        {
            if (TimeBetweenMobSpawns <= 0) ///Если надо заспавнить следующего моба
            {
                if (WavesCount[CurrentWaveIndex] == 0) //а таких не осталось
                {
                    TimeBetweenWaves = WaveCooldown; //то сбрасываем время волны
                    TimeBetweenMobSpawns = 0; //чтобы моб спавнился сразу после начала волны
                                              //WaveCooldown -= 10.0f; //Тут можно как-нибудь поменять время до следующей волны

                }
                else //иначе спавним
                {
                    SpawnNext();
                    WavesCount[CurrentWaveIndex]--;
                    TimeBetweenMobSpawns = _timeBetweenMobSpawns;//сбрасываем таймер спавна следующего моба
                }
            }
            else
                TimeBetweenMobSpawns -= Time.deltaTime; //Если моба спавнить не пора, уменьшаем время
            return;
        }

        if (TimeBetweenWaves > 0) //если же волна не идёт
        {
            TimeBetweenWaves -= Time.deltaTime;
            if (TimeBetweenWaves < 0)
            {
                CurrentWaveIndex++;
                Stats.MaxMobCount = (CurrentWaveIndex < WavesCount.Length ? WavesCount[CurrentWaveIndex] : 0);
                Stats.WaveNum = CurrentWaveIndex + 1;
            }
        }
    }

    void LevelCompleted ()
    {
        Time.timeScale = 0;
        CompletePanel.SetActive(true);
    }

}
