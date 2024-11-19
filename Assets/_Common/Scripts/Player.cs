using UnityEngine;

using zer0.Property.Runtime;

namespace zer0
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        [PropertyObserver("OnChanged")]
        private string Name = "";

        private void OnChanged()
        {
            Debug.Log("Name: " + Name);
        }
    }
}
