<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Payment Google

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.payment.google)](https://github.com/GameFrameX/com.gameframex.unity.payment.google/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.payment.google)](https://github.com/GameFrameX/com.gameframex.unity.payment.google/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

<br />

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 語言

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## 項目簡介

本插件提供了一套簡單易用的 API，用於在 Unity 應用中整合 Google Play 應用內支付功能。它封裝了 Google Play Billing Library 的複雜性，提供了統一的介面，使開發者能夠輕鬆實現以下功能：

- 初始化 Google Play Billing
- 查詢商品詳情
- 購買商品（一次性商品和訂閱）
- 消耗購買（消耗型商品）
- 查詢購買歷史

## 快速開始

### 安裝

編輯 Unity 專案的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：

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

`scopes` 控制哪些套件透過此註冊表解析。只有以 `com.gameframex` 開頭的套件才會從這個註冊表取得。

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.payment.google": "1.0.0"
  }
}
```


## 使用範例

### 初始化

```csharp
// 初始化 Google Play Billing
GooglePlayBilling.Instance.Initialize();
```

### 查詢商品

```csharp
// 查詢一次性商品
GooglePlayBilling.Instance.QueryProductDetails("product_id_1,product_id_2", "inapp");

// 查詢訂閱商品
GooglePlayBilling.Instance.QueryProductDetails("subscription_id_1,subscription_id_2", "subs");
```

### 購買商品

```csharp
// 購買一次性商品
GooglePlayBilling.Instance.Purchase("product_id", "inapp");

// 購買訂閱商品
GooglePlayBilling.Instance.Purchase("subscription_id", "subs");

// 購買帶優惠的訂閱商品
GooglePlayBilling.Instance.PurchaseWithOffer("subscription_id", "subs", "offer_token");
```

### 消耗購買

```csharp
// 消耗購買（僅適用於消耗型商品）
GooglePlayBilling.Instance.ConsumePurchase("purchase_token");
```

### 查詢購買歷史

```csharp
// 查詢一次性商品的購買歷史
GooglePlayBilling.Instance.QueryPurchases("inapp");

// 查詢訂閱商品的購買歷史
GooglePlayBilling.Instance.QueryPurchases("subs");
```

## 平台支援

| 平台    | 支援 |
|---------|------|
| Android | 是   |

## 更新日誌

詳見 [CHANGELOG.md](CHANGELOG.md)。

## 開源協議

本專案基於 MIT 協議開源，詳見 [LICENSE.md](LICENSE.md) 檔案。
