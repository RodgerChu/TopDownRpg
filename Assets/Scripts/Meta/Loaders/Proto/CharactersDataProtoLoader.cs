using System;
using System.IO;
using Cysharp.Threading.Tasks;
using Meta.Data;
using Meta.Loaders.Json;
using ProtoBuf;
using Unity.Loading;
using UnityEngine;
using Zenject;

namespace Meta.Loaders.Proto
{
    public class CharactersDataProtoLoader: BaseProtoMetaLoader
    {
        public override UniTask<object> Load(Action<object, DiContainer> callback, DiContainer container)
        {
            var utc = new UniTaskCompletionSource<object>();
            
            var handle = Resources.LoadAsync<TextAsset>(resourcesMetaPath + "/" + nameof(CharactersData));
            handle.completed += _ =>
            {
                using var memStream = new MemoryStream((handle.asset as TextAsset).bytes);
                var charactersMetaData = Serializer.Deserialize<CharactersData>(memStream);
                var charactersContainer = new CharactersGameplayDataContainer();
                charactersContainer.characters = charactersMetaData.characters;
                callback(charactersContainer, container);
                utc.TrySetResult(charactersContainer);
            };
            
            return utc.Task;
        }
    }
}