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

## デプロイ
作成したAzure Functionsリソースにサンプルコードをデプロイします。  
Visual Studio Codeを開き、Azure Tools拡張機能を追加します。  
![MessagingAPI](images/deploy_functions_1.png)  
  
「Functionsリソース作成」手順にて作成したAzure Functionsを右クリック選択し、「Deploy to Function App」を選択します。  
![MessagingAPI](images/deploy_functions_2.png)  
  
「Select the folder to deploy」入力欄が表示されたら、Browseから **Functions** フォルダを選択します。  
「Initialize project for use with VS Code?」と出たらYesを選択してください。  
「Deployment to "リソース名" completed.」と通知が出たらデプロイ成功です。  
![MessagingAPI](images/deploy_functions_3.png)  

## LINEチャネル作成
[LINE Developers Console](https://developers.line.biz/console/) を開きます。  
プロバイダーを登録していない場合は、任意の名前で登録します。  
![プロパイダー作成2](images/create_provider2.png)  
  
LINE Messaging APIのチャネルを作成します。  
↓のアイコンを選択します。  
![MessagingAPI](images/messaging_api_1.png)  
  
必須項目に任意の値を入力し、利用規約の同意にチェックした後「作成」を選択します。  
![MessagingAPI](images/messaging_api_2.png)  
  
次に、Messaging APIに関する各種設定を行います。  
「Messaging API設定」タブを開きます。  
![MessagingAPI設定](images/messaging_api_settings.png)  
  
応答メッセージをオフにします。（オンの状態だと、毎回定型文が返答されてしまうため）  
![MessagingAPI](images/messaging_api_3.png)  
![MessagingAPI](images/messaging_api_4.png)  
  
チャネルアクセストークンを発行し、コピーします。  
![MessagingAPI](images/messaging_api_5.png)  
  
発行したチャネルアクセストークンを下記手順でAzure Functionsに設定します。
- 先に作成しておいたFunctionsのリソースへ移動
- リソース画面の左サイドメニューにある設定→構成へ移動
- アプリケーション設定に「新しいアプリケーション設定」を追加
  - 名前： `LINE_CHANNEL_ACCESS_TOKEN`
  - 値：先程コピーしたチャネルアクセストークン
- 「保存」ボタンを押下
  
![MessagingAPI](images/messaging_api_6.png)  
  
Webhookの設定を更新します。  
AzureポータルよりFunctionsのURLを取得します。  
![MessagingAPI](images/messaging_api_7.png)  
  
![MessagingAPI](images/messaging_api_8.png)  
  
Messaging API設定画面のWebhook URLに入力し、更新後、「Webhookの利用」をオンにします。  
![MessagingAPI](images/messaging_api_9.png)  
  
Messaging API設定画面中で確認できるQRコードを読み込み、LINE友達登録します。

## 動作確認
LINEを開き、送信したメッセージと同じメッセージが返信されることを確認します。  
![MessagingAPI](images/line_1.png)  
  
確認できたら、次のステップ「[Webアプリの作成](./web-create.md)」へ進みます。
