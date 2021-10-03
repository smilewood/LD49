using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
   public GameObject target;
   public GameObject blastPrefab;

   public void OnCountdownFinished()
   {
      target.GetComponent<ScoreEntity>()?.DestroyByBlast();
      Destroy(target);
      Instantiate(blastPrefab, this.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
   }
}
