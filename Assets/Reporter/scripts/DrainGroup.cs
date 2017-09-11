using UnityEngine;
using System.Collections;

public class DrainGroup : MonoBehaviour {

	private SingleDrain[] singles;
	// Use this for initialization
	void Start () {
		singles=new SingleDrain[3];
		singles = this.GetComponentsInChildren<SingleDrain> ();
		SortByVertical ();

	}
	
	// Update is called once per frame
	void Update () {
	ChangeFormByCamera ();
	}
	void SortByVertical()
	{
		SingleDrain temp;
		for (int i =0; i<singles.Length-1; i++)
						for (int j=i; j<singles.Length; j++) {
				if(singles[i].transform.position.y<singles[j].transform.position.y)
			{temp=singles[i];
			singles[i]=singles[j];
				singles[j]=temp;}
		
		
		
		}
//		for (int i =0; i<singles.Length; i++)
//						singles [i].order = i;
	}

	void SingleChangePlace( int singleIndex,int prefabIndex,int scale,Vector3 tarPos)
	{
		//TO BE CONTINUED!!!!
		if (scale == 1)
			prefabIndex = prefabIndex * 2;
		if(scale==-1)
			prefabIndex = prefabIndex * 2+1;
		if (singles [singleIndex].type != singleRrainPrefabs [prefabIndex].type
		    ||singles [singleIndex].dir != singleRrainPrefabs [prefabIndex].dir) {
			Destroy(singles [singleIndex].gameObject);
			singles [singleIndex]=(SingleDrain)Instantiate(singleRrainPrefabs [prefabIndex]);
		}

	
		if (singles [singleIndex].transform.position != tarPos)
						singles [singleIndex].transform.position = tarPos;
	   
	}

	public SingleDrain[] singleRrainPrefabs;
//	private ArrayList visibleIndex;
//	private ArrayList invisibleIndex;

	public float unitY=800f;

	int nextIndex=0;
	int scale;
	void ChangeFormByCamera()
	{
//				Vector3 cameraPos = (Vector3)(Vector2)Camera.main.transform.position;
//				visibleIndex.Clear ();
//				invisibleIndex.Clear ();
		 int visibleOne=10;
		for (int i=0; i<singles.Length; i++) {
			if (singles [i].visible) {
				visibleOne=i;
				//visibleIndex.Add (i.ToString());
			}
//			else
//				invisibleIndex.Add(i.ToString());
		}
	if (visibleOne == 0) {

			int diffiRefer=GameManager.difficulty;
			if(diffiRefer>95)
				diffiRefer=95;
			if(diffiRefer<10)
				diffiRefer=10;

			if(Random.Range(0,101)>=diffiRefer)	
				nextIndex=0;
			else
			{
				if(Random.Range(0,2)==0)
					nextIndex=1;
				else
					nextIndex=2;
			}



			if(singles[0].type==drainType.str)
				scale=(int)singles[0].dir;
			else
				scale=-singles[0].dir;

			SingleChangePlace(2,nextIndex,scale,singles[0].transform.position+unitY*Vector3.up);
			SortByVertical();



			
		}
	
	
	}




}
