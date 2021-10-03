using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ScoreChanged(int newScore);

public class Scorekeeper
{
   public static Scorekeeper Instance
   {
      get
      {
         if (instance is null)
         {
            instance = new Scorekeeper();
         }
         return instance;
      }
   }

   private static Scorekeeper instance;

   private Scorekeeper()
   {
      Score = 0;
   }


   public int Score 
   {
      get; private set;
   }

   public ScoreChanged OnScoreChanged
   {
      get; set;
   }

   public void AddScore(int score)
   {
      this.Score += score;
      OnScoreChanged.Invoke(this.Score);
   }

   public void ResetScore()
   {
      this.Score = 0;
      OnScoreChanged.Invoke(this.Score);
   }

}
