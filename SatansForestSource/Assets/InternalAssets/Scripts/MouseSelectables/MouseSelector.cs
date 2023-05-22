using SatansForest.InputServices;
using UnityEngine;

namespace SatansForest.MouseSelections
{
    public sealed class MouseSelector 
    {
        private readonly IInputService _inputService;
        private readonly Camera _mainCamera;

        public MouseSelector(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.OnLeftMouseButtonPressed += OnLeftMouseClicked;
            
            _mainCamera = Camera.main;
        }

        private void OnLeftMouseClicked()
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll( GetMousePosition(), Vector2.zero);
            
            foreach (var hit in hits)
            {
                if (hit.transform.TryGetComponent<IMouseSelectable>(out var selectable))
                    selectable.Select();
            }       
        }

        private Vector3 GetMousePosition()
            => _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}