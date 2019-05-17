using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Parser
{
    /// <summary>
    /// パーサインターフェース
    /// </summary>
    public interface IParser
    {

        /// <summary>
        /// 文字列リストから辞書リストに変換
        /// </summary>
        /// <param name="text">文字列リスト</param>
        /// <param name="sep">区切り文字</param>
        /// <returns>辞書リスト</returns>
        List<Dictionary<String, Object>> Str2Dict(List<String> text, Char sep = ',');

        /// <summary>
        /// 辞書リストから文字列リストに変換
        /// </summary>
        /// <param name="dict">辞書リスト</param>
        /// <param name="sep">区切り文字</param>
        /// <returns>文字列リスト</returns>
        List<String> Dict2Str(List<Dictionary<String, Object>> dict, Char sep = ',');

    }

    /// <summary>
    /// パーサインターフェース用拡張関数定義クラス
    /// 本来はインターフェースに含めることが出来ない実装を拡張関数を用いて行います。
    /// </summary>
    public static class IParserExtension
    {
        /// <summary>
        /// ファイル出力
        /// </summary>
        /// <param name="self">IParser</param>
        /// <param name="path">ファイル格納PATH</param>
        /// <param name="str_list">文字列リスト</param>
        /// <returns>成否</returns>
        public static Boolean ToFile(this IParser self, String path, List<String> str_list)
        {
            using (var sw = new StreamWriter(path, append: false, encoding: Encoding.UTF8))
            {
                foreach (String line in str_list)
                {
                    sw.WriteLine(line);
                }
            }
            return true;
        }

        /// <summary>
        /// ファイル入力
        /// </summary>
        /// <param name="self">IParser</param>
        /// <param name="path">ファイル格納PATH</param>
        /// <returns>読取文字列リスト</returns>
        public static List<String> FromFile(this IParser self, String path)
        {
            var result = new List<String>();
            if (!File.Exists(path)) { return result; }
            using (var sr = new StreamReader(path, encoding: Encoding.UTF8))
            {
                while (sr.Peek() >= 0)
                {
                    result.Add(sr.ReadLine());
                }
            }
            return result;
        }


    }
}
