using UnityEditor;
using UnityEngine;

namespace Varguiniano
{
    /// <inheritdoc />
    /// <summary>
    /// Class with some utilities for editors.
    /// </summary>
    public abstract class ExtendedEditor<T> : Editor where T : MonoBehaviour
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
            serializedObject.Update();
            PaintUi();
            serializedObject.ApplyModifiedProperties();
            EditorApplication.update.Invoke();
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