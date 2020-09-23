using PluginModule;
using System;

namespace DemoJsonPlugin
{
    public class MyJsonFormat : IDocPlugin
    {
        public string Version => "JSON 檔擴充套件 Ver 1.0.9527";

        public string CreateFulltextIndex(byte[] content)
        {
            throw new NotImplementedException();
        }
    }
}
