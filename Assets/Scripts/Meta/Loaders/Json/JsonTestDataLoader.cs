using System;
using Meta.Data;
using UnityEngine;

namespace Meta.Loaders.Json
{
    public class JsonTestDataLoader : BaseJsonMetaLoader
    {
        public override void Load(Action<object> callback)
        {
            var json = Resources.Load<TextAsset>(resourcesMetaPath + "/TestMeta").text;
            callback(JsonUtility.FromJson<TestProtoMetaData>(json));
        }
    }
}
