using UnityEngine;
using System.Collections;



public class Monster : MonoBehaviour {

    public GameObject monsterPrefab;
    private GameObject monster;

     private bool canPlaceMonster()
    {
        return monster == null;
    }

    void OnMouseUp()
    {
        if (canPlaceMonster())
        {
            Instantiate(monsterPrefab, transform.position, Quaternion.identity);

            AudioSource audiosource = gameObject.GetComponent<AudioSource>();
            audiosource.PlayOneShot(audiosource.clip);
        }

    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
