using UnityEngine;
using System.Collections;

namespace CompleteProject3
{
    public class ForagerMovement : MonoBehaviour
    {
        Vector3 target;               			// Reference to the target's position.
        UnityEngine.AI.NavMeshAgent nav;            // Reference to the nav mesh agent.


        void Awake ()
        {
            // Set up the references.
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        }

		public void GoTo(Vector3 target){
			this.target = target;
			if(this.target != null)
				nav.SetDestination (this.target);
		}

		public bool isArrive(){
			if (this.nav.remainingDistance < this.nav.stoppingDistance) {
				return true;
			} else {
				return false;
			}
		}
    }
}