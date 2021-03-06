using UnityEngine;
using System.Collections;

public class Rot3rdCamera : FCCamera {
	
	public float _distance;
	public float _birdView;
	
	public override void UpdatePosAndRotation (Transform target, Transform target2, bool enableClamp, ref Vector3 pos, ref Vector3 lookat)
	{
		Vector3 lastPos = pos;
		
		Vector3 pos2 = (target2 == null ? Vector3.zero : target2.position);
		Vector3 dir = pos2 - target.position;
		dir.y = 0.0f;
		// normally no change on axis Y.
		Quaternion rot = Quaternion.FromToRotation(Vector3.forward, dir);
		Vector3 roted = rot * (Vector3.back * (_distance + dir.magnitude));
		
		//if(!_needRotateBlend)
		//{
		//	roted = Vector3.zero;
		//}
		//roted = Vector3.zero;
		roted.y = _birdView;
		lookat = pos2 + Vector3.up * heightOffset;
		pos = pos2 + roted;
		
		if(enableClamp) {
			Vector3 nextMove = pos - lastPos;
			nextMove.y = 0.0f;
			float nextMoveLen = nextMove.magnitude;
			nextMoveLen = Mathf.Min(_cameraSpeedCurve.Evaluate(nextMoveLen), nextMoveLen) - nextMoveLen;
			pos = pos + nextMove.normalized * nextMoveLen;
			
			Vector3 bound = pos - pos2;
			bound.y = 0.0f;
			pos += bound.normalized * Mathf.Max(0.0f, dir.magnitude + _distance - bound.magnitude);
		}
	}
}
