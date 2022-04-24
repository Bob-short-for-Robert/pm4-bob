using UnityEngine;
using Random = UnityEngine.Random;


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
      }
      else
      {
         seed = userSeed;
      }
      Random.InitState(seed);
   }
}
