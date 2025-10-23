// GameFrameX 组织下的以及组织衍生的项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
// 
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE 文件。
// 
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;
using System.Collections.Generic;

namespace GameFrameX.Payment.Google.Runtime
{
    /// <summary>
    /// 商品信息
    /// </summary>
    [Serializable]
    [UnityEngine.Scripting.Preserve]
    public sealed class ProductInfo
    {
        /// <summary>
        /// 商品ID，用于标识商品的唯一标识符
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string ProductId { get; set; }

        /// <summary>
        /// 商品类型，可以是"inapp"(一次性商品)或"subs"(订阅商品)
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string ProductType { get; set; }

        /// <summary>
        /// 商品标题，在商店中显示的主要标题
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string Title { get; set; }

        /// <summary>
        /// 商品描述，详细说明商品的特性和内容
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string Description { get; set; }

        /// <summary>
        /// 商品名称，通常是简短的标识名
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string Name { get; set; }

        /// <summary>
        /// 商品价格（以微单位计），例如 1000000 表示 1.00
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public long PriceAmountMicros { get; set; }

        /// <summary>
        /// 价格货币代码，例如 "USD", "CNY" 等
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string PriceCurrencyCode { get; set; }

        /// <summary>
        /// 格式化后的价格字符串，包含货币符号，如 "$1.00"
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string FormattedPrice { get; set; }

        /// <summary>
        /// 订阅商品的优惠信息列表，仅对订阅商品有效
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public List<SubscriptionOffer> SubscriptionOffers { get; set; }
    }
}