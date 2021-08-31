using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NullFrameworkException.Mobile.InputHandling
{
    public class MobileInputManager : MonoSingleton<MobileInputManager>
    {
        public JoystickInputHandler joystick;
        public SwipeInputHandler swiping;
        public GyroInputHandler gyroscope;

        public static GyroInputHandler.GyroscopeState GetGyroscopeState() => Instance.gyroscope != null ? Instance.gyroscope.gyroscopeData : new GyroInputHandler.GyroscopeState();

        /// <summary>
        /// Attempt to get the axis of the joystick attached to the system.
        /// </summary>
        /// <returns></returns>
        public static Vector2 GetJoystickAxis() => Instance.joystick != null ? Instance.joystick.Axis : Vector2.zero;

        private void Start()
        {
            RunnableUtils.Setup(ref joystick, gameObject, true, this);
            RunnableUtils.Setup(ref swiping, gameObject, true);
            RunnableUtils.Setup(ref gyroscope, gameObject, true);
        }

        private void Update()
        {
            RunnableUtils.Run(ref joystick, gameObject, true);
            RunnableUtils.Run(ref swiping, gameObject, true);
            RunnableUtils.Run(ref gyroscope, gameObject, true);
        }
    } 
}
