using UnityEngine;
using System.Collections;



public class Monster : MonoBehaviour {

    public GameObject monsterPrefab;
    private GameObject monster;
    public GameManagerBehavior gameManager;
	public GameObject buildPrefab;
	public GameObject buildPanel;



    // Use this for initialization
    void Start()
    {
		buildPanel = Instantiate(buildPrefab) as GameObject;
		gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
		buildPanel.SetActive(false); 

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
		buildPanel.SetActive(true);

		if (canPlaceMonster())
        {
			//buildPanel.SetActive(true);
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
