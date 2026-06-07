<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Payment Google

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.payment.google)](https://github.com/GameFrameX/com.gameframex.unity.payment.google/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.payment.google)](https://github.com/GameFrameX/com.gameframex.unity.payment.google/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>
## Language

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## Project Overview

This plugin provides a simple and easy-to-use API for integrating Google Play in-app purchase functionality into Unity applications. It encapsulates the complexity of Google Play Billing Library and provides a unified interface, enabling developers to easily implement:

- Initialize Google Play Billing
- Query product details
- Purchase products (one-time products and subscriptions)
- Consume purchases (consumable products)
- Query purchase history

## Quick Start

### 1. Import Plugin

Import `GooglePlayBilling.cs` and related files into your Unity project.

### 2. Configure AndroidManifest.xml

Ensure your AndroidManifest.xml contains the following permission:

```xml
<uses-permission android:name="com.android.vending.BILLING"/>
```

### 3. Configure Gradle Build File

Ensure your Gradle build file includes the Google Play Billing Library dependency:

```gradle
dependencies {
    implementation 'com.android.billingclient:billing:8.0.0'
}
```

### 4. Usage

Add the `GooglePlayBilling` component to your game scene, or create it dynamically via code:

```csharp
// Get GooglePlayBilling instance
GooglePlayBilling billingManager = GooglePlayBilling.Instance;

// Register event listeners
billingManager.OnInitialized += OnInitialized;
billingManager.OnProductsQueried += OnProductsQueried;
billingManager.OnPurchaseCompleted += OnPurchaseCompleted;

// Initialize
billingManager.Initialize();
```

## Usage Examples

### Initialize

```csharp
// Initialize Google Play Billing
GooglePlayBilling.Instance.Initialize();
```

### Query Products

```csharp
// Query one-time products
GooglePlayBilling.Instance.QueryProductDetails("product_id_1,product_id_2", "inapp");

// Query subscription products
GooglePlayBilling.Instance.QueryProductDetails("subscription_id_1,subscription_id_2", "subs");
```

### Purchase Products

```csharp
// Purchase a one-time product
GooglePlayBilling.Instance.Purchase("product_id", "inapp");

// Purchase a subscription product
GooglePlayBilling.Instance.Purchase("subscription_id", "subs");

// Purchase a subscription product with an offer
GooglePlayBilling.Instance.PurchaseWithOffer("subscription_id", "subs", "offer_token");
```

### Consume Purchase

```csharp
// Consume purchase (only for consumable products)
GooglePlayBilling.Instance.ConsumePurchase("purchase_token");
```

### Query Purchase History

```csharp
// Query purchase history for one-time products
GooglePlayBilling.Instance.QueryPurchases("inapp");

// Query purchase history for subscription products
GooglePlayBilling.Instance.QueryPurchases("subs");
```

## Platform Support

| Platform | Supported |
|----------|-----------|
| Android  | Yes       |

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for details.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
