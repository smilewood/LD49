using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuPanelBehavior : MonoBehaviour
{
   public Button nextLevelButton, previousLevelButton;
   public static bool Paused
   {
      get; private set;
   }

   public void ShowPauseMenu(LevelController levelController)
   {
      Paused = true;
      Time.timeScale = 0;
      UpdatePauseMenu(levelController);

      gameObject.SetActive(true);
   }

   public void UpdatePauseMenu(LevelController levelController)
   {
      nextLevelButton.interactable = levelController.IsNextLevel && levelController.NextLevelUnlocked;
      previousLevelButton.interactable = levelController.IsPreviousLevel;
   }

   public void HidePauseMenu()
   {
      Paused = false;
      Time.timeScale = 1;
      gameObject.SetActive(false);
   }

   public void EscapePressed(LevelController levelController)
   {
      if (gameObject.activeSelf)
      {
         HidePauseMenu();
      }
      else
      {
         ShowPauseMenu(levelController);
      }
   }
   
}
