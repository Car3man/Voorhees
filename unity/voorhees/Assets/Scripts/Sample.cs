using System;
using UnityEngine;
using Voorhees;

public struct Player 
{
	public string name;
	public int gold;
	[JsonKey("age")]
	public float ageYears;
	[JsonIgnore]
	public string metadata;
}

public class Sample : MonoBehaviour
{
    private void Start()
    {
	    Player bilbo = new()
	    {
		    name = "Bilbo Baggins",
		    gold = 99,
		    ageYears = 111.32f,
		    metadata = "This should be ignored"
	    };

	    string bilboJson = JsonMapper.ToJson(bilbo);
	    Debug.Log(bilboJson); // {"name":"Bilbo Baggins","gold":99,"age":111.32}

	    int[] fibonacci = {1, 1, 2, 3, 5, 8};
	    string fibonacciJson = JsonMapper.ToJson(fibonacci);
	    Debug.Log(fibonacciJson); // [1,1,2,3,5,8]
    }
}
