using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Assets.Codebase.Mechanics.CameraHelper
{
    [RequireComponent(typeof(Collider2D))]
    public class LocationService : MonoBehaviour
    {
        [SerializeField]
        private Animator _cameraStateAnimator;
        [SerializeField]
        private string _stateName;

        public void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.gameObject.tag=="Player")
                _cameraStateAnimator.Play(_stateName);
        }
    }
}
    
