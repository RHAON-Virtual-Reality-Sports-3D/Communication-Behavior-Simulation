using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject3
{
	public class Hive : MonoBehaviour
	{
		public int amount = 0;                            			// The amount of the food starts the game with.


		public void Store (int amount)
		{
			// Reduce the current amount by the collecting amount.
			this.amount  += amount;
		}
			
	}
}