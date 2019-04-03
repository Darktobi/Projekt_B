using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCode : MonoBehaviour {

    [SerializeField] private string code;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.addDoorCode(this);
            Destroy(gameObject);
        }
        
    }

    public string getCode()
    {
        return code;
    }

}
