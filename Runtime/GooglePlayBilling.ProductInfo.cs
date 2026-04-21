// ==========================================================================================
//   GameFrameX 组织及其衍生项目的版权、商标、专利及其他相关权利
//   GameFrameX organization and its derivative projects' copyrights, trademarks, patents, and related rights
//   均受中华人民共和国及相关国际法律法规保护。
//   are protected by the laws of the People's Republic of China and relevant international regulations.
//   使用本项目须严格遵守相应法律法规及开源许可证之规定。
//   Usage of this project must strictly comply with applicable laws, regulations, and open-source licenses.
//   本项目采用 MIT 许可证与 Apache License 2.0 双许可证分发，
//   This project is dual-licensed under the MIT License and Apache License 2.0,
//   完整许可证文本请参见源代码根目录下的 LICENSE 文件。
//   please refer to the LICENSE file in the root directory of the source code for the full license text.
//   禁止利用本项目实施任何危害国家安全、破坏社会秩序、
//   It is prohibited to use this project to engage in any activities that endanger national security, disrupt social order,
//   侵犯他人合法权益等法律法规所禁止的行为！
//   or infringe upon the legitimate rights and interests of others, as prohibited by laws and regulations!
//   因基于本项目二次开发所产生的一切法律纠纷与责任，
//   Any legal disputes and liabilities arising from secondary development based on this project
//   本项目组织与贡献者概不承担。
//   shall be borne solely by the developer; the project organization and contributors assume no responsibility.
//   GitHub 仓库：https://github.com/GameFrameX
//   GitHub Repository: https://github.com/GameFrameX
//   Gitee  仓库：https://gitee.com/GameFrameX
//   Gitee Repository:  https://gitee.com/GameFrameX
//   CNB  仓库：https://cnb.cool/GameFrameX
//   CNB Repository:  https://cnb.cool/GameFrameX
//   官方文档：https://gameframex.doc.alianblank.com/
//   Official Documentation: https://gameframex.doc.alianblank.com/
//  ==========================================================================================

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