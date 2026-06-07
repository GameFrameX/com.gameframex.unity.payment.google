<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Payment Google

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.payment.google)](https://github.com/GameFrameX/com.gameframex.unity.payment.google/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.payment.google)](https://github.com/GameFrameX/com.gameframex.unity.payment.google/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

<br />

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · QQグループ: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

</div>

## 言語

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

---

## プロジェクト概要

このプラグインは、Unity アプリケーションに Google Play のアプリ内課金機能を統合するためのシンプルで使いやすい API を提供します。Google Play Billing Library の複雑さをカプセル化し、統一されたインターフェースを提供することで、開発者が以下の機能を簡単に実装できるようにします：

- Google Play Billing の初期化
- 商品詳細の照会
- 商品の購入（一回限り商品とサブスクリプション）
- 購入の消費（消費型商品）
- 購入履歴の照会

## クイックスタート

### インストール

Unity プロジェクトの `Packages/manifest.json` を編集し、`scopedRegistries` セクションを追加してください：

```json
{
  "scopedRegistries": [
    {
      "name": "GameFrameX",
      "url": "https://gameframex.upm.alianblank.uk",
      "scopes": [
        "com.gameframex"
      ]
    }
  ]
}
```

`scopes` は、どのパッケージをこのレジストリから解決するかを制御します。`com.gameframex` で始まるパッケージのみがこのレジストリから取得されます。

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.payment.google": "1.0.0"
  }
}
```

## 使用例

### 初期化

```csharp
// Google Play Billing を初期化
GooglePlayBilling.Instance.Initialize();
```

### 商品の照会

```csharp
// 一回限り商品を照会
GooglePlayBilling.Instance.QueryProductDetails("product_id_1,product_id_2", "inapp");

// サブスクリプション商品を照会
GooglePlayBilling.Instance.QueryProductDetails("subscription_id_1,subscription_id_2", "subs");
```

### 商品の購入

```csharp
// 一回限り商品を購入
GooglePlayBilling.Instance.Purchase("product_id", "inapp");

// サブスクリプション商品を購入
GooglePlayBilling.Instance.Purchase("subscription_id", "subs");

// オファー付きサブスクリプション商品を購入
GooglePlayBilling.Instance.PurchaseWithOffer("subscription_id", "subs", "offer_token");
```

### 購入の消費

```csharp
// 購入を消費（消費型商品のみ）
GooglePlayBilling.Instance.ConsumePurchase("purchase_token");
```

### 購入履歴の照会

```csharp
// 一回限り商品の購入履歴を照会
GooglePlayBilling.Instance.QueryPurchases("inapp");

// サブスクリプション商品の購入履歴を照会
GooglePlayBilling.Instance.QueryPurchases("subs");
```

## プラットフォーム対応

| プラットフォーム | 対応 |
|------------------|------|
| Android          | はい |

## 変更履歴

詳細は [CHANGELOG.md](CHANGELOG.md) をご覧ください。


## 依存関係

| パッケージ | 説明 |
|----------|------|
| `com.gameframex.unity` | 1.1.1 |

## ドキュメントとリソース

- [ドキュメント](https://gameframex.doc.alianblank.com)

## コミュニティとサポート

- QQグループ: 467608841 / 233840761
## ライセンス

詳しくは [LICENSE.md](LICENSE.md) をご参照ください。
