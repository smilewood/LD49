using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScorePanelBehavior : MonoBehaviour
{
   public Text scoreText;
   public string scoreString;

   public Text highScoreText;
   public string highScoreString;

   public Button nextLevelButton;

   public void DisplayLevelScore(LevelController levelController)
   {
      scoreText.text = string.Format(scoreString, Scorekeeper.Instance.Score);
      highScoreText.text = string.Format(highScoreString, levelController.CurrentLevelHighScore);

      nextLevelButton.interactable = levelController.IsNextLevel;

      gameObject.SetActive(true);
   }

   public void HidePanel()
   {
      this.gameObject.SetActive(false);
   }

}
