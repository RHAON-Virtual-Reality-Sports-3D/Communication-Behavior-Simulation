using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject {
	public class ForagerExplore : MonoBehaviour {
		ForagerMemory foragerMemory;
		ForagerMovement foragerMovement;

		public float delete_radius = 1;
		private Vector3 home;
		int size = 21;
		int[,] wanderpoint = new int[44, 44];


		void Awake () {
			foragerMemory = GetComponent<ForagerMemory> ();
			foragerMovement = GetComponent<ForagerMovement> ();
			for (int i = -size; i < size+1; i++)
			{
				for (int j = -size; j < size+1; j++)
				{
					wanderpoint[i + size, j + size] = 1;
				}
			}
		}

		public void Explore(){
			foragerMemory.currentAction = "Explore";
			int x = (int)gameObject.transform.position.x;
			int y = (int)gameObject.transform.position.z;
			Vector3 tmp = new Vector3(x, foragerMovement.transform.position.y, y);
			try{
				if (((foragerMovement.transform.position - tmp).magnitude) < delete_radius && wanderpoint[x + size, y + size] != 0){
					wanderpoint[x + size, y + size] = 0;
				}
			}catch{}
			//print("update3");

			if (foragerMovement.isArrive())
			{
				bool index0 = true;
				while (index0)
				{
					//int index = Random.Range(0, 2500);
					int index = wanderDest();
					//print(index);
					int index_x = index / ((size+1)*2);
					int index_y = index % ((size+1)*2);
					//print((index_x-24) + " " + (index_y-24));
					if (wanderpoint[index_x, index_y] != 0)
					{
						Vector3 pos = new Vector3(index_x - size, 0, index_y - size);
						//print (pos);
						foragerMovement.GoTo(pos);
						//print (pos);
						wanderpoint[index_x, index_y] = 0;
						index0 = false;
					}
				}
			}
		}


		int wanderDest()
		{
			int dest = 0;
			int ch_x = (int)gameObject.transform.position.x;
			int ch_y = (int)gameObject.transform.position.z;
			int ch_area = wanderArea(ch_x, ch_y);

			//Random.seed = System.DateTime.Now.Millisecond;

			int dest_x = Random.Range(-size+1,size);
			int dest_y = Random.Range(-size+1,size);
			while(wanderArea(dest_x, dest_y) == ch_area)
			{
				dest_x = Random.Range(-size+1, size);
				dest_y = Random.Range(-size+1, size);
			}

			dest = (dest_x + size+1) * ((size+1)*2) + (dest_y+size+1);
			return dest;
		}


		// Divide the whole map into 4 areas
		int wanderArea(int x, int y)
		{
			if (x > 0){
				if (y > 0){
					return 1;
				} else{
					return 2;
				}
			} else {
				if (y > 0) {
					return 3;
				} else {
					return 4;
				}
			}
		}
	}
}
