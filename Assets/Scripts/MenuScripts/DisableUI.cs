using UnityEngine;
using System.Collections.Generic;

public class DisableUI : MonoBehaviour {

    public List<GameObject> ToDisable;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DisableAll ()
    {
        foreach (GameObject obj in ToDisable)
            obj.SetActive(false);
    }
}
