using System;
using UnityEngine;

namespace Utils
{
    public static class ActionHelper
    {
        public static Action<PlayerDirection> OnFingerMove;
        public static Action<bool,GameObject> OnPickupAction;
    }
}