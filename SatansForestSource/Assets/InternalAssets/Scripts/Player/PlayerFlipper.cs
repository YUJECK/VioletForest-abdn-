using SatansForest.InputServices;
using UnityEngine;
using Zenject;

namespace SatansForest.PlayerServices
{
    public class PlayerFlipper : MonoBehaviour
    {
        private IInputService _inputService;
        private bool _faceRight = true;
        
        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.OnMoved += OnMoved;
        }

        private void OnMoved(Vector2 obj)
        {
            if(obj.x > 0 && !_faceRight)
            {
                transform.Rotate(0f, 180f, 0f);
                _faceRight = true;
            }
            else if (obj.x < 0 && _faceRight)
            {
                transform.Rotate(0f, -180f, 0f);
                _faceRight = false;
            }
        }
    }
}
