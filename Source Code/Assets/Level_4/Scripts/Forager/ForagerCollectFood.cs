using UnityEngine;
using System.Collections;

namespace CompleteProject3
{
    public class ForagerCollectFood : MonoBehaviour
    {
        public float timeBetweenCollects = 0.5f;     // The time in seconds between each collect.
        public int collectAmount = 5;               // The amount of food taken away per collect.

        GameObject food;                          	// Reference to the food GameObject.
		ForagerCapacity foragerCapacity;			// Reference to the forager's capacity.
		ForagerMemory foragerMemory;
        Food foodAmount;                  				// Reference to the food's amount.

        bool foodInRange;                         	// Whether food is within the trigger collider and can be collected.
        float timer;                                // Timer for counting up to the next collect.


        void Start ()
        {
            // Setting up the references.
			foragerCapacity = GetComponentInParent <ForagerCapacity> ();
			foragerMemory = GetComponentInParent <ForagerMemory> ();

        }

        void OnTriggerEnter (Collider other)
        {
            // If the entering collider is the food...
			if(other.gameObject.CompareTag("Food") && other is SphereCollider)
            {
                // ... the food is in range.
				food = other.gameObject;
				// print("Collectting distance: " + Vector3.Distance(this.gameObject.transform.position, food.transform.position));
				foodAmount = food.GetComponent <Food> ();
                foodInRange = true;
            }
        }


        void OnTriggerExit (Collider other)
        {
            // If the exiting collider is the food...
			if(other.gameObject.CompareTag("Food") && other is SphereCollider)
            {
                // ... the food is no longer in range.
				foodAmount = null;
				food = null;
                foodInRange = false;
            }
        }


        void Update ()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

			if (foodInRange) {
				foragerMemory.currentAction = "Collect";
			}

            // If the timer exceeds the time between collects, the food is in range and this enemy is alive...
			if(timer >= timeBetweenCollects && foodInRange && foragerCapacity.currentCapacity < ForagerCapacity.maxCapacity)
            {
                // ... collect.
                Collect ();
            }
        }


        void Collect ()
		{
            // Reset the timer.
            timer = 0f;

            // If the food has food to collect...
			if(food != null && foodAmount.currentAmount > 0 )
            {
                // ... collect the food.
				collectAmount = Mathf.Min(foodAmount.currentAmount, ForagerCapacity.maxCapacity - foragerCapacity.currentCapacity, collectAmount);
				foodAmount.BeCollected (collectAmount);
				foragerCapacity.AddFood (collectAmount);
            }

			foragerMemory.UpdateFoodInfo (food.GetComponent<Food>().info);
        }
    }
}