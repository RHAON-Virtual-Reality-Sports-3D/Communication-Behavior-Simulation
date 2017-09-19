using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	public class ForagerCommunicate : MonoBehaviour
	{
		public float timeBetweenCommunicate = 0.2f;     	// The time in seconds between each collect.
		ForagerMemory foragerMemory;                 	// Reference to the food's amount.

		bool targetInRange;                         	// Whether food is within the trigger collider and can be collected.
		float timer;                                	// Timer for counting up to the next collect.

		void Awake()
		{
			// Setting up the references.
			foragerMemory = GetComponentInParent <ForagerMemory> ();
		}

		void OnTriggerEnter (Collider other)
		{
			// If the entering collider is the forager...
			if(other.gameObject.CompareTag("Forager") && foragerMemory.foragerCommunicated != null && other.gameObject == foragerMemory.foragerCommunicated)
			{
				targetInRange = true;
			}
		}


		void OnTriggerExit (Collider other)
		{
			// If the exiting collider is the forager...
			if(foragerMemory.foragerCommunicated == null || (other.gameObject.CompareTag("Forager") && other.gameObject == foragerMemory.foragerCommunicated))
			{
				targetInRange = false;
			}
		}


		void Update ()
		{
			// Add the time since Update was last called to the timer.
			timer += Time.deltaTime;

			// If the timer exceeds the time between collects, the food is in range and this enemy is alive...
			if(timer >= timeBetweenCommunicate && foragerMemory.foragerCommunicated != null && targetInRange)
			{
				// ... collect.
				Communicate ();
				timer = 0;
			}
		}


		public bool EstablishCommunication(){
			GameObject targetPicked = foragerMemory.PickBestForager();
			if (foragerMemory.foragerCommunicated != null || targetPicked == null) {
				return false;
			}
			print (Vector3.Distance(targetPicked.transform.position, this.gameObject.transform.position));
			if(targetPicked.GetComponent<ForagerMemory> ().currentAction != "Collect" && targetPicked.GetComponent<ForagerMemory> ().foragerCommunicated == null && targetPicked.GetComponent<ForagerMemory> ().openlist.Count > 0){
				targetPicked.GetComponent<ForagerMemory> ().foragerCommunicated = this.gameObject;
				foragerMemory.foragerCommunicated = targetPicked;

				return true;
			}else{
				return false;
			}
				
		}

		public void ExistCommunication(){
			if (foragerMemory.foragerCommunicated != null) {
				//foragerMemory.foragerCommunicated.GetComponent<ForagerMemory> ().foragerCommunicated = null;
				foragerMemory.foragerDetected.Remove (foragerMemory.foragerCommunicated);
				foragerMemory.foragerCommunicated = null;
			}
		}

		// This a double way communicate method
		public void Communicate ()
		{
			print ("Communicating" );
			if (foragerMemory.foragerCommunicated.GetComponent<ForagerMemory> () != null) {
				
				for (int i = 0; i < foragerMemory.foragerCommunicated.GetComponent<ForagerMemory> ().openlist.Count; i++) {
					foragerMemory.UpdateFoodInfo (foragerMemory.foragerCommunicated.GetComponent<ForagerMemory> ().openlist [i]);
				}
				for (int i = 0; i < foragerMemory.foragerCommunicated.GetComponent<ForagerMemory> ().closelist.Count; i++) {
					foragerMemory.UpdateFoodInfo (foragerMemory.foragerCommunicated.GetComponent<ForagerMemory> ().closelist [i]);
				}

				for (int i = 0; i < foragerMemory.openlist.Count; i++) {
					foragerMemory.foragerCommunicated.GetComponent<ForagerMemory> ().UpdateFoodInfo (foragerMemory.openlist[i]);
				}

				for (int i = 0; i < foragerMemory.closelist.Count; i++) {
					foragerMemory.foragerCommunicated.GetComponent<ForagerMemory> ().UpdateFoodInfo (foragerMemory.closelist[i]);
				}

				foragerMemory.foragerCommunicated.GetComponentInChildren<ForagerCommunicate> ().ExistCommunication();
				ExistCommunication ();
			}

		}
	}
}