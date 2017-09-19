using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject3 {
	public class ForagerInfo {
		public static int numOfForager = 0;

		public int ID;
		public int currentCapacity;
		public string action;			// What the forager is doing before communicating
		public int version;				// Current version of information

		public ForagerInfo(){
			numOfForager++;				// Creating a new forager

			ID = numOfForager;
			currentCapacity = 0;		// Capacity is 0
			action = "";				// No action
			version = 0;				// The first version of information;
		}

		public void UpdateCapacity(int currentCapacity){
			this.currentCapacity = currentCapacity;
			UpdateVersion ();			// Once the attribute changes, the version increases
		}

		public void UpdateAction(string action){
			this.action = action;
			UpdateVersion ();			// Once the attribute changes, the version increases
		}

		public void UpdateVersion(){
			this.version++;
		}

		public override int GetHashCode(){
			return ID;
		}

	}
}
