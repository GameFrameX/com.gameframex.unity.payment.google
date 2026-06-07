<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Payment Google

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.payment.google)](https://github.com/GameFrameX/com.gameframex.unity.payment.google/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.payment.google)](https://github.com/GameFrameX/com.gameframex.unity.payment.google/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현

<br />

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#빠른-시작) · QQ 그룹: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

</div>
## 언어

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

---

## 프로젝트 개요

이 플러그인은 Unity 애플리케이션에 Google Play 인앱 결제 기능을 통합하기 위한 간단하고 사용하기 쉬운 API를 제공합니다. Google Play Billing Library의 복잡성을 캡슐화하고 통합된 인터페이스를 제공하여 개발자가 다음 기능을 쉽게 구현할 수 있도록 합니다:

- Google Play Billing 초기화
- 상품 상세 조회
- 상품 구매 (일회성 상품 및 구독)
- 구매 소비 (소비성 상품)
- 구매 내역 조회

## 빠른 시작

### 1. 플러그인 가져오기

`GooglePlayBilling.cs` 및 관련 파일을 Unity 프로젝트로 가져옵니다.

### 2. AndroidManifest.xml 설정

AndroidManifest.xml에 다음 권한이 포함되어 있는지 확인합니다:

```xml
<uses-permission android:name="com.android.vending.BILLING"/>
```

### 3. Gradle 빌드 파일 설정

Gradle 빌드 파일에 Google Play Billing Library 종속성이 포함되어 있는지 확인합니다:

```gradle
dependencies {
    implementation 'com.android.billingclient:billing:8.0.0'
}
```

### 4. Unity에서 사용

게임 씬에 `GooglePlayBilling` 컴포넌트를 추가하거나 코드로 동적으로 생성합니다:

```csharp
// GooglePlayBilling 인스턴스 가져오기
GooglePlayBilling billingManager = GooglePlayBilling.Instance;

// 이벤트 리스너 등록
billingManager.OnInitialized += OnInitialized;
billingManager.OnProductsQueried += OnProductsQueried;
billingManager.OnPurchaseCompleted += OnPurchaseCompleted;

// 초기화
billingManager.Initialize();
```

## 사용 예시

### 초기화

```csharp
// Google Play Billing 초기화
GooglePlayBilling.Instance.Initialize();
```

### 상품 조회

```csharp
// 일회성 상품 조회
GooglePlayBilling.Instance.QueryProductDetails("product_id_1,product_id_2", "inapp");

// 구독 상품 조회
GooglePlayBilling.Instance.QueryProductDetails("subscription_id_1,subscription_id_2", "subs");
```

### 상품 구매

```csharp
// 일회성 상품 구매
GooglePlayBilling.Instance.Purchase("product_id", "inapp");

// 구독 상품 구매
GooglePlayBilling.Instance.Purchase("subscription_id", "subs");

// 할인이 포함된 구독 상품 구매
GooglePlayBilling.Instance.PurchaseWithOffer("subscription_id", "subs", "offer_token");
```

### 구매 소비

```csharp
// 구매 소비 (소비성 상품에만 해당)
GooglePlayBilling.Instance.ConsumePurchase("purchase_token");
```

### 구매 내역 조회

```csharp
// 일회성 상품 구매 내역 조회
GooglePlayBilling.Instance.QueryPurchases("inapp");

// 구독 상품 구매 내역 조회
GooglePlayBilling.Instance.QueryPurchases("subs");
```

## 플랫폼 지원

| 플랫폼  | 지원 |
|---------|------|
| Android | 예   |

## 변경 로그

자세한 내용은 [CHANGELOG.md](CHANGELOG.md)를 참조하세요.

## 라이선스

이 프로젝트는 MIT 라이선스에 따라 배포됩니다. 자세한 내용은 [LICENSE.md](LICENSE.md) 파일을 참조하세요.
