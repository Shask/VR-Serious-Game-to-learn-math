using UnityEngine;
using System.Collections;

public class FalconRigidBody : MonoBehaviour {

	public float k = 0.5f;
 	public float mass = 1;
	public Vector3 device_scale = new Vector3(1.0f,1.0f,1.0f);//send 1/4 size in the z dimension
	public int bodyId = 0;
	public Vector3 linearFactors = new Vector3(1.0f,1.0f,1.0f);
	public Vector3 angularFactors = new Vector3(1.0f,1.0f,1.0f);
	public float friction = 0.8f;
	public bool isGrabbed = false;
	
	// Use this for initialization
	void Start () {
		bodyId = getNextBodyId();
	 	refreshShape();
	 
	}
	
	public void refreshShape(){
		Mesh m = GetComponent<MeshFilter>().mesh;
   	 	Vector3[] v = m.vertices;
	 	int[] f = m.triangles;
	 	float[] shape = new float[f.Length*3];

		for(int i=0;i<f.Length;i++){
			Vector3 vert = v[f[i]];
				vert.Scale(transform.localScale);
				vert.Scale(device_scale);
//				vert = transform.localRotation*vert;
			
			shape[i*3] = vert.x;
			shape[i*3+1] = vert.y;
			shape[i*3+2] = vert.z;
		}
		Vector3 localPosition = transform.localPosition;
		localPosition.Scale(device_scale);

		
		FalconUnity.sendDynamicShape(bodyId,shape, f.Length/3, mass, k, localPosition, transform.localRotation, linearFactors, angularFactors, friction);
	}

	
	// Update is called once per frame
	public void FixedUpdate () {
		Vector3 pos;
		Quaternion orient;
		if (!isGrabbed) {
			bool res = FalconUnity.getDynamicShapePose (bodyId, out pos, out orient);
			if (!res) {
				//Debug.Log("Error getting object pose "+ bodyId);
				return;
			}	
			transform.localPosition = pos;
			transform.localRotation = orient;

		}
		//FalconUnity.updateDynamicShape(bodyId, mass, k, linearFactors, angularFactors, friction);
		}
	public void StopFlippinShit()
	{
		linearFactors = new Vector3(0f,0f,0f);
		angularFactors = new Vector3(0f,0f,0f);
	}
	public void LetsFlippinShit()
	{
		linearFactors = new Vector3(1.0f,1.0f,1.0f);
		angularFactors = new Vector3(1.0f,1.0f,1.0f);
	}


	public void DropItem(Transform t)
	{

		Quaternion orient;
		Vector3 pos;
		bool res = FalconUnity.getDynamicShapePose (bodyId,out pos , out orient);
		transform.position = pos + new Vector3(0,0,0.5f);
		/*bool res = FalconUnity.getDynamicShapePose (bodyId, out pos, out orient);
		pos = t.position;
		//pos.z += 1f;
		//pos.z == 0.5f;
		//FalconUnity.sendDynamicShape(bodyId,shape, f.Length/3, mass, k, localPosition, transform.localRotation, linearFactors, angularFactors, friction);
		Debug.Log (pos);
		FalconUnity.setDynamicShapePose (bodyId, pos, orient);*/
		isGrabbed = false;
		
		//FalconUnity.sendDynamicShape(bodyId,shape, f.Length/3, mass, k, localPosition, transform.localRotation, linearFactors, angularFactors, friction);

	}


	
	static object Lock = new object();
	private static int curId = -1;
	public static int getNextBodyId() {
		lock(Lock) {
			curId ++;
			return curId;
		}
	}


}
