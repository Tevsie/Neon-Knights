using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnDeath : MonoBehaviour
{

    //this goes on the object creating the particles, the one that dies

    //public ParticleSystem enemyDeathPS;  //reference to PS

    
    /*public void DeathEffect()   //call this method when the object dies
    {
        Instantiate(enemyDeathPS, transform position, Quaternion.identity); //Create a PS in the location of the gameobject
        //eventually put other effects or call other scripts
    }*/

   
    //this goes on PS

   public float timeForParticleDeletion = 1f;
   void Start()
    {
     Destroy(gameObject, timeForParticleDeletion); //Destroy clone after an amount of time
    }
}
