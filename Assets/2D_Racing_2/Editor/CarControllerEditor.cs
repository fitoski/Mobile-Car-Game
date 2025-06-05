using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ALIyerEdon
{
	[CustomEditor(typeof(CarController))]
	[CanEditMultipleObjects]
	public class CarControllerEditor : Editor
	{

		int rand1, rand2;
		int id;

		CarController script;

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			script = (CarController)target;

			EditorGUILayout.Space();

			GUI.color = Color.green;
			EditorGUILayout.Space();

			EditorGUILayout.HelpBox("Car Controller", MessageType.None);

			EditorGUILayout.Space();
			GUI.color = Color.white;

			//---------------------------------------------------------------------------
			EditorGUILayout.HelpBox("Main", MessageType.None);

			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(serializedObject.FindProperty("isMobile"),
				new GUIContent("Is Mobile", "Is Mobile"), true);
			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("centerOfMass"),
				new GUIContent("Center Of Mass", "Center Of Mass"), true);
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(serializedObject.FindProperty("motorWheels"),
				new GUIContent("Motor Wheel2D", "Motor Wheel2D"), true);
			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("motorPower"),
				new GUIContent("Motor Power", "Motor Power"), true);
			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("brakePower"),
				new GUIContent("Brake Power", "Brake Power"), true);
			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("decelerationSpeed"),
				new GUIContent("Friction Power", "Friction Power"), true);
			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("maxSpeed"),
				new GUIContent("Max Speed", "Max Speed"), true);
			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("RotateForce"),
				new GUIContent("Rotate Force", "Rotate Force "), true);
			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("wheelParticle"),
				new GUIContent("Wheel Particle", "Wheel Particle "), true);
			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("particlePosition"),
				new GUIContent("Particle Position", "Wheel Particle Position "), true);
			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("useSmoke"),
				new GUIContent("Use Smoke", "Use Exhaust Smoke Particle "), true);

			if (script.useSmoke)
			{
				EditorGUILayout.PropertyField(serializedObject.FindProperty("smoke"),
					new GUIContent("Exhaust Smoke", "Exhaust Smoke Particle "), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("smokeTargetSpeed"),
					new GUIContent("Stop On Speed", "Exhaust Smoke Particle is Stopped when reach this speed "), true);
				EditorGUILayout.Space();
			}

			EditorGUILayout.PropertyField(serializedObject.FindProperty("groundDistance"),
				new GUIContent("Ground Distance", "Find car is grounded"), true);
			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("cameraDistance"),
				new GUIContent("Camera Distance", "Set camera distance from vehicle "), true);
			EditorGUILayout.Space();

			serializedObject.ApplyModifiedProperties();



		}
	}
}