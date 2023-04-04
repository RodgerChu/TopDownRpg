using System;
using Meta.Data;
using UnityEngine;
using Zenject;

namespace Meta.Loaders.Json
{
    public class JsonTestDataLoader : BaseJsonMetaLoader
    {
        public override void Load(Action<object> callback, DiContainer container)
        {
            var json = Resources.Load<TextAsset>(resourcesMetaPath + "/TestMeta").text;
            callback(JsonUtility.FromJson<TestProtoMetaData>(json));
        }
    }
}
