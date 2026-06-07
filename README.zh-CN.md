<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Payment Google

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.payment.google)](https://github.com/GameFrameX/com.gameframex.unity.payment.google/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.payment.google)](https://github.com/GameFrameX/com.gameframex.unity.payment.google/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使

<br />

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 语言

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## 项目简介

本插件提供了一套简单易用的 API，用于在 Unity 应用中集成 Google Play 应用内支付功能。它封装了 Google Play Billing Library 的复杂性，提供了一个统一的接口，使开发者能够轻松实现以下功能：

- 初始化 Google Play Billing
- 查询商品详情
- 购买商品（一次性商品和订阅）
- 消耗购买（消耗型商品）
- 查询购买历史

## 快速开始

### 安装

编辑 Unity 项目的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：

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

`scopes` 控制哪些包通过此注册表解析。只有以 `com.gameframex` 开头的包才会从这个注册表获取。

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.payment.google": "1.0.0"
  }
}
```

## 使用示例

### 初始化

```csharp
// 初始化 Google Play Billing
GooglePlayBilling.Instance.Initialize();
```

### 查询商品

```csharp
// 查询一次性商品
GooglePlayBilling.Instance.QueryProductDetails("product_id_1,product_id_2", "inapp");

// 查询订阅商品
GooglePlayBilling.Instance.QueryProductDetails("subscription_id_1,subscription_id_2", "subs");
```

### 购买商品

```csharp
// 购买一次性商品
GooglePlayBilling.Instance.Purchase("product_id", "inapp");

// 购买订阅商品
GooglePlayBilling.Instance.Purchase("subscription_id", "subs");

// 购买带优惠的订阅商品
GooglePlayBilling.Instance.PurchaseWithOffer("subscription_id", "subs", "offer_token");
```

### 消耗购买

```csharp
// 消耗购买（仅适用于消耗型商品）
GooglePlayBilling.Instance.ConsumePurchase("purchase_token");
```

### 查询购买历史

```csharp
// 查询一次性商品的购买历史
GooglePlayBilling.Instance.QueryPurchases("inapp");

// 查询订阅商品的购买历史
GooglePlayBilling.Instance.QueryPurchases("subs");
```

## 平台支持

| 平台    | 支持 |
|---------|------|
| Android | 是   |

## 更新日志

详见 [CHANGELOG.md](CHANGELOG.md)。

## 开源协议

详见 [LICENSE.md](LICENSE.md) 文件。
