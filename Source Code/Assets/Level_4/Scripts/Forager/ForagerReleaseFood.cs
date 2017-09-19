using UnityEngine;
using System.Collections;

namespace CompleteProject3
{
	public class ForagerReleaseFood : MonoBehaviour
	{
		public float timeBetweenCollects = 0.1f;     // The time in seconds between each release.
		public int releaseAmount;               	// The amount of food taken away per release.

		GameObject hive;                          	// Reference to the food GameObject.
		ForagerCapacity foragerCapacity;			// Reference to the forager's capacity.
		Hive hiveAmount;                  			// Reference to the hive's amount.

		bool hiveInRange;                         	// Whether food is within the trigger collider and can be collected.
		float timer;                                // Timer for counting up to the next collect.


		void Start ()
		{
			// Setting up the references.
			hive = GameObject.FindGameObjectWithTag ("Hive");
			hiveAmount = hive.GetComponent <Hive> ();
			foragerCapacity = GetComponentInParent <ForagerCapacity> ();
		}


		void OnTriggerEnter (Collider other)
		{
			// If the entering collider is the hive...
			if(other.gameObject == hive)
			{
				// ... the food is in range.
				hiveInRange = true;
			}
		}


		void OnTriggerExit (Collider other)
		{
			// If the exiting collider is the hive...
			if(other.gameObject == hive)
			{
				// ... the hive is no longer in range.
				hiveInRange = false;
			}
		}


		void Update ()
		{
			// Add the time since Update was last called to the timer.
			timer += Time.deltaTime;

			// If the timer exceeds the time between collects, the food is in range and this enemy is alive...
			if(timer >= timeBetweenCollects && hiveInRange)
			{
				// ... collect.
				Release ();
			}

		}


		void Release ()
		{
			// Reset the timer.
			timer = 0f;

			// ... release the food.
			hiveAmount.Store(foragerCapacity.currentCapacity);
			foragerCapacity.ReleaseFood();
		}
	}
}