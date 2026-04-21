// GameFrameX 组织下的以及组织衍生的项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规的许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;
using System.Collections.Generic;
using GameFrameX.Payment.Runtime;

namespace GameFrameX.Payment.Google.Runtime
{
    [UnityEngine.Scripting.Preserve]
    public sealed class GooglePaymentManager : BasePaymentManager
    {
        private static string ToProductTypeString(PaymentProductType productType)
        {
            return productType == PaymentProductType.Subs ? "subs" : "inapp";
        }

        [UnityEngine.Scripting.Preserve]
        public GooglePaymentManager()
        {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="isDebug">是否是沙盒模式</param>
        /// <param name="isClientVerify">是否进行客户端验证</param>
        [UnityEngine.Scripting.Preserve]
        public override void Init(bool isDebug = false, bool isClientVerify = false)
        {
            GooglePlayBilling.Instance.Initialize(isDebug);
        }

        /// <summary>
        /// 支付系统是否准备好
        /// </summary>
        /// <returns>准备好返回true，否则返回false</returns>
        [UnityEngine.Scripting.Preserve]
        public override bool IsReady()
        {
            return GooglePlayBilling.Instance.IsReady();
        }

        /// <summary>
        /// 设置预加载的预定义商品ID
        /// </summary>
        /// <param name="inAppProductIds">内购商品ID列表</param>
        /// <param name="subsProductIds">订阅商品ID列表</param>
        [UnityEngine.Scripting.Preserve]
        public override void SetPredefinedProductIds(List<string> inAppProductIds, List<string> subsProductIds)
        {
            GooglePlayBilling.Instance.SetPredefinedProductIds(inAppProductIds, subsProductIds);
        }

        /// <summary>
        /// 查询购买记录
        /// </summary>
        /// <param name="productType">产品类型</param>
        [UnityEngine.Scripting.Preserve]
        public override void QueryPurchases(PaymentProductType productType)
        {
            GooglePlayBilling.Instance.QueryPurchases(ToProductTypeString(productType));
        }

        /// <summary>
        /// 消耗购买
        /// </summary>
        /// <param name="purchaseToken">购买令牌</param>
        [UnityEngine.Scripting.Preserve]
        public override void ConsumePurchase(string purchaseToken)
        {
            GooglePlayBilling.Instance.ConsumePurchase(purchaseToken);
        }

        /// <summary>
        /// 购买 一次性商品
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        [Obsolete("请使用 Buy(PurchaseParams) 替代")]
        public override void BuyInApp(string productId, string orderId, string offerToken = "", string customData = "")
        {
            GooglePlayBilling.Instance.PurchaseWithAllParams(productId, "inapp", offerToken, orderId, customData);
        }

        /// <summary>
        /// 购买 订阅商品
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        [Obsolete("请使用 Buy(PurchaseParams) 替代")]
        public override void BuySubs(string productId, string orderId, string offerToken = "", string customData = "")
        {
            GooglePlayBilling.Instance.PurchaseWithAllParams(productId, "subs", offerToken, orderId, customData);
        }

        /// <summary>
        /// 购买
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        [Obsolete("请使用 Buy(PurchaseParams) 替代")]
        public override void Buy(string productId, PaymentProductType productType, string orderId, string offerToken = "", string customData = "")
        {
            GooglePlayBilling.Instance.PurchaseWithAllParams(productId, ToProductTypeString(productType), offerToken, orderId, customData);
        }

        /// <summary>
        /// 购买（推荐使用）
        /// </summary>
        /// <param name="purchaseParams">购买参数，推荐使用 GooglePurchaseParams</param>
        [UnityEngine.Scripting.Preserve]
        public override void Buy(PurchaseParams purchaseParams)
        {
            if (purchaseParams is GooglePurchaseParams googleParams)
            {
                GooglePlayBilling.Instance.PurchaseWithAllParams(
                    googleParams.ProductId,
                    ToProductTypeString(googleParams.ProductType),
                    googleParams.OfferToken,
                    googleParams.OrderId,
                    googleParams.CustomData);
            }
            else
            {
                GooglePlayBilling.Instance.PurchaseWithAllParams(
                    purchaseParams.ProductId,
                    ToProductTypeString(purchaseParams.ProductType),
                    "",
                    purchaseParams.OrderId,
                    "");
            }
        }
    }
}
