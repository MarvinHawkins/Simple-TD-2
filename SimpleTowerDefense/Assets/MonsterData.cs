using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]

public class MonsterLevel
{
    //Stores class and other info
    public int cost;
    public GameObject visualization;
}

public class MonsterData : MonoBehaviour {

    public List<MonsterLevel> levels;
    private MonsterLevel currentLevel;

    void OnEnable()
    {
        CurrentLevel = levels[0];
    }

    public MonsterLevel CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);

            GameObject leveVisualization = levels[currentLevelIndex].visualization;
               for(int i=0; i<levels.Count; i++)  
                if(leveVisualization != null)
                {
                    if (i == currentLevelIndex)
                    {
                        levels[i].visualization.SetActive(true);
                    }
                    else
                    {
                        levels[i].visualization.SetActive(false);
                    }

                    }
                }

        }
    
   public MonsterLevel getNextLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        int maxLeveIndex = levels.Count - 1;
        if( currentLevelIndex < maxLeveIndex)
        {
            return levels[currentLevelIndex + 1];
        }
        else
        {
            return null;
        }
    }

    public void increaseLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel); //set current level to the level of the tower
        if(currentLevelIndex < levels.Count - 1)
        {
            CurrentLevel = levels[currentLevelIndex + 1];
        }
    }

  
    }