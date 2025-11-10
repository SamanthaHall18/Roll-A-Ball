using System;
using UnityEditor;
using UnityEngine;

public class Key : MonoBehaviour
{
    //attach to key object, then attach the Player Object to both boxes
    public GameObject player;
    public PlayerInventory PlayerInventory;

    private bool isPickedUp = false;
    public Vector3 offsetPosition = new Vector3(0, 1, 0); //float above the player
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && !isPickedUp)
        {
            if (PlayerInventory != null && !PlayerInventory.HasKey())
            {
                PlayerInventory.PickUpKey(gameObject);
                player = other.gameObject;
                isPickedUp = true;
            }
        }
    }

    private void Update() // makes the key float above the ball w/o rotating
    {
        if (isPickedUp && player is not null)
        {
            transform.position = player.transform.position + offsetPosition;
            transform.rotation = Quaternion.identity;
            
            // if you want the key to float
            transform.position = player.transform.position + 
                                 offsetPosition + 
                                 new Vector3(0, Mathf.Sin(Time.time * 3f) * 0.2f, 0);
        }
    }
}
