using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	private static WeaponManager instance;
	public static WeaponManager Instance
	{
		get
		{
			return instance;
		}
	}

	public List<Color> colors;
	public Color nextColor;

	public float spawnSpeed;
	public int munitions;


	void Awake()
	{
		instance = this;
		StartCoroutine(AddMunitions());
	}

	public bool CanSpawn()
	{
		return munitions > 0;
	}

	public void ChooseColor()
	{
		nextColor = colors[Random.Range(0, colors.Count)];
	}

	public void Spawned()
	{
		ChooseColor();
		--munitions;
	}

	private IEnumerator AddMunitions()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnSpeed);
			++munitions;
		}
	}
}
