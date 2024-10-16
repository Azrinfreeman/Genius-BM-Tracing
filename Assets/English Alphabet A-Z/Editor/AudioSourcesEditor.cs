using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

///Developed By Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

[CustomEditor (typeof(AudioSources))]
public class AudioSourcesEditor: Editor
{
	public override void OnInspectorGUI ()
	{
		AudioSources audioSources = (AudioSources)target;//get the target

        EditorGUILayout.Separator();
        #if !(UNITY_5 || UNITY_2017 || UNITY_2018_0 || UNITY_2018_1 || UNITY_2018_2)
                //Unity 2018.3 or higher
                EditorGUILayout.BeginHorizontal();
                GUI.backgroundColor = Colors.cyanColor;
                EditorGUILayout.Separator();
                if (GUILayout.Button("Apply", GUILayout.Width(70), GUILayout.Height(30), GUILayout.ExpandWidth(false)))
                {
                    PrefabUtility.ApplyPrefabInstance(audioSources.gameObject, InteractionMode.AutomatedAction);
                }
                GUI.backgroundColor = Colors.whiteColor;
                EditorGUILayout.EndHorizontal();
        #endif
        EditorGUILayout.Separator();

        EditorGUILayout.Separator ();
		audioSources.bubbleSFX = EditorGUILayout.ObjectField ("Bubble SFX",audioSources.bubbleSFX, typeof(AudioClip),true) as AudioClip;
		EditorGUILayout.HelpBox ("Use the first AudioSource component below for the Music.", MessageType.Info);
		EditorGUILayout.HelpBox ("Use the second AudioSource component below for the Sound Effects.", MessageType.Info);
		EditorGUILayout.HelpBox ("* Click on Apply button that located on the top to save your changes", MessageType.Info);
		EditorGUILayout.Separator ();
	}
}

