using PluginModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebCore.Models
{
    public class DocPluginManager
    {
        Dictionary<string, IDocPlugin> plugins;

        public Dictionary<string, string> PluginInfos { get; private set; }

        public DocPluginManager(PluginManager manager)
        {
            plugins = manager.Plugins;
            PluginInfos = plugins.ToDictionary(o => o.Key, o => o.Value.Version);
        }

        public IDocPlugin GetPlugin(string docFormatName)
        {
            if (!plugins.ContainsKey(docFormatName)) 
                throw new ApplicationException("No plugin for format - " + docFormatName);
            return plugins[docFormatName];
        }


    }
}