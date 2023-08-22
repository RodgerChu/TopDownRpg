using System;
using Cysharp.Threading.Tasks;
using Meta.Data;
using UnityEngine;
using Zenject;

namespace Meta.Loaders.Json
{
    public class JsonSkillsLoader: BaseJsonMetaLoader
    {
        public override UniTask<object> Load(Action<object, DiContainer> callback, DiContainer container)
        {
            var utcs = new UniTaskCompletionSource<object>();

            var handle = Resources.LoadAsync<TextAsset>(resourcesMetaPath + "/" + nameof(SkillMetaDataContainer));
            handle.completed += _ =>
            {
                var data = JsonUtility.FromJson<SkillMetaDataContainer>((handle.asset as TextAsset).text);
                callback(data, container);
                utcs.TrySetResult(data);
            };
            
            return utcs.Task;
        }
    }
}