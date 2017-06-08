using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public float speed;
	public Color color;

	public Renderer objectRenderer;
	
	void Update ()
	{
		UpdateColor();
		transform.position += Vector3.up * speed * Time.deltaTime;
		if (objectRenderer.isVisible == false)
		{
			Destroy(gameObject);
		}
	}

	public void UpdateColor()
	{
		objectRenderer.material.color = color;
	}

	void OnTriggerEnter(Collider coll)
	{
		EnemyBase enemyHit = coll.GetComponent<EnemyBase>();
		if (enemyHit)
		{
			enemyHit.mainColor.r = Mathf.Max(0, enemyHit.mainColor.r - color.r);
			enemyHit.mainColor.g = Mathf.Max(0, enemyHit.mainColor.g - color.g);
			enemyHit.mainColor.b = Mathf.Max(0, enemyHit.mainColor.b - color.b);
			Destroy(gameObject);
        }
	}
}
