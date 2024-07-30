using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.Mechanics.CameraHelper
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraHelper : MonoBehaviour
    {
        private IInterestable _interestableObject;

        [Inject]
        private void Construct(IInterestable interestableObject)
        {
            _interestableObject = interestableObject;
        }

        private void Start()
        {
            GetComponent<CinemachineVirtualCamera>().Follow = _interestableObject.GetTransform;
            Destroy(this);
        }
    }
}