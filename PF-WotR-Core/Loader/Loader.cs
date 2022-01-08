using System;
using System.IO;
using Newtonsoft.Json.Linq;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Loader
{
    public abstract class Loader
    {
        protected readonly String _filename;
        protected readonly String _jsonString;
        protected readonly JObject _jObject;

        public Loader(String filename)
        {
            Mod.Debug($"Loading file {filename}");
            _filename = filename;
            _jsonString = File.ReadAllText(_filename);
            _jObject = JObject.Parse(_jsonString);
        }

        public abstract bool load();
    }
}
