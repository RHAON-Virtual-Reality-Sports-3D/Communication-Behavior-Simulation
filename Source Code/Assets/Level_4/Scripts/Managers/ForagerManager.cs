using UnityEngine;

namespace CompleteProject3
{
    public class ForagerManager : MonoBehaviour
    {
        public GameObject forager;              // The forager prefab to be spawned.
        public float spawnTime = 0.1f;          // How long between each spawn.
        public Transform[] spawnPoints;			// An array of the spawn points this forager can spawn from.
		public int numOfForager = 2;			// The number of foragers


        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime.
			for(int i = 0; i < numOfForager; i++)
				Invoke ("Spawn", spawnTime);
        }

        void Spawn ()
        {

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);

            // Create an instance of the forager prefab at the randomly selected spawn point's position and rotation.
            Instantiate (forager, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}