using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public List<Key> keys;
    public List<DoorCode> doorCodes;
    public bool hasGravityChanger;

    private int reactorPieces;


    // Use this for initialization
    void Start ()
    {
        keys = new List<Key>();
        reactorPieces = 0;
        hasGravityChanger = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        
    }

    public void addKey(Key key)
    {
        keys.Add(key);
    }

    public void addDoorCode(DoorCode doorCode)
    {
        doorCodes.Add(doorCode);
        Debug.Log("Folgenden Code erhalten: " + doorCode.getCode());
    }

    public void removeDoorCode(DoorCode doorCode)
    {
        doorCodes.Remove(doorCode);
    }


    public bool hasRightKey (Key.KeyColor neededKeyColor)
    {
       foreach(Key key in keys)
        {
            if (key.GetKeyColor() == neededKeyColor)
            {
                return true;
            }
        }

        return false;
    }

    public bool hasRightDoorCode (string code)
    {
        foreach(DoorCode doorCode in doorCodes)
        {
            if(doorCode.getCode() == code)
            {
                removeDoorCode(doorCode);
                return true;
            }
        }
        return false;
    }

    public int getCurrentKey (Key.KeyColor color)
    {
        int keyCount = 0;

        foreach(Key key in keys)
        {
            if(key.GetKeyColor() == color)
            {
                keyCount++;
            }
        }

        return keyCount;
    }

    public int getRepairPiece()
    {
        return reactorPieces;
    }

    public void addRepairPiece()
    {
        reactorPieces++;
    }

    public void removeRepairPieces(int numberToRemove)
    {
        reactorPieces -= numberToRemove;
    }
}
