# Functionsの更新
## アプリケーション設定にDB接続文字列を追加
SQL Databaseのリソースへ移動し、設定→接続文字列からADO.NETの接続文字列をコピーします。  
Functionsのリソースへ移動し、アプリケーション設定にDBの接続文字列を `SQLDB_CONNECTION` として追加します。

## ソースコードの変更
`Functions.csproj` を開き、 `System.Data.SqlClient` パッケージを追加します。

```xml
<PackageReference Include="System.Data.SqlClient" Version="4.8.2" />
```

`Webhook.cs` を開き、処理を追加します。  
usingに `System.Data.SqlClient` と `ApplicationCore.Entities` を追加します。

```csharp
using System.Data.SqlClient;
using ApplicationCore.Entities;
```

DB接続文字列をフィールドに追加し、コンストラクタ内で初期化します。

```csharp
private readonly IHttpClientFactory httpClientFactory;
private readonly string accessToken;
private readonly string sqldbConnection; // 追加

public Webhook(
    IHttpClientFactory httpClientFactory,
    IConfiguration configuration)
{
    this.httpClientFactory = httpClientFactory;
    accessToken = configuration.GetValue<string>("LINE_CHANNEL_ACCESS_TOKEN");
    sqldbConnection = configuration.GetValue<string>("SQLDB_CONNECTION"); // 追加
}
```

GetMessage関数をWebhookクラス内に追加します。

```csharp
/// <summary>
/// DBからメッセージデータを取得
/// </summary>
/// <returns>取得したメッセージデータ</returns>
private Message GetMessage()
{
    var message = default(Message);
    using (var connection = new SqlConnection(sqldbConnection))
    {
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            // 1件のみ取得
            command.CommandText = "SELECT TOP 1 * FROM Messages;";
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    message = new Message
                    {
                        Id = reader["Id"] as Guid? ?? Guid.Empty,
                        Text = reader["Text"] as string,
                    };
                }
            }
        }
    }

    if (message == null || message.Id == Guid.Empty)
    {
        return null;
    }

    return message;
}
```

GetMessage関数を使用して返信内容を取得するよう、Run関数内を変更します。

```csharp
// ----- コメントアウト -----
// オウム返しする
//await Reply(firstEvent.ReplyToken, firstEvent.Message.Text);
// ----------

// DBからメッセージデータを取得
var message = GetMessage();

// DBからメッセージデータが取得できれば取得したテキストを返信、なければオウム返し
var text = message?.Text ?? firstEvent.Message.Text;
await Reply(firstEvent.ReplyToken, text);
```

## 再度デプロイ・動作確認
手順「Functionsの作成 > デプロイ」で行ったものと同様の手順で再度デプロイします。
