using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
   public string text;
   private Text UI;
   // Start is called before the first frame update
   void Awake()
   {
      UI = GetComponent<Text>();
      Scorekeeper.Instance.OnScoreChanged += ScoreChanged;
   }

   public void ScoreChanged(int newScore)
   {
      UI.text = string.Format(text, newScore);
   }
}
