using UnityEngine;

public class EffectOnDeath : MonoBehaviour
{
   public float timeForParticleDeletion;

   void Start()
    {
    Destroy(gameObject, timeForParticleDeletion); 
    }
}
