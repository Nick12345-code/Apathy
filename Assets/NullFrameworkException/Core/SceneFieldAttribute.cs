using UnityEngine;

namespace NullFrameworkException
{
    public sealed class SceneFieldAttribute : PropertyAttribute
    {
        /// <summary>
        /// Converts a filepath to a SceneManager one for more friendly scene loading.
        /// </summary>
        /// <param name="_name"> The filepath being converted. </param>
        /// <returns></returns>
        public static string LoadableName(string _path)
        {
            // parts of path being ignored
            string start = "Assets/";
            string end = ".unity";

            // test if the path contains 'start' data, if so, remove it
            if (_path.StartsWith(start))
            {
                _path = _path.Substring(start.Length);
            }

            if (_path.EndsWith(end))
            {
                _path = _path.Substring(0, _path.LastIndexOf(end));
            }

            // return newly edited path
            return _path;
        }

        /// <summary>
        /// takes a local path and converts it into an asset path
        /// </summary>
        /// <param name="path"> the local path </param>
        /// <returns></returns>
        public static string ToAssetPath(string path) => $"Assets/{path}.unity";
    } 
}
