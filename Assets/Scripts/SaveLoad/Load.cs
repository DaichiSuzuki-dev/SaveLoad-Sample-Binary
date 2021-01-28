using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// 共通クラス
// ロードシステムを管理
partial class DataOperation
{
    /// <summary>保存したデータを読み込む</summary>
    /// <typeparam name="Type">ロードしたい情報</typeparam>
    /// <param name="path">ファイル名</param>
    public static Type Load<Type>(string path)

    // クラス型で制約
    where Type : class
    {
        // データをバイナリー形式で管理する
        var bf = new BinaryFormatter();

        // 指定したパス名でファイルを開く
        var data = File.Open(path, FileMode.Open);

        // データをデシリアライズ
        var saveInfo = (Type)bf.Deserialize(data);

        // ファイルを閉じる
        data.Close();

        // 取得したものを返す
        return saveInfo;
    }
}