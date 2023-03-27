using System;
using System.IO;
using System.Reflection;
using Meta.Loaders;
using Meta.Loaders.Json;
using ProtoBuf;
using Startup.GlobalBinders;
using UnityEditor;

public class JsonsToProtoSerializer
{
    [MenuItem("Tools/DB/Serialize to proto")]
    public static void SerializeJsons()
    {
        var savePath = "Assets/Resources/" + BaseProtoMetaLoader.resourcesMetaPath;
        var types = Assembly.GetAssembly(typeof(BaseProtoMetaLoader)).GetTypes();
        foreach (var type in types)
        {
            if (!type.IsAbstract && typeof(IJsonMetaLoader).IsAssignableFrom(type))
            {
                var loader = Activator.CreateInstance(type) as BaseMetaLoader;
                loader.Load(meta =>
                {
                    var metaName = meta.GetType().Name;
                    var filePath = savePath + "/" + metaName + ".txt";
                    using var memStream = new MemoryStream();
                    Serializer.Serialize(memStream, meta);
                    if (!Directory.Exists(savePath))
                    {
                        Directory.CreateDirectory(savePath);
                    }

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    File.WriteAllBytes(filePath, memStream.ToArray());
                });
            }
        }
    }
}
