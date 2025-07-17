using UnityEngine;
using UnityEditor;

public class AddAudioPoint : MonoBehaviour
{
    [MenuItem("Tools/Add AudioPoint to Selected")]
    static void AddAudioChildToSelected()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj.transform.Find("AudioPoint") == null)
            {
                GameObject audioPoint = new GameObject("AudioPoint");
                audioPoint.transform.SetParent(obj.transform);
                audioPoint.transform.localPosition = Vector3.zero;

                var source = audioPoint.AddComponent<AudioSource>();
                source.spatialBlend = 1f;
                source.playOnAwake = false;
                source.loop = false;
            }
        }
    }
}
