using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCircle : MonoBehaviour
{
   public float scoreSpeed;
   public float maxSize;
   private CircleCollider2D circle;
   // Start is called before the first frame update
   void Awake()
   {
      circle = GetComponent<CircleCollider2D>();
   }

   public void RunScore(Action finishedAction)
   {
      StartCoroutine(RunScoring(finishedAction));
   }

   public void ScoringInterrupt()
   {
      StopAllCoroutines();
      circle.radius = .5f;
   }

   private IEnumerator RunScoring(Action finishedAction)
   {
      float expand = .5f;
      while(expand < maxSize)
      {
         expand += Time.deltaTime * scoreSpeed;
         circle.radius = expand;
         yield return new WaitForFixedUpdate();
      }
      circle.radius = .5f;
      finishedAction();
   }
}
