using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SetRandomSeed : MonoBehaviour
{
   public string stringSeed = "seed";
   public bool useStringSeed;
   public int seed;
   public bool randomizeSeed;

   private void Awake()
   {
      if (useStringSeed)
      {
         seed = stringSeed.GetHashCode();
      }

      if (randomizeSeed)
      {
         seed = Random.Range(0, 99999);
      }
      
      Random.InitState(seed);
   }
}
