using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NullFrameworkException
{
    public abstract class RunnableBehaviour : MonoBehaviour, IRunnable
    {
        public bool Enabled { get; set; } = true;

        private bool isSetup = false;

        public void Setup(params object[] _params)
        {
            // if runnable already setup, display a warning
            if (isSetup)
            {
                throw new InvalidOperationException($"GameObject {gameObject.name} already setup!");
            }

            // run the OnSetup function and flag this component as setup
            OnSetup(_params);
            isSetup = true;
        }

        public void Run(params object[] _params)
        {
            // if the runnable is enabled and setup, run the OnRun function with passed values
            if (Enabled && isSetup)
            {
                OnRun(_params);
            }
        }

        protected abstract void OnSetup(params object[] _params);
        protected abstract void OnRun(params object[] _params);

    }
}
