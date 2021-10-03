using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
   public List<GameObject> Levels;
   public int currentLevel;
   public GameObject activeLevel;
   public int highestUnlockedLevel;

   private GameTracker tracker;

   public bool FindLevelInScene;

   private void Awake()
   {
      tracker = gameObject.GetComponent<GameTracker>();
   }

   // Start is called before the first frame update
   void Start()
   {
      if (!FindLevelInScene)
      {
         ResetLevel();
      }
      else
      {
         activeLevel = GameObject.FindGameObjectWithTag("Level");
      }
   }

#if UNITY_EDITOR
   private void OnApplicationQuit()
   {
      foreach (Level l in GetLevels())
      {
         l.HighScore = 0;
      }
      
   }
#endif

   public void ResetLevel()
   {
      Destroy(activeLevel);
      Scorekeeper.Instance.ResetScore();
      activeLevel = Instantiate(Levels[currentLevel]);
      _currentLevel = null;
      tracker.LevelReset();
   }

   public void NextLevel()
   {
      ++currentLevel;
      ResetLevel();
   }
   public void PreviousLevel()
   {
      --currentLevel;
      ResetLevel();
   }

   public void LoadLevel(int levelToLoad)
   {
      currentLevel = levelToLoad;
      ResetLevel();
   }

   public List<Level> GetLevels()
   {
      return Levels.Select(go => go.GetComponent<Level>()).ToList();
   }
   public Level CurrentLevel
   {
      get
      {
         if(_currentLevel is null)
         {
            _currentLevel = activeLevel.GetComponent<Level>();
         }
         return _currentLevel;
      }
   }
   private Level _currentLevel;

   public int CurrentLevelHighScore
   {
      get
      {
         return Levels[currentLevel].GetComponent<Level>().HighScore;
      }
   }

   public void SaveScore()
   {
      if(Scorekeeper.Instance.Score > CurrentLevelHighScore)
      {
         Levels[currentLevel].GetComponent<Level>().HighScore = Scorekeeper.Instance.Score;
      }
   }

   public bool IsNextLevel
   {
      get
      {
         return currentLevel < Levels.Count -1;
      }
   }
   public bool NextLevelUnlocked
   {
      get
      {
         return highestUnlockedLevel > currentLevel;      
      }
   }
   public bool IsPreviousLevel
   {
      get
      {
         return currentLevel > 0;
      }
   }

   public bool IsLevelUnlocked(int level)
   {
      if(level < 0 || level >= Levels.Count)
      {
         return false;
      }
      return level <= highestUnlockedLevel;
   }

   public void UnlockNextLevel()
   {
      highestUnlockedLevel = currentLevel + 1;
   }

}
