using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public enum KeyColor {Red, Blue, Green};

    [SerializeField]private KeyColor color;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.addKey(this);
            Destroy(gameObject);
        }
    }

    public KeyColor GetKeyColor()
    {
        return color;
    }

}
