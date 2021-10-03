using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnImpact : MonoBehaviour
{
   public float BreakForce;
   public GameObject puffPrefab;

   private void OnCollisionEnter2D(Collision2D collision)
   {
      float baseImpaceForce = collision.relativeVelocity.magnitude;
      float impactMass = collision.otherRigidbody.mass;
      if(collision.rigidbody is Rigidbody2D other)
      {
         impactMass += other.mass;
      }
      float ImpactForce = baseImpaceForce * Mathf.Sqrt(impactMass);

      if(ImpactForce > BreakForce)
      {
         Debug.Log(string.Format("Impact between {0} and {1}; Impact force: {2}", this.gameObject.name, collision.gameObject.name, ImpactForce));
         Instantiate(puffPrefab, this.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
         AudioManager.Instance.PlayBreakSound();
         Destroy(this.gameObject);
      }
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("Dropped"))
      {
         Destroy(this.gameObject);
         return;
      }
   }
}
