using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
	public List<Vector3> points;

	public float DistToPath(float dist)
	{
		return dist / Vector3.Distance(points[1], points[0]);
	}

	public Vector3 GetPathPoint(float position)
	{
		return (points[1] - points[0]) * position + points[0];
    }

	void OnDrawGizmos()
	{
		foreach (Vector3 point in points)
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(point, 1);
		}
	}
}
