using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject {
	public class FoodInfo{
		public static int numOfFoods = 0;

		public int ID;
		public Vector3 position;	// Position of food source
		public int currentAmount;
		public int version;			// Current version of information

		public FoodInfo(GameObject gameObject){
			numOfFoods++;															// Creating a new food

			ID = numOfFoods;
			position = gameObject.transform.position;
			currentAmount = gameObject.GetComponent<Food>().currentAmount;			// Amount of orign food
			version = 0;															// The first version of information;
		}

		public void UpdateAmount(int currentAmount){
			this.currentAmount = currentAmount;
			UpdateVersion ();														// Once the attribute changes, the version increases
		}
			
		public void UpdateVersion(){
			this.version++;
		}

		public override int GetHashCode(){
			return ID;
		}
	}
}

