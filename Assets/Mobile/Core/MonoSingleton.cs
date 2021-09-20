using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NullFrameworkException
{
    // this makes sure T inherits from MonoSingleton
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T Instance
        {
            get
            {
                // the internal instance isn't set, attempt to find it in the scene
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();

                    // no instance was found, throw a NullReferenceException detailing what singleton caused the error
                    if (instance == null)
                    {
                        // shows exact class name of the generic type
                        throw new NullReferenceException($"No object of type: {typeof(T).Name} was found");
                    }
                }
                return instance;
            }
        }

        private static T instance = null;

        // has singleton been generated?
        public static bool isSingletonValid() => instance != null;

        // singletone instance won't be destroyed on scene load
        public static void FlagAsPersistent() => DontDestroyOnLoad(instance.gameObject);

        // finds instance within the scene
        protected T CreateInstance() => Instance;
    } 
}
