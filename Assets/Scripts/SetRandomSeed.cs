using System;
using UnityEditor.PackageManager;
using UnityEngine;
using Random = UnityEngine.Random;
using static BOB_Logger;

public class SetRandomSeed : MonoBehaviour
{
   public int userSeed = 10;
   public int seed;
   public bool randomizeSeed;

   private void Awake()
   {

      if (randomizeSeed)
      {
         seed = Random.Range(0, 99999);
         Log(String.Format("generating new seed {0}", seed.ToString()), LogLevel.Info);
      }
      else
      {
         seed = userSeed;
         Log(String.Format("using seed {0}", seed.ToString()), LogLevel.Info);
      }
      Random.InitState(seed);
   }
}
