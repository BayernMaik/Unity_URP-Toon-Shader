#if (UNITY_EDITOR)

using UnityEngine;
using UnityEditor;
using System;

public class ShaderGUI_1_Shade_Shadow_Highlight : ShaderGUI
{
    [SerializeField] private bool _foldout_SurfaceInputs = false;
    [SerializeField] private bool _foldout_AdvancedOptions = false;
    private Color _backgroundColor = new Color(0.85f, 0.85f, 0.85f);

    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] materialProperties)
    {
        #region Surface Inputs
        GUI.backgroundColor = _backgroundColor;
        _foldout_SurfaceInputs = EditorGUILayout.BeginFoldoutHeaderGroup(_foldout_SurfaceInputs, "Surface Inputs");
        GUI.backgroundColor = Color.white;
        if (_foldout_SurfaceInputs)
        {
            #region Color
            MaterialProperty _color = ShaderGUI.FindProperty("_Color", materialProperties);
            EditorGUILayout.LabelField(_color.displayName);
            _color.colorValue = EditorGUILayout.ColorField(_color.colorValue);
            #endregion
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        #endregion

        #region Advanced Options
        GUI.backgroundColor = _backgroundColor;
        _foldout_AdvancedOptions = EditorGUILayout.BeginFoldoutHeaderGroup(_foldout_AdvancedOptions, "Advanced Options");
        GUI.backgroundColor = Color.white;
        if (_foldout_AdvancedOptions)
        {
            materialEditor.RenderQueueField();
            materialEditor.EnableInstancingField();
            materialEditor.DoubleSidedGIField();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        #endregion
    }
}
#endif