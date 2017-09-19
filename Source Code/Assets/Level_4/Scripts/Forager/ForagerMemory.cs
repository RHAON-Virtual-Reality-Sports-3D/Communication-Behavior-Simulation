using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject3{
	public class ForagerMemory : MonoBehaviour {

		// self info
		public ForagerInfo info;

		// Level 1
		public Vector3 hivePos;

		// Level 2
		public static List<FoodInfo> openlist;
		public static List<FoodInfo> closelist;

		// Level 3
		public static List<ForagerInfo> teammates;

		// Teammates in detection field 
		public List<GameObject> foragerDetected;
		// Teammate communicated with
		public GameObject foragerCommunicated = null;
		// Current action
		public string currentAction = "Idle";

		void Awake () {
			info = new ForagerInfo ();
			GameObject hive = GameObject.FindGameObjectWithTag ("Hive");
			hivePos = hive.transform.position;
			openlist = new List<FoodInfo> ();
			closelist = new List<FoodInfo> ();
			teammates = new List<ForagerInfo> ();
			foragerDetected = new List<GameObject> ();
		}



		// Pick the best food target from open list
		public FoodInfo PickBestFood(){
			if (openlist.Count == 0)		// if the open list is empty
				return null;

			int bestIndex = 0;
			float bestScore = FoodScore(openlist[0]);
			for (int i = 1; i < openlist.Count; i++) {
				float currentScore = FoodScore(openlist[i]);
				if (currentScore < bestScore) {
					bestIndex = i;
					bestScore = currentScore;
				}
			}
			return openlist [bestIndex];
		}

		// Pick the best forager target to communicate
		public GameObject PickBestForager(){
			if (foragerDetected.Count == 0)		// if the open list is empty
				return null;

			int bestIndex = 0;
			float bestScore = ForagerScore(foragerDetected[0]);
			for (int i = 1; i < foragerDetected.Count; i++) {
				float currentScore = ForagerScore(foragerDetected[0]);
				if (currentScore < bestScore) {
					bestIndex = i;
					bestScore = currentScore;
				}
			}
			return foragerDetected[bestIndex];
		}

		// Calculate score of food source, Score is 0.8*distance+0.2*currentCapacity, the larger the worse
		float FoodScore(FoodInfo food){
			return Vector3.Distance(food.position, gameObject.transform.position);
		}

		// Calculate score of target forager, Score is 0.8*distance+0.2*currentCapacity, the larger the worse
		float ForagerScore(GameObject forager){
			return Vector3.Distance(forager.transform.position, gameObject.transform.position);
		}


		// Update food info
		public void UpdateFoodInfo (FoodInfo info){
			int index = -1;
			for(int i = 0; i < openlist.Count; i++){
				if (openlist[i].ID == info.ID)
					index = i;
			}

			// if the food already in the openlist, check version of info
			if (index != -1) {
				if (info.currentAmount == 0) {
					openlist.RemoveAt (index);
					closelist.Add (info);
				} else {
					if(openlist [index].version < info.version)
						openlist [index] = info;
				}
			}
			// if the food is new
			else {
				if (info.currentAmount == 0) {
					if(!closelist.Contains(info))
						closelist.Add (info);
				} else {
					openlist.Add (info);
				}
			}
		}
			

		// Update forager info
		public void UpdateForagerInfo(ForagerInfo info){

		}

			
	}
}
