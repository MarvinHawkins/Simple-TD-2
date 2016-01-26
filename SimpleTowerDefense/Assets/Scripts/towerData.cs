using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class towerLevel
{
    

}

public class towerData : MonoBehaviour {

    public int cost;
    public GameObject appearance; //Determines how t he unit looks
    public float range; //how far can the unit see?
    public List<towerLevel> levels;
    private towerLevel currentLevel;

    void OnEnable()
    {
        currentLevel = levels[0];
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
