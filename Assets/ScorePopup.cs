using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePopup : MonoBehaviour
{
   public Text text;

   public void Setup(int score, bool blasted)
   {
      text.text = score.ToString();
      text.color = Color.green;
   }
}
