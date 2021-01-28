using System.IO;
using UnityEngine;
using UnityEngine.UI;

// 共通クラス
partial class GameController : MonoBehaviour
{
    // 画面に表示するテキスト
    [SerializeField] Text quanitity = null;

    // Clickされた回数
    public int clickAmount = 0;

    // ファイルを保存する場所
    private string fileName;

    void Awake()
    {
        // Application.dataPathは現在のファイルがある場所を示す
        // スラッシュで区切ることで、現在のファイルから指定した名前（今回はData.save）でファイルを新規作成できる
        fileName = Application.dataPath + "/Data.save";
    }

    // ゲーム開始時
    void Start()
    {
        // 前回データを読み込む
        LoadGameData();
    }

    void Update()
    {
        // テキストに現在の状態を代入
        quanitity.text = clickAmount.ToString();
    }

    // 「 + 」をクリック
    public void Pushed_PLUS()
    {
        // 数値を１増やす
        clickAmount++;
    }

    // 「 - 」をクリック
    public void Pushed_MINUS()
    {
        // 数値を１減らす
        clickAmount--;
    }

    // 「 SAVE 」をクリック
    public void Pushed_SAVE()
    {
        // 現在の状態をセーブ
        SaveGameData();
        // メッセージを表示
        Debug.Log("セーブに成功！！");
    }

    // 「 LOAD 」をクリック
    public void Pushed_LOAD()
    {
        // データを読み込む
        LoadGameData();
        // メッセージを表示
        Debug.Log("ロードに成功！！");
    }

    // 「 DELETE 」をクリック
    public void Pushed_DELETE()
    {
        // ファイルを削除
        DataOperation.Delete(fileName);
        // メッセージを表示
        Debug.Log("データの削除に成功！！再起動で確認してみてね");
    }

    // 現在の状態をセーブ
    private void SaveGameData()
    {
        // 中身を扱えるよう、変数を作成
        var saveInfo = new SaveInformation()
        {
            // 保存用の変数に、現在の数値を代入
            clickArchives = clickAmount
        };

        // SaveInformationの中身をセーブ
        DataOperation.Save(saveInfo, fileName);
    }


    // 保存されたデータを読み込む
    private void LoadGameData()
    {
        // ファイルが開けた場合
        if (File.Exists(fileName))
        {
            // < >内にクラスを、引数にパス名を入れると、セーブされたデータが呼ばれる
            var saveInfo = DataOperation.Load<SaveInformation>(fileName);

            // 保存されたデータを代入
            clickAmount = saveInfo.clickArchives;
        }
        // 開けなかった場合
        else
        {
            // コンソール画面にメッセージを表示する
            Debug.Log("前回のデータはありません");
        }
    }
}
