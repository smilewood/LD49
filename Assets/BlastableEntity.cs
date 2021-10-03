using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlastableEntity : MonoBehaviour
{
   public GameObject bomb;
   bool blasted = false;
   private GameTracker gm;

   private void Start()
   {
      gm = GameObject.Find("GameMaster").GetComponent<GameTracker>();
   }

   private void OnMouseDown()
   {
      if (!blasted && gm.AllowBlasts && !EventSystem.current.IsPointerOverGameObject())
      {
         gm.BlastApplied();
         GameObject bombGO = Instantiate(bomb, this.transform.position, Quaternion.identity, this.transform);
         bombGO.GetComponent<Bomb>().target = this.gameObject;
         AudioManager.Instance.PlayBombSound();
         blasted = true;
      }
   }

}
