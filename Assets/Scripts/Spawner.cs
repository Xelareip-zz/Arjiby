using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public List<Path> paths;

	public List<Color> colors;

	public GameObject enemiesHolder;
	public GameObject enemyPrefab;

	public float spawnFrequency;

	void Start()
	{
		StartCoroutine(SpawnIn());
	}

	private IEnumerator SpawnIn()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnFrequency);
			Spawn();
		}
	}

	private void Spawn()
	{
		int pathId = Random.Range(0, paths.Count);
		Path pickedPath = paths[pathId];
		GameObject newEnemy = Instantiate(enemyPrefab, pickedPath.points[0], Quaternion.identity);
		newEnemy.transform.SetParent(enemiesHolder.transform);

		EnemyBase enemyScript = newEnemy.GetComponent<EnemyBase>();
		enemyScript.mainColor = colors[Random.Range(0, colors.Count)];
		enemyScript.UpdateColor();
		enemyScript.path = pickedPath;
	}

}
