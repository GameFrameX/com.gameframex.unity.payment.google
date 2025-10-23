// GameFrameX 组织下的以及组织衍生的项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
// 
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE 文件。
// 
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;

namespace GameFrameX.Payment.Google.Runtime
{
    /// <summary>
    /// 购买信息
    /// </summary>
    [Serializable]
    [UnityEngine.Scripting.Preserve]
    public sealed class PurchaseInfo
    {
        /// <summary>
        /// 订单ID，购买交易的唯一标识符
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string OrderId { get; set; }

        /// <summary>
        /// 应用包名
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string PackageName { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string ProductId { get; set; }

        /// <summary>
        /// 购买时间戳（毫秒）
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public long PurchaseTime { get; set; }

        /// <summary>
        /// 购买状态，表示当前购买的状态（如待处理、已完成等）
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public int PurchaseState { get; set; }

        /// <summary>
        /// 购买令牌，用于后续的购买验证和消耗
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string PurchaseToken { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public int Quantity { get; set; }

        /// <summary>
        /// 是否已确认购买
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public bool IsAcknowledged { get; set; }

        /// <summary>
        /// 是否自动续订（仅适用于订阅商品）
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public bool IsAutoRenewing { get; set; }

        /// <summary>
        /// 混淆的账户ID，用于标识购买用户的账户
        /// </summary>
        /// <value>返回混淆的账户标识符字符串，如果未设置则为空字符串</value>
        [UnityEngine.Scripting.Preserve]
        public string ObfuscatedAccountId { get; set; }

        /// <summary>
        /// 混淆的配置文件ID，用于标识购买用户的配置文件
        /// </summary>
        /// <value>返回混淆的配置文件标识符字符串，如果未设置则为空字符串</value>
        [UnityEngine.Scripting.Preserve]
        public string ObfuscatedProfileId { get; set; }
    }
}