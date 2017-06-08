using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
	public Color mainColor;
	public float speed;

	public Path path;
	public float pathPosition;

	public Renderer objectRenderer;

	void Update ()
	{
		float dist = speed * Time.deltaTime;
		pathPosition += path.DistToPath(dist);
        transform.position = path.GetPathPoint(pathPosition);
		if (pathPosition >= 1 || (mainColor.r == 0 && mainColor.g == 0 && mainColor.b == 0))
		{
			Destroy(gameObject);
		}
	}

	public void UpdateColor()
	{
		objectRenderer.material.color = mainColor;
	}
}
