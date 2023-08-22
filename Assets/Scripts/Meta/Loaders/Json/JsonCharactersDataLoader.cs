using System;
using Cysharp.Threading.Tasks;
using Meta.Data;
using UnityEngine;
using Zenject;

namespace Meta.Loaders.Json
{
    public class JsonCharactersDataLoader: BaseJsonMetaLoader
    {
        public override UniTask<object> Load(Action<object, DiContainer> callback, DiContainer container)
        {
            var json = Resources.Load<TextAsset>(resourcesMetaPath + "/" + nameof(CharactersData)).text;
            var data = JsonUtility.FromJson<CharactersData>(json);
            callback(data, container);
            return new UniTask<object>(data);
        }
    }
}