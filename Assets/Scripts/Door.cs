using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    // attach to door object
    public PlayerInventory PlayerInventory;
    public GameObject door; // visual mesh
    
    public float speed = 2f;
    public float targetY = -5f;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Door Triggered by: " + other.name);
        if (other.name == "Player" && PlayerInventory != null &&
            PlayerInventory.HasKey())
        { 
            PlayerInventory.UseKey();
            UnlockDoor(); 
        }
    }
    
    public void UnlockDoor()
        {
            StartCoroutine(SlideDoorDown());
        }

    private IEnumerator SlideDoorDown()
    {
        Vector3 targetPos = new Vector3(door.transform.position.x, targetY, door.transform.position.z);
        while (Vector3.Distance(door.transform.position, targetPos) > 0.01f)
        {
            door.transform.position = Vector3.MoveTowards(
                door.transform.position,
                targetPos,
                speed * Time.deltaTime);
            yield return null;
        }
    }
}
