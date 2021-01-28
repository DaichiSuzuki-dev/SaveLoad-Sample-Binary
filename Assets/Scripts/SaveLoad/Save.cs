using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// 共通クラス
// セーブシステムを管理
partial class DataOperation
{
    /// <summary>情報をセーブする</summary>
    /// <param name="path">ファイル名</param>
    /// <param name="info">セーブしたい情報</param>
    public static void Save(object info, string path)
    {
        // データをバイナリー形式で管理する
        var bf = new BinaryFormatter();

        // 指定したパスでファイルを新規（上書き）作成
        var data = File.Create(path);

        // データをシリアライズ
        bf.Serialize(data, info);

        // ファイルを閉じる
        data.Close();
    }
}