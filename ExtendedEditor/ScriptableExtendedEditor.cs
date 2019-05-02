using UnityEditor;
using UnityEngine;

namespace Varguiniano
{
    /// <inheritdoc />
    /// <summary>
    /// Class with some utilities for editors.
    /// Refer to: https://gist.github.com/varguiniano/2a488f1e438ca334208eb8647fc99176
    /// </summary>
    public abstract class ScriptableExtendedEditor<T> : Editor where T : ScriptableObject
    {
        /// <summary>
        /// Reference to the object being edited.
        /// </summary>
        protected T TargetObject => (T) target;

        /// <inheritdoc />
        /// <summary>
        /// Paint the UI and apply the properties.
        /// </summary>
        public override void OnInspectorGUI()
        {
            PaintUi();
            serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Paint the UI.
        /// </summary>
        protected abstract void PaintUi();

        /// <summary>
        /// Paints the property given.
        /// </summary>
        /// <param name="name">Name of that property.</param>
        /// <param name="includeChildren">Should it include children?</param>
        protected void PaintProperty(string name, bool includeChildren = false) =>
            EditorGUILayout.PropertyField(serializedObject.FindProperty(name), includeChildren);
    }
}