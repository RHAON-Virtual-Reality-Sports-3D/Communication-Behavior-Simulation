using UnityEngine;

namespace CompleteProject
{
    public class ForagerCapacity : MonoBehaviour
    {
        public static int maxCapacity = 30;            	// The capacity the forager starts the game with.
        public int currentCapacity = 0;             // The current food the forager has.

		ForagerMemory foragerMemory;

        void Awake ()
        {
            // Setting up the references.
			foragerMemory = GetComponent <ForagerMemory> ();
        }

        public void AddFood (int amount)
        {

            // Increase the current capacity.
			currentCapacity += amount;
			foragerMemory.info.UpdateCapacity(currentCapacity);
        }

		public void ReleaseFood ()
		{
			// Set current capacity 0
			currentCapacity = 0;
			foragerMemory.info.UpdateCapacity(currentCapacity);
		}
			

    }
}