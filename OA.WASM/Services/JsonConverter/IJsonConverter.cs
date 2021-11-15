using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Services.JsonConverter
{
    public interface IJsonConverter
    {
        string SerializeObject(object o);
        T DeserializeObject<T>(string json);
    }
}
