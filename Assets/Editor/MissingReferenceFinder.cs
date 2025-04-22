using UnityEngine;
using UnityEditor;

public class MissingReferenceFinder
{
    [MenuItem("Tools/Cari Missing References")]
    public static void FindMissingReferences()
    {
        GameObject[] allObjects = Object.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allObjects)
        {
            Component[] components = go.GetComponents<Component>();
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] == null)
                {
                    Debug.LogWarning($"[Missing Script] GameObject '{go.name}' di scene '{go.scene.name}' memiliki script hilang!", go);
                }
            }

            // Optional: cek SerializedProperty (field) yang hilang juga
            SerializedObject so = new SerializedObject(go);
            SerializedProperty prop = so.GetIterator();
            while (prop.NextVisible(true))
            {
                if (prop.propertyType == SerializedPropertyType.ObjectReference && prop.objectReferenceValue == null && prop.objectReferenceInstanceIDValue != 0)
                {
                    Debug.LogWarning($"[Missing Reference] GameObject '{go.name}' memiliki referensi hilang di field '{prop.displayName}'", go);
                }
            }
        }

        Debug.Log("Selesai cek missing references.");
    }
}
