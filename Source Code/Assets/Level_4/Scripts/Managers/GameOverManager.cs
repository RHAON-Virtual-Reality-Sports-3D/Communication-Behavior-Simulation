using UnityEngine;

namespace CompleteProject3
{
    public class GameOverManager : MonoBehaviour
    {
		GameObject[] foods;
		GameObject UI;

		float timer = 0;
		bool isOver = false;
		float totalFoodCollected = 0;
		float totalFood = 0;




        void Awake ()
        {
            // Set up the reference.
			foods = GameObject.FindGameObjectsWithTag ("Food");
			UI = GameObject.FindGameObjectWithTag ("UI");

			for (int i = 0; i < foods.Length; i++) {
				totalFood += foods [i].GetComponent<Food> ().currentAmount;
			}
				
        }


        void Update ()
        {
			// Check game over
			if (isOver) {
				print ("Gameover");
				UI.GetComponent<TextMesh> ().text = "Game Over " +
													"\nTotal Time: " + timer +
													"\nTotal Food: " + totalFood +
													"\nFood Collected: " + totalFoodCollected;
				return;
			}

			int currentTotalFood = 0;
			for (int i = 0; i < foods.Length; i++) {
				currentTotalFood += foods [i].GetComponent<Food> ().currentAmount;
			}

			totalFoodCollected = (totalFood - currentTotalFood);
			// If all food collected, game over
			if(currentTotalFood == 0) isOver = true;

			timer += Time.deltaTime;
			UI.GetComponent<TextMesh> ().text = "Game On " +
												"\nCurrent Time: " + timer +
												"\nTotal Food: " + totalFood +
												"\nFood Collected: " + totalFoodCollected;

        }
    }
}