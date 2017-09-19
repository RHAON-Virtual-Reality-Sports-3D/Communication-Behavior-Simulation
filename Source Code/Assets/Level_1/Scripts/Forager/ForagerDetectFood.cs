using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject {
	public class ForagerDetectFood : MonoBehaviour {

		ForagerMemory foragerMemory;

		void Start () {
			foragerMemory = GetComponentInParent <ForagerMemory> ();
		}
		
		void OnTriggerEnter (Collider other)
		{
			// If the entering collider is the food...
			if(other.gameObject.CompareTag("Food") && other is SphereCollider )
			{
				// ... the food detected.
				//print("Food in detection field: "+Vector3.Distance(gameObject.transform.position, other.gameObject.transform.position));
				foragerMemory.UpdateFoodInfo(other.gameObject.GetComponent<Food>().info);
			}
		}

		void OnTriggerExit (Collider other)
		{
			// If the entering collider is the food...
			if(other.gameObject.CompareTag("Food") && other is SphereCollider )
			{
				// ... the food detected.
				//print("Food out of detection field");
				foragerMemory.UpdateFoodInfo(other.gameObject.GetComponent<Food>().info);
			}
		}
			
	}
}