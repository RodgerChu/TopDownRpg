using UnityEditor;
using Zenject;

namespace Startup.GlobalBinders
{
    public class MetaBinder : MonoInstaller
    {
        private ProtoMetaBinder m_protoBinder = new();
        private JsonMetaBinder m_jsonMetaBinder = new();

        public override void InstallBindings()
        {
#if UNITY_EDITOR
            if (EditorPrefs.GetBool("use_proto"))
            {
                m_protoBinder.InstallBindings(Container);
            }
            else
            {
                m_jsonMetaBinder.InstallBindings(Container);
            }
#else
            m_protoBinder.InstallBindings(Container);
#endif
        }
    }
}
