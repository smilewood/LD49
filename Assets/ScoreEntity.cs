using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEntity : MonoBehaviour
{
   public int blastScore;
   public int endScore;

   public GameObject ScorePopup;

   public void DestroyByBlast()
   {
      Scorekeeper.Instance.AddScore(blastScore);
      GameObject popup = Instantiate(ScorePopup, this.transform.position, Quaternion.identity);
      popup.GetComponent<ScorePopup>().Setup(blastScore, true);
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("ScoreCheck"))
      {
         int score = (int)(endScore * (gameObject.transform.position.y + 4.5));

         Scorekeeper.Instance.AddScore(score);
         GameObject popup = Instantiate(ScorePopup, this.transform.position, Quaternion.identity);
         popup.GetComponent<ScorePopup>().Setup(score, false);
      }
   }
}
