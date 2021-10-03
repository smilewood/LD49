using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelSelectPanelBehavior : MonoBehaviour
{
   public Transform LevelPanel;
   public GameObject LevelSelectButtonPrefab;
   private bool initialized = false;
   private void Awake()
   {
   }

   public void ShowLevelSelectPanel(LevelController levelController, UnityAction onButtonCLicked)
   {
      if (!initialized)
      {
         List<Level> levels = levelController.GetLevels();
         for (int i = 0; i < levels.Count; ++i)
         {
            LevelSelectButton button = Instantiate(LevelSelectButtonPrefab, LevelPanel).GetComponent<LevelSelectButton>();
            button.InitializeButton(i, levels[i].LevelName, levelController);
            button.gameObject.GetComponent<Button>().onClick.AddListener(HideLevelSelectPanel);
            button.gameObject.GetComponent<Button>().onClick.AddListener(onButtonCLicked);
         }
         initialized = true;
      }
      else
      {
         foreach (Transform t in LevelPanel)
         {
            if(t.GetComponent<LevelSelectButton>() is LevelSelectButton button)
            {
               button.RefreshButtonInteractable();
            }
         }
      }
      gameObject.SetActive(true);
   }

   public void HideLevelSelectPanel()
   {
      gameObject.SetActive(false);
   }
}
