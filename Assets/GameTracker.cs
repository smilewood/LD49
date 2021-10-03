using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTracker : MonoBehaviour
{
   LevelController level;
   public float speedLimit;
   public GameObject ScoreLevelButton;
   public LevelScorePanelBehavior LevelScoreUI;
   public PauseMenuPanelBehavior PauseMenuUI;
   public BlimpBehavior BlimpUI;
   public LevelSelectPanelBehavior LevelSelectUI;
   public GameObject MainMenu;
   public GameObject TruckButtons;

   public bool AllowBlasts = true;
   private ScoreCircle scoreCircle;
   private int blastsSoFar;
   private bool mainMenuShown;

   private void Awake()
   {
      scoreCircle = GameObject.Find("ScoringCircle").GetComponent<ScoreCircle>();
      level = GetComponent<LevelController>();
      
   }

   // Start is called before the first frame update
   void Start()
   {
      ShowMainMenu();
   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape) && !mainMenuShown)
      {
         PauseToggle();
      }

      if (!PauseMenuPanelBehavior.Paused && !mainMenuShown)
      {
         bool canReset = blastsSoFar >= level.CurrentLevel.MinBombs;
         if (canReset)
         {
            foreach (Transform t in level.activeLevel.transform)
            {
               if (t.gameObject.GetComponent<Rigidbody2D>() is Rigidbody2D rb2d)
               {
                  if (rb2d.velocity.magnitude > speedLimit)
                  {
                     canReset = false;
                     break;
                  }
               }
               if (t.gameObject.GetComponentInChildren<Bomb>() is Bomb)
               {
                  canReset = false;
                  break;
               }
            }
         }
         ScoreLevelButton.GetComponent<Button>().interactable = canReset;
      }
   }

   public void PauseToggle()
   {
      MenuFunctions.Instance.HideAllMenus();
      PauseMenuUI.EscapePressed(level);
   }

   public void StartScoring()
   {
      AllowBlasts = false;
      scoreCircle.RunScore(FinishScoring);
   }
   public void FinishScoring()
   {
      level.SaveScore();
      level.UnlockNextLevel();
      LevelScoreUI.DisplayLevelScore(level);
   }

   public void LevelReset()
   {
      LevelScoreUI.HidePanel();
      scoreCircle.ScoringInterrupt();
      AllowBlasts = true;
      blastsSoFar = 0;
      BlimpUI.UpdateLevel(level.currentLevel, level.CurrentLevel.LevelName);
      BlimpUI.UpdateBlasts(blastsSoFar, level.CurrentLevel.MinBombs);
      if (PauseMenuPanelBehavior.Paused)
      {
         PauseMenuUI.ShowPauseMenu(level);
      }
   }

   internal void BlastApplied()
   {
      ++blastsSoFar;
      BlimpUI.UpdateBlasts(blastsSoFar, level.CurrentLevel.MinBombs);
   }

   public void ShowLevelSelect()
   {
      MenuFunctions.Instance.HideAllMenus();
      LevelSelectUI.ShowLevelSelectPanel(level, LevelSelected);
   }

   public void StartGame()
   {
      level.LoadLevel(level.highestUnlockedLevel);
      HideMainMenu();
   }

   public void LevelSelected()
   {
      PauseMenuUI.HidePauseMenu();
      HideMainMenu();
   }


   public void ShowMainMenu()
   {
      PauseMenuUI.HidePauseMenu();
      MainMenu.SetActive(true);
      mainMenuShown = true;
      TruckButtons.SetActive(false);
      Time.timeScale = 0;
   }

   public void HideMainMenu()
   {
      MainMenu.SetActive(false);
      mainMenuShown = false;
      TruckButtons.SetActive(true);
      Time.timeScale = 1;
   }

}
