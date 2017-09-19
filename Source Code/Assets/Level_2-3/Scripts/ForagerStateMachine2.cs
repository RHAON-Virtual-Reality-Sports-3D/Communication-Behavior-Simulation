using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject {
	public class ForagerStateMachine2 : MonoBehaviour {
		ForagerMemory foragerMemory;
		ForagerMovement foragerMovement;
		ForagerExplore foragerExplore;
		ForagerCommunicate foragerCommunicate;

		float timer = 0f;


		void Awake () {
			foragerMemory = GetComponent<ForagerMemory>();
			foragerMovement = GetComponent<ForagerMovement>();
			foragerExplore = GetComponent<ForagerExplore>();
			foragerCommunicate = GetComponentInChildren<ForagerCommunicate> ();
		}

		void Update () {
			int currentCapacity = foragerMemory.info.currentCapacity;
			GameObject target = foragerMemory.foragerCommunicated;

			if (target == null) {
				if (timer > 1f) {
					foragerCommunicate.EstablishCommunication ();
					timer = 0f;
				}
			} else {
				foragerMovement.GoTo (target.transform.position);
				foragerMemory.currentAction = "Communicate";
				return;
			}

			timer += Time.deltaTime;

			if (currentCapacity != 30) {
				if (foragerMemory.openlist.Count == 0) {
					foragerExplore.Explore ();
					foragerMemory.currentAction = "Explore";
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
