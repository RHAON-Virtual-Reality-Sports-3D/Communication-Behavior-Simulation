using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CompleteProject {
	public class ForagerDetectForager : MonoBehaviour {
		ForagerMemory foragerMemory;

		void Awake () {
			foragerMemory = GetComponentInParent<ForagerMemory> ();
		}

		void OnTriggerEnter (Collider other)
		{
			// If the entering collider is the food...
			if(other.gameObject.CompareTag("Forager") && other is CapsuleCollider)
			{
				if(!foragerMemory.foragerDetected.Contains(other.gameObject))
					foragerMemory.foragerDetected.Add (other.gameObject);
			}
		}

		void OnTriggerExist (Collider other)
		{
			// If the entering collider is the food...
			if(other.gameObject.CompareTag("Forager") && other is CapsuleCollider)
			{
					foragerMemory.foragerDetected.Remove (other.gameObject);
			}
		}
			
	}
}