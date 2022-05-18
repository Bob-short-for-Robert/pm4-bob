using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarController : MonoBehaviour
{
    public int HotBarSlotSize => gameObject.transform.childCount;
    private List<GameObject> hotbarSlots = new List<GameObject>();

    private KeyCode[] hotbarKeys =
        {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hotbarKeys.Length; i++)
        {
            if (Input.GetKeyDown(hotbarKeys[i]))
            {
                Debug.Log("Use item: " + i);
                
                return;
            }
        }
    }
    
    private void SetUpHotbarSlots()
    {
        for (int i = 0; i < HotBarSlotSize; i++)
        {
            GameObject item = new GameObject();
            hotbarSlots.Add(item);
        }
    }
}
