using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Hud
{
    public class ResourceListUIScript : MonoBehaviour
    {
        public GameObject resourceUi;

        private void Update()
        {
            var collected = ResourceManager.GetCollected();
            foreach (var vResource in collected)
            {
                var resUi = this.transform.Find(vResource.Key)?.gameObject;
                if (resUi == null)
                {
                    resUi = Instantiate(resourceUi, this.transform);
                    resUi.name = vResource.Key;
                }

                foreach (var child in resUi.GetComponentsInChildren<Text>())
                {
                    child.text = child.name switch
                    {
                        "ResourceLabel" => vResource.Key,
                        "ResourceCount" => vResource.Value.ToString(),
                        _ => child.text
                    };
                }
            }
        }
    }
}
