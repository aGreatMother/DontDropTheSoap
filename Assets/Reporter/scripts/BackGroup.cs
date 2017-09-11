using UnityEngine;
using System.Collections;

public class BackGroup : MonoBehaviour {

	private SingleBack[] singleBacks;
	// Use this for initialization
	void Start () {
		singleBacks = new SingleBack[2];
		singleBacks = this.GetComponentsInChildren<SingleBack> ();
		visibleIndex=new ArrayList();
		invisibleIndex=new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
		ChangeFormByCamera ();
	}
	ArrayList visibleIndex;
	ArrayList invisibleIndex;
	//public float unitX=800f;
	public float unitY=800f;
	void ChangeFormByCamera()
	{
		Vector3 cameraPos = (Vector3)(Vector2)Camera.main.transform.position;
		visibleIndex.Clear ();
		invisibleIndex.Clear ();
		for (int i=0; i<singleBacks.Length; i++) {
						if (singleBacks [i].visible) {
								visibleIndex.Add (i.ToString());
						}
		else
				invisibleIndex.Add(i.ToString());
		}// suppose to be simple!

		if (visibleIndex.Count == 1) {
			Vector3 op=singleBacks[int.Parse (visibleIndex[0] as string) ].transform.position;
			Vector3 ip1=singleBacks[int.Parse (invisibleIndex[0] as string) ].transform.position;


			float signY=Mathf.Sign(cameraPos.y-op.y);

			if(ip1!=op+signY*Vector3.up*unitY)
				singleBacks[int.Parse (invisibleIndex[0] as string) ].ChangeToOtherPlace(op+signY*Vector3.up*unitY);

		}

		//FOLLOWING MUTE PART IS FOR A SENCE NEED ENDLESS BACKDROP FOR BOTH LEVEL AND UPRIGHT //
		//if (visibleIndex.Count == 4&&visibleIndex.Count==3)
						//return;
//		if (visibleIndex.Count == 2) {
//			Vector3 p1=singleBacks[int.Parse (visibleIndex[0] as string) ].transform.position;
//			Vector3 p2=singleBacks[int.Parse (visibleIndex[1] as string) ].transform.position;
//			Vector3 ip1=singleBacks[int.Parse (invisibleIndex[0] as string) ].transform.position;
//			Vector3 ip2=singleBacks[int.Parse (invisibleIndex[1] as string) ].transform.position;
//			if(p1.x==p2.x)
//			{
//				if(cameraPos.x>p1.x&&ip1.x!=p1.x+unitX)
//					singleBacks[int.Parse (invisibleIndex[0] as string) ].ChangeToOtherPlace
//						(Vector3.right*unitX+p1);
//				if(cameraPos.x>p2.x&&ip2.x!=p2.x+unitX)
//					singleBacks[int.Parse (invisibleIndex[1] as string) ].ChangeToOtherPlace
//						(Vector3.right*unitX+p2);
//				if(cameraPos.x<p1.x&&ip1.x!=p1.x-unitX)
//					singleBacks[int.Parse (invisibleIndex[0] as string) ].ChangeToOtherPlace
//						(p1-Vector3.right*unitX);
//				if(cameraPos.x<p2.x&&ip2.x!=p2.x-unitX)
//					singleBacks[int.Parse (invisibleIndex[1] as string) ].ChangeToOtherPlace
//						(p2-Vector3.right*unitX);
//			}
//			if(p1.y==p2.y)
//			{
//				if(cameraPos.y>p1.y&&ip1.y!=p1.y+unitY)
//					singleBacks[int.Parse (invisibleIndex[0] as string) ].ChangeToOtherPlace
//						(Vector3.up*unitY+p1);
//				if(cameraPos.y>p2.y&&ip2.y!=p2.y+unitY)
//					singleBacks[int.Parse (invisibleIndex[1] as string) ].ChangeToOtherPlace
//						(Vector3.up*unitY+p2);
//				if(cameraPos.y<p1.y&&ip1.y!=p1.y-unitY)
//					singleBacks[int.Parse (invisibleIndex[0] as string) ].ChangeToOtherPlace
//						(p1-Vector3.up*unitY);
//				if(cameraPos.y<p2.y&&ip2.y!=p2.y-unitY)
//					singleBacks[int.Parse (invisibleIndex[1] as string) ].ChangeToOtherPlace
//						(p2-Vector3.up*unitY);
//			}
//		}
//		if (visibleIndex.Count == 1) {
//			Vector3 op=singleBacks[int.Parse (visibleIndex[0] as string) ].transform.position;
//			Vector3 ip1=singleBacks[int.Parse (invisibleIndex[0] as string) ].transform.position;
//			Vector3 ip2=singleBacks[int.Parse (invisibleIndex[1] as string) ].transform.position;
//			Vector3 ip3=singleBacks[int.Parse (invisibleIndex[2] as string) ].transform.position;
//			float signX=Mathf.Sign(cameraPos.x-op.x);
//			float signY=Mathf.Sign(cameraPos.y-op.y);
//			if(ip1!=op+signX*Vector3.right*unitX)
//				singleBacks[int.Parse (invisibleIndex[0] as string) ].ChangeToOtherPlace(op+signX*Vector3.right*unitX);
//			if(ip2!=op+signY*Vector3.up*unitY)
//				singleBacks[int.Parse (invisibleIndex[1] as string) ].ChangeToOtherPlace(op+signY*Vector3.up*unitY);
//			if(ip3!=op+signX*Vector3.right*unitX+signY*Vector3.up*unitY)
//				singleBacks[int.Parse (invisibleIndex[2] as string) ].ChangeToOtherPlace(op+signX*Vector3.right*unitX+signY*Vector3.up*unitY);
//		}


	
	}

}
