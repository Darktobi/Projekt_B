using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public List<Key> keys;
    public bool hasGravityChanger;


	// Use this for initialization
	void Start ()
    {
        keys = new List<Key>();
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
}
