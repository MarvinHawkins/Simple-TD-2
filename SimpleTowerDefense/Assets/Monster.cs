using UnityEngine;
using System.Collections;



public class Monster : MonoBehaviour {

    public GameObject monsterPrefab;
    private GameObject monster;
    public GameManagerBehavior gameManager;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();

    }


    private bool canPlaceMonster()
    {
        int cost = monsterPrefab.GetComponent<MonsterData>().levels[0].cost;
        return monster == null && gameManager.Gold >= cost;
    }

    private bool canUpgradeMonster()
    {
        if (monster != null)
        {
           
            MonsterData monsterData = monster.GetComponent<MonsterData>();
            MonsterLevel nextLevel = monsterData.getNextLevel();

            if (nextLevel != null)
            {
                return gameManager.Gold >= nextLevel.cost;
            }

        }
        return false;
    }

    void OnMouseUp()
    {
        if (canPlaceMonster())
        {
           monster = (GameObject)
           Instantiate(monsterPrefab, transform.position, Quaternion.identity);

            AudioSource audiosource = gameObject.GetComponent<AudioSource>();
            audiosource.PlayOneShot(audiosource.clip);
            gameManager.Gold -= monster.GetComponent<MonsterData>().CurrentLevel.cost;
        }
         else if(canUpgradeMonster())
             {
             monster.GetComponent<MonsterData>().increaseLevel();
             AudioSource audioSource = gameObject.GetComponent<AudioSource>();
             audioSource.PlayOneShot(audioSource.clip);
             //ToDo Deduct gold
             gameManager.Gold -= monster.GetComponent<MonsterData>().CurrentLevel.cost;

         }
        
    }

   

  
	
	// Update is called once per frame
	void Update () {
	
	}
}
