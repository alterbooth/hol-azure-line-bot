# Functionsの作成
## Functionsリソース作成
はじめに、リソースグループを作成します。  
[Azureポータル](https://portal.azure.com) を開き、上部の検索バーから「リソース」と入力し「リソース グループ」を選択します。  
![リソースグループ作成1](images/create_resourcegroup_1.png)  
  
「作成」ボタンから、リソースグループ作成画面を開き、情報を入力します。  
![リソースグループ作成2](images/create_resourcegroup_2.png)  
  
「確認および作成」タブより、「作成」ボタンを押下します。  
![リソースグループ作成3](images/create_resourcegroup_3.png)  
  
次に、Azure Functionsのリソースを作成します。  
作成したリソースグループを開き、「作成」ボタンを選択します。  
![Azure Functions作成1](images/create_functions_1.png)  
  
リソースの作成画面が開けたら、「関数アプリ」を選択します。  
![Azure Functions作成2](images/create_functions_2.png)  
  
下記スクリーンショットに倣って情報を入力します。  
入力後「確認および作成」を選択、確認および作成の画面で「作成」と移ってください。  
![Azure Functions作成3](images/create_functions_3.png)  
  
以下のように「デプロイが完了しました」と表示されれば、Azure Functionsリソース作成完了です。  
![Azure Functions作成4](images/create_functions_4.png)  

## LINEチャネル作成
- 【無ければ】プロパイダー作成  
![プロパイダー作成](images/create_provider.png)  
![プロパイダー作成2](images/create_provider2.png)
- プロパイダーのメニュー画面へ移動し
- 新規チャネル作成 → LINEログイン  
![LINEログイン](images/line_login.png)
  - チャネル名とチャネル説明を入力
  - アプリタイプを「Webアプリ」に設定
  - LINE開発者契約に同意して作成
- 新規チャネル作成 → Messaging API  
![MessagingAPI](images/messaging_api.png)
  - チャネル名とチャネル説明を入力
  - 大業種：ウェブサービスを選択
  - 小業種：ウェブサービス（その他）を選択
  - LINE公式アカウント利用規約とLINE公式アカウントAPI利用規約に同意して作成
- Messaging APIの設定
  - 上部タブの「Messaging API設定」へ移動  
  ![MessagingAPI設定](images/messaging_api_settings.png)  
  - 以下の項目を編集する
    - webhook
      - Functionsの設定からURL取得
      - "取得したURL"/api/webhookを設定
    - 応答メッセージを無効
    - あいさつメッセージを無効

## 環境変数にチャネルアクセストークン設定
- 先程作成したMessaging APIへ移動
- Messaging API設定へ移動
- 最下部にある「チャネルアクセストークン」をコピー
  - まだ発行してない場合は「発行」ボタンを押下してコピー
- 先に作成しておいたFunctionsのリソースへ移動
- リソース画面の左サイドメニューにある設定→構成へ移動
- アプリケーション設定に「新しいアプリケーション設定」を追加
  - 名前：LINE_CHANNEL_ACCESS_TOKEN
  - 値：コピーしたチャネルアクセストークン
  - デプロイスロットの設定にチェック
- 新しく追加されたことを確認したら保存
  - ※保存完了までしばらくかかるので待機

## デプロイ
- GitHubからソースコードを取得
  - [GitHub - alterbooth/hol-azure-line-bot](https://github.com/alterbooth/hol-azure-line-bot)
- [Visual Studio Code を使用して C# 関数を作成する - Azure Functions \| Microsoft Docs](https://docs.microsoft.com/ja-jp/azure/azure-functions/create-first-function-vs-code-csharp)
- 上記を参考に作成したリソースに対してデプロイを行う

## 動作確認
- 作成したLINEアカウントに対してなにか発言して同じ内容が返ってくればOK
