// GameFrameX 组织下的以及组织衍生的项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
// 
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE 文件。
// 
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;

namespace GameFrameX.Payment.Google.Runtime
{
    /// <summary>
    /// 价格阶段信息
    /// </summary>
    [Serializable]
    [UnityEngine.Scripting.Preserve]
    public sealed class PricingPhase
    {
        /// <summary>
        /// 价格金额（以微单位计）
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public long PriceAmountMicros { get; set; }

        /// <summary>
        /// 价格货币代码
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string PriceCurrencyCode { get; set; }

        /// <summary>
        /// 格式化后的价格字符串
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string FormattedPrice { get; set; }

        /// <summary>
        /// 计费周期，如 "P1M"（1个月）, "P1Y"（1年）等
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string BillingPeriod { get; set; }

        /// <summary>
        /// 计费周期计数，表示该价格阶段包含几个计费周期
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public int BillingCycleCount { get; set; }

        /// <summary>
        /// 重复模式，定义订阅如何续订
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public int RecurrenceMode { get; set; }
    }
}