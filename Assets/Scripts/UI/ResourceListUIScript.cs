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
            Dictionary<string, int> collected = ResourceManager.GetCollected();
            foreach (var vResource in collected)
            {
                GameObject resUi = this.transform.Find(vResource.Key)?.gameObject;
                if (resUi == null)
                {
                    resUi = Instantiate(resourceUi, this.transform);
                    resUi.name = vResource.Key;
                }

                foreach (Text child in resUi.GetComponentsInChildren<Text>())
                {
                    if (child.name == "ResourceLabel")
                    {
                        child.text = vResource.Key;
                    }
                    else if (child.name == "ResourceCount")
                    {
                        child.text = vResource.Value.ToString();
                    }
                }
            }
        }
    }
}
