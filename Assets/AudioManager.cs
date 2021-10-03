using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public GameObject audioClipPrefab;

   public AudioClip BombClip;
   private bool playBombClip;

   public AudioClip BreakClip;
   private bool playBreakClip;

   public static AudioManager Instance
   {
      get
      {
         return _instance;
      }
   }
   private static AudioManager _instance;

   private void Awake()
   {
      if(_instance is null)
      {
         _instance = this;
      }
   }

   private void Update()
   {
      if (playBombClip)
      {
         PlayClip(BombClip);
         playBombClip = false;
      }
      if (playBreakClip)
      {
         PlayClip(BreakClip);
         playBreakClip = false;
      }
   }

   private void PlayClip(AudioClip clip)
   {
      GameObject go = Instantiate(audioClipPrefab, this.transform);
      go.GetComponent<AudioSource>().clip = clip;
   }

   public void PlayBombSound()
   {
      playBombClip = true;
   }
   public void PlayBreakSound()
   {
      playBreakClip = true;
   }
}
