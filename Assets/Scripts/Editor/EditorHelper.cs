using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using System.Reflection;
using UnityEditor.Events;
using UnityEngine.Events;
using System.Linq;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;

public class EditorHelper : EditorWindow
{
    [MenuItem("Jay/EditorHelper")]
    public static void ShowTime()
    {
        EditorWindow.GetWindow<EditorHelper>();
    }
    private UnityEditor.Animations.AnimatorController animationController;
    private string NameToInsertGameObjectTo;
    private GameObject ObjectToInsert;

    [MenuItem("Hotkey/RunTitle #1", false, 100)]
    public static void RunTitle()
    {
        UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/Scene/title.unity", UnityEditor.SceneManagement.OpenSceneMode.Single);
        EditorApplication.isPlaying = true;
    }

    [MenuItem("Hotkey/RunMain #2", false, 100)]
    public static void GoMain()
    {
        UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/Scene/main.unity", UnityEditor.SceneManagement.OpenSceneMode.Single);
        UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/Scene/essential.unity", UnityEditor.SceneManagement.OpenSceneMode.Additive);
    }

    [MenuItem("Hotkey/RunExploration #3", false, 100)]
    public static void GoExploration()
    {
        UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/Scene/exploration.unity", UnityEditor.SceneManagement.OpenSceneMode.Single);
        UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/Scene/essential.unity", UnityEditor.SceneManagement.OpenSceneMode.Additive);
    }

    [MenuItem("Hotkey/RunEssential #4", false, 100)]
    public static void GoEssential()
    {
        UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/Scene/ready.unity", UnityEditor.SceneManagement.OpenSceneMode.Single);
        UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/Scene/essential.unity", UnityEditor.SceneManagement.OpenSceneMode.Additive);
    }


    private GameObject From, To;

    private void OnGUI()
    {

        animationController = EditorGUILayout.ObjectField(animationController, typeof(UnityEditor.Animations.AnimatorController), false) as UnityEditor.Animations.AnimatorController;


        From = EditorGUILayout.ObjectField(From, typeof(GameObject), true) as GameObject;
        To = EditorGUILayout.ObjectField(To, typeof(GameObject), true) as GameObject;


        if (GUILayout.Button("Under"))
        {
            foreach(GameObject go in Selection.gameObjects)
            {
                GameObject newChild = PrefabUtility.InstantiatePrefab(From) as GameObject;
                Transform trans = newChild.transform;
                trans.parent = go.transform;
                trans.localPosition = new Vector3(0, 0.16f, 0.12f);
            }
        }

        #region archive

        if (GUILayout.Button("Copy Radial"))
        {
            Transform parent = Selection.activeGameObject.transform;
            for (int i = 140; i >= -140; i -= 10)
            {
                GameObject copy = (GameObject)PrefabUtility.InstantiatePrefab(ObjectToInsert, parent);
                copy.transform.rotation = Quaternion.Euler(0, 0, i);
            }
        }


        if (GUILayout.Button("Multiapply on Root"))
        {
            foreach (GameObject go in Selection.gameObjects)
            {
                PrefabUtility.ReplacePrefab(go, PrefabUtility.GetCorrespondingObjectFromSource(go), ReplacePrefabOptions.ConnectToPrefab);
            }
        }
        if (GUILayout.Button("CpCollider on Root"))
        {
            foreach (GameObject go in Selection.gameObjects)
            {
                foreach (BoxCollider bc in go.GetComponents<BoxCollider>())
                {
                    BoxCollider cp = go.AddComponent<BoxCollider>();
                    cp.size = bc.size;
                    cp.center = bc.center;
                    cp.isTrigger = true;
                }
            }
        }

        if (GUILayout.Button("Nuke Playerprefs"))
        {
            PlayerPrefs.DeleteAll();
        }

        if (GUILayout.Button("Room to visual"))
        {
            foreach (GameObject room in Selection.gameObjects)
            {
                GameObject visual = GameObject.Find(room.name + " (1)");
                visual.transform.position = room.transform.position;
                visual.transform.rotation = room.transform.rotation;

                List<GameObject> childList = new List<GameObject>();
                foreach (Transform child in visual.transform)
                {
                    childList.Add(child.gameObject);
                }

                foreach (GameObject child in childList)
                {
                    DestroyImmediate(child.gameObject);
                }
                childList.Clear();


                foreach (Transform child in room.transform)
                {
                    childList.Add(child.gameObject);
                }
                foreach (GameObject child in childList)
                {
                    child.transform.SetParent(visual.transform);
                    foreach (MonoBehaviour script in child.GetComponentsInChildren<MonoBehaviour>())
                    {
                        DestroyImmediate(script);
                    }
                    foreach (Collider script in child.GetComponentsInChildren<Collider>())
                    {
                        DestroyImmediate(script);
                    }
                }
            }
        }


        if (GUILayout.Button("Nuke Scripts"))
        {
            foreach (GameObject go in Selection.gameObjects)
            {
                foreach (MonoBehaviour script in go.GetComponentsInChildren<MonoBehaviour>())
                {
                    DestroyImmediate(script);
                }
                foreach (Collider script in go.GetComponentsInChildren<Collider>())
                {
                    DestroyImmediate(script);
                }
            }
        }


        NameToInsertGameObjectTo = EditorGUILayout.TextField("Name of GameObjects", NameToInsertGameObjectTo);
        ObjectToInsert = EditorGUILayout.ObjectField(ObjectToInsert, typeof(GameObject), true) as GameObject;
        if (GUILayout.Button("Insert Gameobject as children foreach gameobject with given name"))
        {
            foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>())
            {
                if (go.name == NameToInsertGameObjectTo)
                {
                    GameObject obj = Instantiate(ObjectToInsert);
                    obj.name = ObjectToInsert.name;
                    obj.transform.SetParent(go.transform);
                    obj.transform.localPosition = Vector3.zero;
                    obj.transform.localRotation = Quaternion.identity;
                }
            }
        }

        if (GUILayout.Button("Insert Gameobject as children foreach selected gameobject"))
        {
            foreach (GameObject go in Selection.gameObjects)
            {
                GameObject obj = Instantiate(ObjectToInsert);
                obj.name = ObjectToInsert.name;
                obj.transform.SetParent(go.transform);
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
            }
        }

        if (GUILayout.Button("Replace Gameobject as children foreach gameobject with given name"))
        {
            foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>())
            {
                if (go.name == NameToInsertGameObjectTo)
                {
                    GameObject obj = Instantiate(ObjectToInsert);
                    obj.name = ObjectToInsert.name;
                    Transform child = go.transform.Find(obj.name);
                    while (child != null)
                    {
                        DestroyImmediate(child.gameObject);
                        child = go.transform.Find(obj.name);
                    }

                    obj.transform.SetParent(go.transform);
                    obj.transform.localPosition = Vector3.zero;
                    obj.transform.localRotation = Quaternion.identity;
                }
            }
        }

        if (GUILayout.Button("AnimatorStateEnterExit"))
        {
            foreach (var script in animationController.GetBehaviours<StateMachineBehaviour>())
            {
                DestroyImmediate(script, true);
            }
            foreach (var layer in animationController.layers)
            {
                foreach (var state in layer.stateMachine.states)
                {
                    string stateName = state.state.name;
                    AnimationStateTranslator.StateMessage message = new AnimationStateTranslator.StateMessage();
                    message.onEnter = "EnterState";
                    message.onExit = "ExitState";
                    message.stateFullName = stateName;

                    AnimationStateTranslator translator = animationController.AddEffectiveStateMachineBehaviour<AnimationStateTranslator>(state.state, 0);
                    translator.OutgoingMessages = new AnimationStateTranslator.StateMessage[1]  {
                        message
                    };
                }
            }
        }

        #endregion

    }

    private Microsoft.MixedReality.Toolkit.UI.ObjectManipulator SetupHololensInteraction(GameObject target, bool lockScale = true)
    {
        var om = target.AddComponent<Microsoft.MixedReality.Toolkit.UI.ObjectManipulator>();
        target.AddComponent<NearInteractionGrabbable>();
        target.AddComponent<RotationAxisConstraint>();
        target.AddComponent<MoveAxisConstraint>();
        var s = target.AddComponent<MinMaxScaleConstraint>();
        if (lockScale)
        {
            s.ScaleMinimum = 1;
            s.ScaleMaximum = 1;
        }
        return om;
    }

    public static BindingFlags All
    {
        get
        {
            return BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance;
        }
    }


    public static void CopyUnityEvents(object sourceObj, string source_UnityEvent, object dest, bool debug = false)
    {
        foreach (var f in sourceObj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.SetProperty | BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            // Debug.Log(f);
        }
        FieldInfo unityEvent = sourceObj.GetType().GetField(source_UnityEvent, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.SetProperty | BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        if (unityEvent.FieldType != dest.GetType())
        {
            if (debug == true)
            {
                Debug.Log("Source Type: " + unityEvent.FieldType);
                Debug.Log("Dest Type: " + dest.GetType());
                Debug.Log("CopyUnityEvents - Source & Dest types don't match, exiting.");
            }
            return;
        }
        else
        {
            SerializedObject so = new SerializedObject((Object)sourceObj);
            SerializedProperty persistentCalls = so.FindProperty(source_UnityEvent).FindPropertyRelative("m_PersistentCalls.m_Calls");
            for (int i = 0; i < persistentCalls.arraySize; ++i)
            {
                Object target = persistentCalls.GetArrayElementAtIndex(i).FindPropertyRelative("m_Target").objectReferenceValue;
                string methodName = persistentCalls.GetArrayElementAtIndex(i).FindPropertyRelative("m_MethodName").stringValue;
                MethodInfo method = null;
                try
                {
                    method = target.GetType().GetMethod(methodName, All);
                }
                catch
                {
                    foreach (MethodInfo info in target.GetType().GetMethods(All).Where(x => x.Name == methodName))
                    {
                        ParameterInfo[] _params = info.GetParameters();
                        if (_params.Length < 2)
                        {
                            method = info;
                        }
                    }
                }
                ParameterInfo[] parameters = method.GetParameters();
                if (parameters.Length > 0)
                {
                    switch (parameters[0].ParameterType.Name)
                    {
                        case nameof(System.Boolean):
                            bool bool_value = persistentCalls.GetArrayElementAtIndex(i).FindPropertyRelative("m_Arguments.m_BoolArgument").boolValue;
                            var bool_execute = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), target, methodName) as UnityAction<bool>;
                            UnityEventTools.AddBoolPersistentListener(
                                dest as UnityEventBase,
                                bool_execute,
                                bool_value
                            );
                            break;
                        case nameof(System.Int32):
                            int int_value = persistentCalls.GetArrayElementAtIndex(i).FindPropertyRelative("m_Arguments.m_IntArgument").intValue;
                            var int_execute = System.Delegate.CreateDelegate(typeof(UnityAction<int>), target, methodName) as UnityAction<int>;
                            UnityEventTools.AddIntPersistentListener(
                                dest as UnityEventBase,
                                int_execute,
                                int_value
                            );
                            break;
                        case nameof(System.Single):
                            float float_value = persistentCalls.GetArrayElementAtIndex(i).FindPropertyRelative("m_Arguments.m_FloatArgument").floatValue;
                            var float_execute = System.Delegate.CreateDelegate(typeof(UnityAction<float>), target, methodName) as UnityAction<float>;
                            UnityEventTools.AddFloatPersistentListener(
                                dest as UnityEventBase,
                                float_execute,
                                float_value
                            );
                            break;
                        case nameof(System.String):
                            string str_value = persistentCalls.GetArrayElementAtIndex(i).FindPropertyRelative("m_Arguments.m_StringArgument").stringValue;
                            var str_execute = System.Delegate.CreateDelegate(typeof(UnityAction<string>), target, methodName) as UnityAction<string>;
                            UnityEventTools.AddStringPersistentListener(
                                dest as UnityEventBase,
                                str_execute,
                                str_value
                            );
                            break;
                        case nameof(System.Object):
                            Object obj_value = persistentCalls.GetArrayElementAtIndex(i).FindPropertyRelative("m_Arguments.m_ObjectArgument").objectReferenceValue;
                            var obj_execute = System.Delegate.CreateDelegate(typeof(UnityAction<Object>), target, methodName) as UnityAction<Object>;
                            UnityEventTools.AddObjectPersistentListener(
                                dest as UnityEventBase,
                                obj_execute,
                                obj_value
                            );
                            break;
                        default:
                            var void_execute = System.Delegate.CreateDelegate(typeof(UnityAction), target, methodName) as UnityAction;
                            UnityEventTools.AddPersistentListener(
                                dest as UnityEvent,
                                void_execute
                            );
                            break;
                    }
                }
                else
                {
                    var void_execute = System.Delegate.CreateDelegate(typeof(UnityAction), target, methodName) as UnityAction;
                    UnityEventTools.AddPersistentListener(
                        dest as UnityEvent,
                        void_execute
                    );
                }
            }
        }
    }
}
