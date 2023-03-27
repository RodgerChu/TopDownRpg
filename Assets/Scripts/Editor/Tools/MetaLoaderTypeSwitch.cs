using UnityEditor;
using UnityEngine;

namespace Editor.Tools
{
    public class MetaLoaderTypeSwitch : MonoBehaviour
    {
        [MenuItem("Tools/DB/Use proto", false, 0)]
        public static void SwitchToProto()
        {
            EditorPrefs.SetBool("use_proto", true);
        }

        [MenuItem("Tools/DB/Use proto", true, 0)]
        public static bool SwitchToProtoChecker()
        {
            return !EditorPrefs.GetBool("use_proto");
        }
        
        [MenuItem("Tools/DB/Use json", false, 0)]
        public static void SwitchToJson()
        {
            EditorPrefs.SetBool("use_proto", false);
        }

        [MenuItem("Tools/DB/Use json", true, 0)]
        public static bool SwitchToJsonChecker()
        {
            return EditorPrefs.GetBool("use_proto");
        }
    }
}
