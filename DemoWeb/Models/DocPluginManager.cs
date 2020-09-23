using PluginModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWeb.Models
{
    public static class DocPluginManager
    {
        static Dictionary<string, IDocPlugin> plugins = 
            new PluginManager(AppDomain.CurrentDomain).Plugins;

        public static Dictionary<string, string> PluginInfos =
            plugins.ToDictionary(o => o.Key, o => o.Value.Version);
        
        public static IDocPlugin GetPlugin(string docFormatName)
        {
            if (!plugins.ContainsKey(docFormatName)) 
                throw new ApplicationException("No plugin for format - " + docFormatName);
            return plugins[docFormatName];
        }


    }
}