using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zer0.Property.Runtime;

namespace zer0.Property
{
    public class PropertyTester : MonoBehaviour
    {
        [SerializeField]
        private bool _displayPlayer = true;

        [SerializeField]
        [PropertyDisplayer("_displayPlayer", true)]
        [PropertyObserver("OnPlayerChanged")]
        private Player _player;

        [SerializeField]
        [PropertyObserver("OnPlayerChanged")]
        private string Name;

        private void OnPlayerChanged()
        {
            Debug.Log(_player);
        }
    }
}
