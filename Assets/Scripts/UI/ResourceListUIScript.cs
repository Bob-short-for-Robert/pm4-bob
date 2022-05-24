using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UI
{
    public class ResourceListUIScript : MonoBehaviour
    {
        public GameObject resourceUi;

        private void Update()
        {
            List<Resource> inventory = ResourceManager.GetInventory();
            foreach (var vResource in inventory)
            {
                GameObject resUi = this.transform.Find(vResource.Name)?.gameObject;
                if (resUi == null)
                {
                    resUi = Instantiate(resourceUi, this.transform);
                    resUi.name = vResource.Name;
                }

                foreach (Text child in resUi.GetComponentsInChildren<Text>())
                {
                    if (child.name == "ResourceLabel")
                    {
                        child.text = vResource.Name;
                    }
                    else if (child.name == "ResourceCount")
                    {
                        child.text = vResource.quantity.ToString();
                    }
                }
            }
        }
    }
}
