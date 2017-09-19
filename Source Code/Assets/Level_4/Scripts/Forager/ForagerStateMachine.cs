using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject3 {
	public class ForagerStateMachine : MonoBehaviour {

		ForagerMemory foragerMemory;
		ForagerMovement foragerMovement;
		ForagerExplore foragerExplore;


		void Awake () {
			foragerMemory = GetComponent<ForagerMemory>();
			foragerMovement = GetComponent<ForagerMovement>();
			foragerExplore = GetComponent<ForagerExplore>();
		}

		void Update () {
			int currentCapacity = foragerMemory.info.currentCapacity;

			if (currentCapacity != 30) {
				if (ForagerMemory.openlist.Count == 0) {
					foragerExplore.Explore ();
				} else {
					FoodInfo info = foragerMemory.PickBestFood ();
					foragerMovement.GoTo (info.position);
					foragerMemory.currentAction = "Go to food";
				}
			} else {
				foragerMovement.GoTo (foragerMemory.hivePos);
				foragerMemory.currentAction = "Go home";
			}
		}
	}
}
