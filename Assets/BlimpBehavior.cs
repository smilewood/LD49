using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlimpBehavior : MonoBehaviour
{
   public Text LevelText;
   public string LevelString;

   public Text BlastsText;
   public string blastsString;

   public void UpdateBlasts(int current, int min)
   {
      BlastsText.text = string.Format(blastsString, current, min);
   }

   public void UpdateLevel(int level, string name)
   {
      LevelText.text = string.Format(LevelString, level+1, name);
   }
}
