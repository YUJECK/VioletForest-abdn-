using System.Collections.Generic;
using SatansForest.InputServices;
using UnityEngine;
using Zenject;

namespace SatansForest.MouseSelections
{
    public sealed class MouseSelector : ITickable
    {
        private readonly IInputService _inputService;
        private readonly Camera _mainCamera;

        private readonly List<IMouseSelectable> _currentPointed = new();
        
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

        public void Tick()
        {
            var hits = Physics2D.RaycastAll(GetMousePosition(), Vector2.zero);

            foreach (var selectable in _currentPointed)
            {
                selectable.Deselect();
            }
            _currentPointed.Clear();
            
            foreach (var hit in hits)
            {
                if (hit.transform.TryGetComponent<IMouseSelectable>(out var selectable) && !_currentPointed.Contains(selectable))
                {
                    selectable.OnPointed();
                    _currentPointed.Add(selectable);
                }
            }
        }
    }
}