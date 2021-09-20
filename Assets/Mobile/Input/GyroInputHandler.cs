using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NullFrameworkException.Mobile
{
    public class GyroInputHandler : RunnableBehaviour
    {
        [System.Serializable]
        public class GyroscopeState
        {
            public Vector3 rotationDelta;
            public Quaternion deviceRotation;
        }

        public GyroscopeState gyroscopeData = new GyroscopeState();

        protected override void OnSetup(params object[] _params)
        {
            Input.gyro.enabled = SystemInfo.supportsGyroscope;
        }

        protected override void OnRun(params object[] _params)
        {
            gyroscopeData.deviceRotation = Input.gyro.attitude;
            gyroscopeData.rotationDelta = Input.gyro.rotationRateUnbiased;
        }

    }
}
