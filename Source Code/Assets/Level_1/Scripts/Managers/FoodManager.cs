using UnityEngine;

namespace CompleteProject
{
	public class FoodManager : MonoBehaviour
	{
		public GameObject food;                // The enemy prefab to be spawned.
		public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

		public int numOfFood = 10;


		void Start ()
		{
			for(int i = 0; i < numOfFood; i++)
				Invoke ("Spawn", 0);
		}


		void Spawn ()
		{
			// Find a random index between zero and one less than the number of spawn points.
			//Vector3 spawnPosition = Vector3();

			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			//Instantiate (food, spawnPosition);
		}
	}
}