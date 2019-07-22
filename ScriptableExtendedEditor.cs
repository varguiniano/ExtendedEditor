using UnityEditor;
using UnityEngine;

namespace Varguiniano
{
    /// <inheritdoc />
    /// <summary>
    /// Class with some utilities for editors.
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
            PaintProperty(serializedObject.FindProperty(name), includeChildren);

        /// <summary>
        /// Paints the property given.
        /// </summary>
        /// <param name="serializedProperty">Property to paint.</param>
        /// <param name="includeChildren">Should it include children?</param>
        protected void PaintProperty(SerializedProperty serializedProperty, bool includeChildren = false) =>
            EditorGUILayout.PropertyField(serializedProperty, includeChildren);

        /// <summary>
        /// Paints the property given.
        /// </summary>
        /// <param name="rect">Rect to paint to.</param>
        /// <param name="serializedProperty">Property to paint.</param>
        /// <param name="includeChildren">Should it include children?</param>
        protected void PaintProperty(Rect rect, SerializedProperty serializedProperty, bool includeChildren = false) =>
            EditorGUI.PropertyField(rect, serializedProperty, includeChildren);
        
        /// <summary>
        /// Paints the property given.
        /// </summary>
        /// <param name="serializedProperty">Property to look into.</param>
        /// <param name="name">Name of that property.</param>
        /// <param name="includeChildren">Should it include children?</param>
        protected void PaintPropertyFromProperty(SerializedProperty serializedProperty, string name, bool includeChildren = false) =>
            EditorGUILayout.PropertyField(serializedProperty.FindPropertyRelative(name), includeChildren);

        /// <summary>
        /// Paints the property given.
        /// </summary>
        /// <param name="rect">Rect to paint to.</param>
        /// <param name="serializedProperty">Property to look into.</param>
        /// <param name="name">Name of that property.</param>
        /// <param name="includeChildren">Should it include children?</param>
        protected void PaintPropertyFromProperty(Rect rect, SerializedProperty serializedProperty, string name, bool includeChildren = false) =>
            EditorGUI.PropertyField(rect, serializedProperty.FindPropertyRelative(name), includeChildren);
    }
}