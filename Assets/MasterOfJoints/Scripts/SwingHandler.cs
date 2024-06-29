using System.Collections;
using UnityEngine;

namespace MasterOfJoints
{
    public class SwingHandler : MonoBehaviour
    {
        private const float MotorTimeDuration = 0.2f;
        [SerializeField] private HingeJoint _hingeJoint;

        private WaitForSeconds _waitForSeconds = new(MotorTimeDuration);
        private Coroutine _activeCoroutine;

        public void UseMotor()
        {
            if(_activeCoroutine != null)
            {
                StopCoroutine(_activeCoroutine);
            }

            _activeCoroutine = StartCoroutine(ProcessMotor());
        }

        private IEnumerator ProcessMotor()
        {
            _hingeJoint.useMotor = true;

            yield return _waitForSeconds;

            _hingeJoint.useMotor = false;
            _activeCoroutine = null;
        }
    }
}
