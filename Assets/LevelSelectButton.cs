using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
   public string levelNumberStringFormat;
   private int levelToSelect;
   private LevelController levelController;
   public void InitializeButton(int levelNumber, string levelName, LevelController levelController)
   {
      this.levelToSelect = levelNumber;
      this.levelController = levelController;
      transform.Find("LevelNumber").GetComponent<Text>().text = string.Format(levelNumberStringFormat, levelToSelect + 1);
      transform.Find("LevelName").GetComponent<Text>().text = levelName;
      RefreshButtonInteractable();
   }

   public void RefreshButtonInteractable()
   {
      this.GetComponent<Button>().interactable = levelController.IsLevelUnlocked(levelToSelect);
   }


   public void ButtonClicked()
   {
      levelController.LoadLevel(levelToSelect);
   }
}
