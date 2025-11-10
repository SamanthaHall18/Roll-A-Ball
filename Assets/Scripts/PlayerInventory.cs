using UnityEditor.Analytics;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // attach to Player object, you do NOT need to attach anything to Current Key
    public GameObject currentKey;

    public void PickUpKey(GameObject key)
    {
        if (currentKey == null)
        {
            currentKey = key;
        }
    }

    public bool HasKey()
    {
        return currentKey != null;
    }

    public void UseKey()
    {
        if (currentKey != null)
        {
            currentKey.SetActive(false);
            currentKey = null;
        }
    }
}
