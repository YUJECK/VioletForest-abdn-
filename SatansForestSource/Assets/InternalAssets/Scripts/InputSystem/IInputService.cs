using System;
using UnityEngine;

namespace VioletHell.InputServices
{
    public interface IInputService
    {
        event Action<Vector2> OnMoved;
        event Action OnInteracted;
        event Action OnRightMouseButtonPressed;
        event Action OnLeftMouseButtonPressed;
    }
}   