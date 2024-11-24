using UnityEngine;

using zer0.Property.Runtime;

namespace zer0
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private string Name = "";

        public override string ToString()
        {
            return $"Player: {Name}";
        }
    }
}
