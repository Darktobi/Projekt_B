using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Prototype Solution
    public List<Key> keys;


	// Use this for initialization
	void Start ()
    {
        keys = new List<Key>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

    }

    public void addKey(Key key)
    {
        keys.Add(key);
    }

    public void removeKey(Key key)
    {
        keys.Remove(key);
    }

    public bool hasRightKey (Key.KeyColor color)
    {
       foreach(Key key in keys)
        {
            if (key.GetKeyColor() == color)
            {
                removeKey(key);
                return true;
            }
        }

        return false;
    }
}
