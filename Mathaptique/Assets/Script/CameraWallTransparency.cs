using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
public class CameraWallTransparency : MonoBehaviour {

	public float clipMoveTime = 0.05f;              // time taken to move when avoiding cliping (low value = fast, which it should be)
	public float returnTime = 0.4f;                 // time taken to move back towards desired position, when not clipping (typically should be a higher value than clipMoveTime)
	public float sphereCastRadius = 10f;           // the radius of the sphere used to test for object between camera and target
	public bool visualiseInEditor;                  // toggle for visualising the algorithm through lines for the raycast in the editor
	public float closestDistance = 0.5f;            // the closest distance the camera can be from the target
	public bool protecting { get; private set; }    // used for determining if there is an object between the target and the camera
	public string dontClipTag = "Player";           // don't clip against objects with this tag (useful for not clipping against the targeted object)
	
	public Transform m_Cam;                  // the transform of the camera
	public Transform m_Pivot;                // the point at which the camera pivots around
	private float m_OriginalDist;             // the original distance to the camera before any modification are made
	private float m_MoveVelocity;             // the velocity at which the camera moved
	private float m_CurrentDist;              // the current distance from the camera to the target
	private Ray m_Ray;                        // the ray used in the lateupdate for casting between the camera and the target
	private RaycastHit[] m_Hits;              // the hits between the camera and the target
//	private RayHitComparer m_RayHitComparer;  // variable to compare raycast hit distances

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
}