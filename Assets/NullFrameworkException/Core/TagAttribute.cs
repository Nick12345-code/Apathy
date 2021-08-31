using UnityEngine;

namespace NullFrameworkException
{
    // sealed means it can't be inherited from
    // standard is to have 'attribute' at the end of the class name
    /// <summary>
    /// This can be added to any string to make it render as the tag dropdown in the inspector
    /// </summary>
    public sealed class TagAttribute : PropertyAttribute
    {

    } 
}
