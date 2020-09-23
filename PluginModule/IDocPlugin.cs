using System;

namespace PluginModule
{
    public interface IDocPlugin
    {
        /// <summary>
        /// 取得版本資訊
        /// </summary>
        string Version { get;  }
        /// <summary>
        /// 建立全文檢索用的索引
        /// </summary>
        /// <param name="content">文件檔內容</param>
        /// <returns>純文字索引</returns>
        string CreateFulltextIndex(byte[] content);
    }
}
