using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject3
{
    public class Food : MonoBehaviour
    {
		public FoodInfo info;
        public static int startingAmount = 100;                     // The amount of the food starts the game with.
		public int currentAmount = 100;                         	// The current amount of the food.
		public float sinkSpeed = 2.5f;              				// The speed at which the food sinks through the floor when run out.
		public Animator anmi;												// Whether the food runs out.
		bool isSinking;

        void Awake ()
        {
            // Set the initial amount of the food.
			info = new FoodInfo(gameObject);
			anmi = GetComponent<Animator> ();
        }
			
        public void BeCollected (int amount)
        {

            // Reduce the current amount by the collecting amount.
            currentAmount -= amount;
			info.UpdateAmount (currentAmount);

            // If the food has lost all it's amount and the empty flag hasn't been set yet...
            if(currentAmount <= 0)
            {
                // ... it should disappear.
                Empty ();
            }
        }
			
        void Empty ()
        {
            // Set the death flag so this function won't be called again.
			anmi.SetTrigger ("Empty");
        }

		void StartSinking(){}
			
    }
}