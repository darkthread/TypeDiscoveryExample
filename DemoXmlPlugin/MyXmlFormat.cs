using PluginModule;
using System;

namespace DemoXmlPlugin
{
    public class MyXmlFormat : IDocPlugin
    {
        public string Version => "XML 檔擴充套件 Ver 2.1.5487";

        public string CreateFulltextIndex(byte[] content)
        {
            throw new NotImplementedException();
        }
    }
}
