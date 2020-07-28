using UnityEngine;

namespace Scenes.Structures
{
    public class LoadMap : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        
    }
}
