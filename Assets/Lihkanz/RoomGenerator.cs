using UnityEngine;
using System.Collections;

public class RoomGenerator : MonoBehaviour {

    public int totalAmountOfRooms, currentAmtRooms;
    public enum RoomType{ monster, puzzle, trap, special }
    RoomType currentRoomType;

	// Use this for initialization
	void Start () {
        GenerateDungeon();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void GenerateDungeon()
    {
        while(currentAmtRooms < totalAmountOfRooms)
        {
            currentRoomType = (RoomType)Random.Range(0,4);
            GenerateRoom(currentRoomType);
            currentAmtRooms++;
        }
    }

    void GenerateRoom(RoomType _currentRoomType)
    {
        Debug.Log(_currentRoomType);
    }
}
