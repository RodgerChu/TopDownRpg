using System;
using Cysharp.Threading.Tasks;
using Meta.Data;
using Unity.Loading;
using UnityEngine;
using Zenject;

namespace Meta.Loaders.Json
{
    public class JsonTestDataLoader : BaseJsonMetaLoader
    {
        public override UniTask<object> Load(Action<object, DiContainer> callback, DiContainer container)
        {
            var json = Resources.Load<TextAsset>(resourcesMetaPath + "/TestMeta").text;
            var testData = JsonUtility.FromJson<TestProtoMetaData>(json);
            callback(testData, container);
            return new UniTask<object>(testData);
        }
    }
}
