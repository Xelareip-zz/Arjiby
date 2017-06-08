using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
	public Collider objectCollider;

	public GameObject weapon;

	public Vector3 nullVect;

	void Update ()
	{
		Vector3 position = nullVect;
        if (Input.touchCount != 0)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
				position = touch.position;
			}
        }
		else if (Input.GetMouseButtonDown(0))
		{
			position = Input.mousePosition;
		}

		if (position == nullVect)
		{
			return;
		}

		Ray touchRay = Camera.main.ScreenPointToRay(position);

		RaycastHit hit;
		if (objectCollider.Raycast(touchRay, out hit, float.MaxValue))
		{
			Spawn();
		}
	}

	private void Spawn()
	{
		if (WeaponManager.Instance.CanSpawn())
		{
			GameObject weaponObj = Instantiate(weapon, transform.position, Quaternion.identity);

			Weapon weaponScript = weaponObj.GetComponent<Weapon>();
			weaponScript.color = WeaponManager.Instance.nextColor;
			weaponScript.UpdateColor();
			WeaponManager.Instance.Spawned();
		}
	}
}
