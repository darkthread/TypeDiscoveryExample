using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PluginModule
{
    public class PluginManager
    {
        public Dictionary<string, IDocPlugin> Plugins = null;

        public PluginManager(AppDomain app)
        {
            //找出目前程序已載入的所有組件
            FindIDocPlugins(app.GetAssemblies());
        }

        public PluginManager(string binPath)
        {
            //找出bin目錄下*Plugin.dll
            FindIDocPlugins(System.IO.Directory.GetFiles(binPath, "*Plugin.dll")
                .Select(file => Assembly.LoadFrom(file)));
        }

        void FindIDocPlugins(IEnumerable<Assembly> assemblies)
        {
            Type pluginInterface = typeof(IDocPlugin);
            Plugins = assemblies
                    //列出所有組件裡的所有型別
                    .SelectMany(o => o.GetTypes())
                    //篩選出有實作IDocPlugin的所有類別
                    .Where(t => t.IsClass && pluginInterface.IsAssignableFrom(t))
                    .ToDictionary(
                        o => o.Name, //名稱為Key，對映IDocPlugin Instance
                                     //假設IDocPlugin為ThreadSafe，整個Process共用一個Instance即可
                        o => (IDocPlugin)Activator.CreateInstance(o)
                    );
        }


    }
}
