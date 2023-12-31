  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//I used this tutorial on classes and constructors: https://www.youtube.com/watch?v=cbk6p1V9fJQ
public class Items
{
	public int itemDamage { get { return _itemDamage; } }
	public string itemName { get { return _itemName; } }
	public string itemType { get { return _itemType; } }
	public string itemDirection { get {return _itemDirection; } }
	public GameObject objectPrefab { get { return _objectPrefab; } }

	//serialize private variables
	[Header ("Item Settings")]
	[SerializeField]
	private int _itemDamage;
	[SerializeField]
	private string _itemName;
	[SerializeField]
	private string _itemType;
	[SerializeField]
	private string _itemDirection;
	[SerializeField]
	private GameObject _objectPrefab;

	public Items(int Damage, string Name, string Type, string Direction, GameObject objectPrefab)
	{
		this._itemDamage = Damage;
		this._itemName = Name;
		this._itemType = Type;
		this._itemDirection = Direction;
		this._objectPrefab = objectPrefab;
	}
}

public class ItemSpawning : MonoBehaviour {

	//array from the Item class
	[Header("Item Settings")]
	public Items[] Item = new Items[7];
	public static GameObject Spawn1;
	public static GameObject Spawn2;
	public static GameObject Spawn3;

	public GameObject[] spawnPoints = new GameObject[3] {Spawn1, Spawn2, Spawn3};
	public float timer = 2f;

	void Start(){
		
		//CreateHazards ();
		//Reference for invoke repeating: chiskugler.com/2015/01/06/unity-invoke-and-coroutines/
	}

	void Update(){
		//timer -= 1 * Time.deltaTime;
		//if (timer >= 0);
		CreateHazards();
	}

	//This function will instantiate a random item and issue damage or health boost
	void CreateHazards(){
		int spawnIndex = UnityEngine.Random.Range(0,2);

		GameObject itemPrefab = Item[Random.Range(0, Item.Length)].objectPrefab;

		var randomSpwanPoint = spawnPoints [spawnIndex];

	
		//This section will choose a spwan point
		Debug.Log ("The spawn point is: " + randomSpwanPoint);
		Instantiate (itemPrefab, this.transform.position, Quaternion.identity);

		if (spawnPoints [spawnIndex] = Spawn1) {

			Instantiate (itemPrefab, this.transform.position, Quaternion.identity);
			itemPrefab.transform.Translate (Vector3.forward * Time.deltaTime, Space.World);
			Debug.Log ("Creating prefab");
		} 

		else if (spawnPoints [spawnIndex] = Spawn2) {

			Instantiate (itemPrefab, this.transform.position, Quaternion.identity);
			itemPrefab.transform.Translate (Vector3.back * Time.deltaTime, Space.World);
			Debug.Log ("Creating prefab");
		} 

		else if (spawnPoints [spawnIndex] = Spawn3) {
			Instantiate (itemPrefab, this.transform.position, Quaternion.identity);
			itemPrefab.transform.Translate (Vector3.down * Time.deltaTime, Space.World);
			Debug.Log ("Creating prefab");
		}
	}
		
}
