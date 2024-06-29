using UnityEngine;

namespace MasterOfJoints
{
    public class UserClickHandler : MonoBehaviour
    {
        [SerializeField] private SwingHandler _swingHandler;
        [SerializeField] private CatapulteHandler _catapulteHandler;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _swingHandler.UseMotor();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _catapulteHandler.Shoot();
            }
        }
    }
}
