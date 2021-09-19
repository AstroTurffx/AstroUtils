using UnityEngine;

namespace AstroTurffx.AstroUtils.Editor
{
    public class FoldAttribute : PropertyAttribute
    {
        public string name;
        public bool continuous;

        /// <summary>Adds the property to a specified foldout group.</summary>
        /// <param name="name">Name of the foldout group.</param>
        /// <param name="continuous">Toggle to fold variables below it.</param>
        public FoldAttribute(string name, bool continuous = false)
        {
            this.continuous = continuous;
            this.name = name;
        }
    }
}