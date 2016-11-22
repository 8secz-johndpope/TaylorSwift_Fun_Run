using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;

public class TileManager : MonoBehaviour {

	// Use this for initialization
	public GameObject _sky;
	public Text timerText;
	public GameObject[] backgrounds;
	public GameObject[] tilePrefabs;
	public GameObject[] walls;
	private Transform playerTransform;
	private float spawnZ = -12.0f;
	private float tileLength = 12.0f;
	private int amnTilesOnScreen = 7;
	private float safeZone = 15.0f;
	private int lastPrefabIndex = 0;
	private List<GameObject> activeTiles;
	private float timer;
	private bool canSpawn = true;
	private bool canEmpty = true;
	void Start () {
		activeTiles = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		for (int i = 0; i < amnTilesOnScreen; i++) 
		{
			if(i < 5)
			SpawnTile (0);
			else
			SpawnTile (-1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
		{
			if (timer < 10) {
				SpawnTile (-1);
				DeleteTile ();
			} 
			else {
				if (canEmpty) 
				{
					SpawnTile (8);
					canEmpty = false;
				}
				SpawnTile (-2);
				DeleteTile ();
			}
		}
		timer += Time.deltaTime;
		if (timer > 25f && canSpawn == false) {
			SpawnWall (1);
			TimeToNull ();
			canEmpty = true;
			return;
		}
		if (timer > 10 && canSpawn == true) {
			
			SpawnWall (0);
		}
		//print (timer);
		timerText.text = timer.ToString ("F");
	}
	private void SpawnTile(int prefabIndex)
	{
		GameObject go;
		if(prefabIndex == -1)
		go = Instantiate(tilePrefabs[RandomPrefabIndex(1,5)]) as GameObject;
		else if (prefabIndex == -2) {
			go = Instantiate (tilePrefabs [RandomPrefabIndex (5, 8)]) as GameObject;
		}
		else
			go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add (go);

	}
	private void SpawnWall(int num)
	{
		GameObject wall;
		wall = Instantiate(walls[num]) as GameObject;
		wall.transform.SetParent (transform);
		wall.transform.position = Vector3.forward * spawnZ;
		//spawnZ += tileLength;
		canSpawn = false;

	}
	private void DeleteTile()
	{
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);

	}
	private void TimeToNull()
	{
		timer = 0;
		canSpawn = true;
	}
	private int RandomPrefabIndex(int a,int b)
	{
		if (tilePrefabs.Length <= 1)
			return 0;
		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex)
		{
			randomIndex = Random.Range (a, b);
		}
		lastPrefabIndex = randomIndex;
		return randomIndex;
	}
	public void BackgroundChancher(float one, float two, float three, float four, float five)
	{
		backgrounds [0].GetComponent<SpriteRenderer> ().DOFade (one, 0.5f);
		backgrounds [1].GetComponent<SpriteRenderer> ().DOFade (two, 0.5f);
		backgrounds [2].GetComponent<SpriteRenderer> ().DOFade (three, 0.5f);
		backgrounds [3].GetComponent<SpriteRenderer> ().DOFade (four, 0.5f);
		backgrounds [4].GetComponent<SpriteRenderer> ().DOFade (five, 0.5f);
	}
	public void SetActiveSky (bool _boolka)
	{
		if (_boolka == true)
			_sky.SetActive (true);
		else
			_sky.SetActive (false);

	}
}

