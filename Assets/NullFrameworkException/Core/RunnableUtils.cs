using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NullFrameworkException
{
    public static class RunnableUtils
    {
        /// <summary>
        /// attempts to retrieve the runnable behaviour from the passed gameObject or its children
        /// </summary>
        /// <param name="_runnable"> the reference the runnable will be set to </param>
        /// <param name="_from"> the gameObject we are attempting to get a runnable from </param>
        public static bool Validate<TRunnable>(ref TRunnable _runnable, GameObject _from, bool _optional) where TRunnable : IRunnable
        {
            // if the passed runnable is already set, return true
            if (_runnable != null)
            {
                return true;
            }

            // if the passed runnable isn't set, attempt to get it from the passed GameObject
            if (_runnable == null)
            {
                _runnable = _from.GetComponent<TRunnable>();

                // we successfully retrieve the component, return true
                if (_runnable != null)
                {
                    return true;
                }
            }

            // if the passed runnable isn't set, attempt to get it from the passed GameObject's children
            if (_runnable == null)
            {
                _runnable = _from.GetComponentInChildren<TRunnable>();

                // we successfully retrieve the component, return true
                if (_runnable != null)
                {
                    return true;
                }
            }

            if (!_optional)
            {
                // the second parameter of Unity's debug.log is the object associated with the log message
                Debug.LogException(new NullReferenceException($"Component {typeof(TRunnable).Name} is not present in the hierarchy of the gameObject {_from.name}."), _from); 
            }

            return false;
        }

        /// <summary>
        /// attempts to validate then setup the IRunnable, returning whether or not it succeeded
        /// </summary>
        /// <param name="_runnable"> the runnable being setup </param>
        /// <param name="_from"> the gameObject the runnable is attached to </param>
        /// <param name="_params"> any additional information the Runnable's setup function needs </param>
        public static bool Setup<TRunnable>(ref TRunnable _runnable, GameObject _from, bool _optional, params object[] _params) where TRunnable : IRunnable
        {
            if (Validate(ref _runnable, _from, _optional))
            {
                _runnable.Setup(_params);
                return true;
            }
            
            // we failed to validate the component, so return false
            return false;
        }

        /// <summary>
        /// attempts to validate the runnable, if successful run it using the information provided
        /// </summary>
        /// <param name="_runnable"> the runnable being run </param>
        /// <param name="_from"> the gameObject the runnable is attached to </param>
        /// <param name="_params"> any additional information the Runnable's run function needs </param>
        public static void Run<TRunnable>(ref TRunnable _runnable, GameObject _from, bool _optional, params object[] _params) where TRunnable : IRunnable
        {
            // validate component just in case we didn't do it earlier
            if (Validate(ref _runnable, _from, _optional))
            {
                _runnable.Run(_params);
            }
        }
    } 
}
