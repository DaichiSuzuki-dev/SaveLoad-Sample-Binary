using System.IO;

// 共通クラス
// デリートシステムを管理
partial class DataOperation
{
    /// <summary>
    /// 引数にセットしたファイルを削除する
    /// </summary>
    public static void Delete(string path)
    {
        // ファイルの削除
        File.Delete(path);
    }
}