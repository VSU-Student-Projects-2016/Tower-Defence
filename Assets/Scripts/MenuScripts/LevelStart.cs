using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelStart : MonoBehaviour {

    /// <summary>
    /// На какой уровень переходим
    /// </summary>
    public int level;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonClick()
    {
        SceneManager.LoadScene(level);
    }
}
