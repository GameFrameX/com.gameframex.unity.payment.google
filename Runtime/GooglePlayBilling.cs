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
using GameFrameX.Runtime;
using UnityEngine;

namespace GameFrameX.Payment.Google.Runtime
{
    /// <summary>
    /// Google Play 应用内支付管理类
    /// 用于Unity端与Android端通信，处理应用内购买功能
    /// </summary>
    public class GooglePlayBilling : MonoBehaviour
    {
        #region 单例实现

        private static GooglePlayBilling _instance;

        public static GooglePlayBilling Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject("GooglePlayBillingBridge");
                    _instance = go.AddComponent<GooglePlayBilling>();
                    DontDestroyOnLoad(go);
                }

                return _instance;
            }
        }

        #endregion

        #region 消息代码

        // 初始化相关
        [UnityEngine.Scripting.Preserve] private const int InitSuccess = 1000;
        [UnityEngine.Scripting.Preserve] private const int InitFail = 1001;

        // 查询商品相关
        [UnityEngine.Scripting.Preserve] private const int QueryProductsSuccess = 2000;
        [UnityEngine.Scripting.Preserve] private const int QueryProductsFail = 2001;

        // 购买相关
        [UnityEngine.Scripting.Preserve] private const int PurchaseSuccess = 3000;
        [UnityEngine.Scripting.Preserve] private const int PurchaseFail = 3001;
        [UnityEngine.Scripting.Preserve] private const int PurchaseCancel = 3002;

        // 消耗相关
        [UnityEngine.Scripting.Preserve] private const int ConsumeSuccess = 4000;
        [UnityEngine.Scripting.Preserve] private const int ConsumeFail = 4001;

        // 查询购买历史相关
        [UnityEngine.Scripting.Preserve] private const int QueryPurchasesSuccess = 5000;
        [UnityEngine.Scripting.Preserve] private const int QueryPurchasesFail = 5001;

        #endregion

        #region 事件定义

        // 初始化事件
        [UnityEngine.Scripting.Preserve] public event Action<bool, string> OnInitialized;

        // 查询商品事件
        [UnityEngine.Scripting.Preserve] public event Action<bool, List<ProductInfo>> OnProductsQueried;

        // 购买事件
        [UnityEngine.Scripting.Preserve] public event Action<bool, PurchaseInfo> OnPurchaseCompleted;
        [UnityEngine.Scripting.Preserve] public event Action OnPurchaseCancelled;

        // 消耗事件
        [UnityEngine.Scripting.Preserve] public event Action<bool, string> OnPurchaseConsumed;

        // 查询购买历史事件
        [UnityEngine.Scripting.Preserve] public event Action<bool, List<PurchaseInfo>> OnPurchasesQueried;

        #endregion

        #region Android桥接

        private AndroidJavaObject _pluginInstance;
        private bool _isInitialized = false;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);

#if UNITY_ANDROID && !UNITY_EDITOR
            try
            {
                _pluginInstance = new AndroidJavaClass("com.alianblank.google.play.GooglePlayBillingBridge");
                Debug.Log("Google Play Billing 插件加载成功");
            }
            catch (Exception e)
            {
                Debug.LogError("Google Play Billing 插件加载失败: " + e.Message);
            }

#else
            Debug.Log("Google Play Billing 仅在Android平台上可用");
#endif
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 初始化Google Play Billing
        /// </summary>
        /// <param name="isDebug"></param>
        [UnityEngine.Scripting.Preserve]
        public void Initialize(bool isDebug = false)
        {
            if (_isInitialized)
            {
                Debug.Log("Google Play Billing 已经初始化");
                OnInitialized?.Invoke(true, "Google Play Billing 已经初始化");
                return;
            }

#if UNITY_ANDROID && !UNITY_EDITOR
            if (_pluginInstance != null)
            {
                try
                {
                    _pluginInstance.CallStatic("initialize");
                    Debug.Log("Google Play Billing 初始化请求已发送");
                }
                catch (Exception e)
                {
                    Debug.LogError("Google Play Billing 初始化失败: " + e.Message);
                    OnInitialized?.Invoke(false, "初始化失败: " + e.Message);
                }
            }
            else
            {
                Debug.LogError("Google Play Billing 插件未加载");
                OnInitialized?.Invoke(false, "插件未加载");
            }

#else
            Debug.Log("Google Play Billing 仅在Android平台上可用");
            OnInitialized?.Invoke(false, "仅在Android平台上可用");
#endif
        }

        /// <summary>
        /// 查询商品详情
        /// </summary>
        /// <param name="productIds">商品ID列表，用逗号分隔</param>
        /// <param name="productType">商品类型，可以是 "inapp" 或 "subs"</param>
        [UnityEngine.Scripting.Preserve]
        public void QueryProductDetails(string productIds, string productType = "inapp")
        {
            if (!_isInitialized)
            {
                Debug.LogWarning("Google Play Billing 未初始化，尝试初始化...");
                Initialize();
                return;
            }

#if UNITY_ANDROID && !UNITY_EDITOR
            if (_pluginInstance != null)
            {
                try
                {
                    _pluginInstance.CallStatic("queryProductDetails", productIds, productType);
                    Debug.Log("查询商品详情请求已发送: " + productIds);
                }
                catch (Exception e)
                {
                    Debug.LogError("查询商品详情失败: " + e.Message);
                    OnProductsQueried?.Invoke(false, null);
                }
            }
            else
            {
                Debug.LogError("Google Play Billing 插件未加载");
                OnProductsQueried?.Invoke(false, null);
            }

#else
            Debug.Log("Google Play Billing 仅在Android平台上可用");
            OnProductsQueried?.Invoke(false, null);
#endif
        }

        /// <summary>
        /// 发起购买（带完整参数）
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <param name="productType">商品类型，可以是 "inapp" 或 "subs"</param>
        /// <param name="offerToken">订阅优惠令牌（仅订阅商品需要）</param>
        /// <param name="obfuscatedAccountId">混淆的账户ID，用于标识购买用户的账户</param>
        /// <param name="obfuscatedProfileId">混淆的配置文件ID，用于标识购买用户的配置文件</param>
        [UnityEngine.Scripting.Preserve]
        public void PurchaseWithAllParams(string productId, string productType = "inapp", string offerToken = "", string obfuscatedAccountId = "", string obfuscatedProfileId = "")
        {
            if (!_isInitialized)
            {
                Debug.LogWarning("Google Play Billing 未初始化，尝试初始化...");
                Initialize();
                return;
            }

#if UNITY_ANDROID && !UNITY_EDITOR
            if (_pluginInstance != null)
            {
                try
                {
                    _pluginInstance.CallStatic("purchaseWithAllParams", productId, productType, offerToken, obfuscatedAccountId, obfuscatedProfileId);
                    Debug.Log($"发起购买(带完整参数)请求已发送: {productId}, 账户ID: {obfuscatedAccountId}, 配置文件ID: {obfuscatedProfileId}");
                }
                catch (Exception e)
                {
                    Debug.LogError("发起购买(带完整参数)失败: " + e.Message);
                    OnPurchaseCompleted?.Invoke(false, null);
                }
            }
            else
            {
                Debug.LogError("Google Play Billing 插件未加载");
                OnPurchaseCompleted?.Invoke(false, null);
            }

#else
            Debug.Log("Google Play Billing 仅在Android平台上可用");
            OnPurchaseCompleted?.Invoke(false, null);
#endif
        }

        /// <summary>
        /// 消耗购买（消耗型商品）
        /// </summary>
        /// <param name="purchaseToken">购买令牌</param>
        [UnityEngine.Scripting.Preserve]
        public void ConsumePurchase(string purchaseToken)
        {
            if (!_isInitialized)
            {
                Debug.LogWarning("Google Play Billing 未初始化，尝试初始化...");
                Initialize();
                return;
            }

#if UNITY_ANDROID && !UNITY_EDITOR
            if (_pluginInstance != null)
            {
                try
                {
                    _pluginInstance.CallStatic("consumePurchase", purchaseToken);
                    Debug.Log("消耗购买请求已发送: " + purchaseToken);
                }
                catch (Exception e)
                {
                    Debug.LogError("消耗购买失败: " + e.Message);
                    OnPurchaseConsumed?.Invoke(false, "消耗购买失败: " + e.Message);
                }
            }
            else
            {
                Debug.LogError("Google Play Billing 插件未加载");
                OnPurchaseConsumed?.Invoke(false, "插件未加载");
            }

#else
            Debug.Log("Google Play Billing 仅在Android平台上可用");
            OnPurchaseConsumed?.Invoke(false, "仅在Android平台上可用");
#endif
        }

        /// <summary>
        /// 查询购买历史
        /// </summary>
        /// <param name="productType">商品类型，可以是 "inapp" 或 "subs"</param>
        [UnityEngine.Scripting.Preserve]
        public void QueryPurchases(string productType = "inapp")
        {
            if (!_isInitialized)
            {
                Debug.LogWarning("Google Play Billing 未初始化，尝试初始化...");
                Initialize();
                return;
            }

#if UNITY_ANDROID && !UNITY_EDITOR
            if (_pluginInstance != null)
            {
                try
                {
                    _pluginInstance.CallStatic("queryPurchases", productType);
                    Debug.Log("查询购买历史请求已发送: " + productType);
                }
                catch (Exception e)
                {
                    Debug.LogError("查询购买历史失败: " + e.Message);
                    OnPurchasesQueried?.Invoke(false, null);
                }
            }
            else
            {
                Debug.LogError("Google Play Billing 插件未加载");
                OnPurchasesQueried?.Invoke(false, null);
            }

#else
            Debug.Log("Google Play Billing 仅在Android平台上可用");
            OnPurchasesQueried?.Invoke(false, null);
#endif
        }

        /// <summary>
        /// 设置预定义商品ID列表（用于预加载缓存）
        /// 注意：此方法必须在Initialize()之前调用
        /// </summary>
        /// <param name="inAppProductIds">一次性商品ID数组</param>
        /// <param name="subsProductIds">订阅商品ID数组</param>
        [UnityEngine.Scripting.Preserve]
        public void SetPredefinedProductIds(List<string> inAppProductIds, List<string> subsProductIds = null)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (_pluginInstance != null)
            {
                string inAppJson = "[]";
                try
                {
                    // 将字符串数组转换为JSON格式
                    inAppJson = Utility.Json.ToJson(inAppProductIds ?? new List<string>());
                    Debug.Log($"设置预定义商品ID - 一次性商品: {inAppJson}");
                }
                catch (Exception e)
                {
                    Debug.LogError("设置预定义商品ID失败: " + e.Message);
                }

                string subsJson = "[]";
                try
                {
                    // 将字符串数组转换为JSON格式
                    subsJson = Utility.Json.ToJson(subsProductIds ?? new List<string>());
                    Debug.Log($"设置预定义商品ID - 订阅商品: {subsJson}");
                }
                catch (Exception e)
                {
                    Debug.LogError("设置预定义商品ID失败: " + e.Message);
                }

                try
                {
                    // 将字符串数组转换为JSON格式
                    _pluginInstance.CallStatic("setPredefinedProductIds", inAppJson, subsJson);
                }
                catch (Exception e)
                {
                    Debug.LogError("设置预定义商品ID失败: " + e.Message);
                }
            }
            else
            {
                Debug.LogError("Google Play Billing 插件未加载");
            }

#else
            Debug.Log("Google Play Billing 仅在Android平台上可用");
#endif
        }

        /// <summary>
        /// 清空商品详情缓存
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public void ClearProductDetailsCache()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (_pluginInstance != null)
            {
                try
                {
                    _pluginInstance.CallStatic("clearProductDetailsCache");
                    Debug.Log("已清空商品详情缓存");
                }
                catch (Exception e)
                {
                    Debug.LogError("清空商品详情缓存失败: " + e.Message);
                }
            }
            else
            {
                Debug.LogError("Google Play Billing 插件未加载");
            }

#else
            Debug.Log("Google Play Billing 仅在Android平台上可用");
#endif
        }


        /// <summary>
        /// 检查支付系统是否就绪
        /// </summary>
        /// <returns>如果就绪返回true，否则返回false</returns>
        [UnityEngine.Scripting.Preserve]
        public bool IsReady()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (_pluginInstance != null)
            {
                try
                {
                    string result = _pluginInstance.CallStatic<string>("isReady");
                    bool isReady = bool.Parse(result);
                    Debug.Log($"检查支付系统是否就绪: {isReady}");
                    return isReady;
                }
                catch (Exception e)
                {
                    Debug.LogError("检查支付系统是否就绪失败: " + e.Message);
                    return false;
                }
            }
            else
            {
                Debug.LogError("Google Play Billing 插件未加载");
                return false;
            }

#else
            Debug.Log("Google Play Billing 仅在Android平台上可用");
            return false;
#endif
        }


        /// <summary>
        /// 检查商品详情是否已缓存
        /// </summary>
        /// <returns>如果商品详情已缓存返回true，否则返回false</returns>
        [UnityEngine.Scripting.Preserve]
        public bool IsProductDetailsCached()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (_pluginInstance != null)
            {
                try
                {
                    string result = _pluginInstance.CallStatic<string>("isProductDetailsCached");
                    bool cached = bool.Parse(result);
                    Debug.Log($"商品详情缓存状态: {cached}");
                    return cached;
                }
                catch (Exception e)
                {
                    Debug.LogError("检查商品详情缓存状态失败: " + e.Message);
                    return false;
                }
            }
            else
            {
                Debug.LogError("Google Play Billing 插件未加载");
                return false;
            }

#else
            Debug.Log("Google Play Billing 仅在Android平台上可用");
            return false;
#endif
        }

        /// <summary>
        /// 获取缓存中的商品类型（用于调试）
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <returns>商品类型，如果不存在返回null</returns>
        [UnityEngine.Scripting.Preserve]
        public string GetCachedProductType(string productId)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (_pluginInstance != null)
            {
                try
                {
                    string result = _pluginInstance.CallStatic<string>("getCachedProductType", productId);
                    if (result == "null")
                    {
                        Debug.Log($"商品 {productId} 不在缓存中");
                        return null;
                    }
                    else if (result == "error")
                    {
                        Debug.LogError($"获取商品 {productId} 缓存类型时发生错误");
                        return null;
                    }
                    else
                    {
                        Debug.Log($"商品 {productId} 的缓存类型: {result}");
                        return result;
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError("获取缓存商品类型失败: " + e.Message);
                    return null;
                }
            }
            else
            {
                Debug.LogError("Google Play Billing 插件未加载");
                return null;
            }

#else
            Debug.Log("Google Play Billing 仅在Android平台上可用");
            return null;
#endif
        }

        #endregion

        #region 消息处理

        /// <summary>
        /// 接收来自Android的消息
        /// 此方法由Android端通过UnitySendMessage调用
        /// </summary>
        /// <param name="message">消息内容，格式为 "消息代码|消息内容"</param>
        [UnityEngine.Scripting.Preserve]
        public void OnMessage(string message)
        {
            Debug.Log("收到来自Android的消息: " + message);

            try
            {
                string[] parts = message.Split(new char[] { '|' }, 2);
                if (parts.Length < 2)
                {
                    Debug.LogError("无效的消息格式: " + message);
                    return;
                }

                int messageCode = int.Parse(parts[0]);
                string messageContent = parts[1];

                ProcessMessage(messageCode, messageContent);
            }
            catch (Exception e)
            {
                Debug.LogError("处理消息时出错: " + e.Message);
            }
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="messageCode">消息代码</param>
        /// <param name="messageContent">消息内容</param>
        private void ProcessMessage(int messageCode, string messageContent)
        {
            switch (messageCode)
            {
                // 初始化相关
                case InitSuccess:
                    _isInitialized = true;
                    Debug.Log("Google Play Billing 初始化成功: " + messageContent);
                    OnInitialized?.Invoke(true, messageContent);
                    break;

                case InitFail:
                    _isInitialized = false;
                    Debug.LogError("Google Play Billing 初始化失败: " + messageContent);
                    OnInitialized?.Invoke(false, messageContent);
                    break;

                // 查询商品相关
                case QueryProductsSuccess:
                    Debug.Log("查询商品成功: " + messageContent);
                    List<ProductInfo> products = ParseProductsJson(messageContent);
                    OnProductsQueried?.Invoke(true, products);
                    break;

                case QueryProductsFail:
                    Debug.LogError("查询商品失败: " + messageContent);
                    OnProductsQueried?.Invoke(false, null);
                    break;

                // 购买相关
                case PurchaseSuccess:
                    Debug.Log("购买成功: " + messageContent);
                    PurchaseInfo purchaseInfo = ParsePurchaseJson(messageContent);
                    OnPurchaseCompleted?.Invoke(true, purchaseInfo);
                    break;

                case PurchaseFail:
                    Debug.LogError("购买失败: " + messageContent);
                    OnPurchaseCompleted?.Invoke(false, null);
                    break;

                case PurchaseCancel:
                    Debug.Log("购买取消: " + messageContent);
                    OnPurchaseCancelled?.Invoke();
                    break;

                // 消耗相关
                case ConsumeSuccess:
                    Debug.Log("消耗成功: " + messageContent);
                    OnPurchaseConsumed?.Invoke(true, messageContent);
                    break;

                case ConsumeFail:
                    Debug.LogError("消耗失败: " + messageContent);
                    OnPurchaseConsumed?.Invoke(false, messageContent);
                    break;

                // 查询购买历史相关
                case QueryPurchasesSuccess:
                    Debug.Log("查询购买历史成功: " + messageContent);
                    List<PurchaseInfo> purchases = ParsePurchasesJson(messageContent);
                    OnPurchasesQueried?.Invoke(true, purchases);
                    break;

                case QueryPurchasesFail:
                    Debug.LogError("查询购买历史失败: " + messageContent);
                    OnPurchasesQueried?.Invoke(false, null);
                    break;

                default:
                    Debug.LogWarning("未知的消息代码: " + messageCode);
                    break;
            }
        }

        #endregion

        #region JSON解析

        /// <summary>
        /// 解析商品JSON
        /// </summary>
        private List<ProductInfo> ParseProductsJson(string json)
        {
            List<ProductInfo> products = new List<ProductInfo>();

            try
            {
                if (string.IsNullOrEmpty(json) || json == "[]")
                {
                    return products;
                }

                return Utility.Json.ToObject<List<ProductInfo>>(json);
            }
            catch (Exception e)
            {
                Debug.LogError("解析商品JSON失败: " + e.Message);
            }

            return products;
        }

        /// <summary>
        /// 解析单个购买JSON
        /// </summary>
        private PurchaseInfo ParsePurchaseJson(string json)
        {
            try
            {
                if (string.IsNullOrEmpty(json))
                {
                    return null;
                }

                return Utility.Json.ToObject<PurchaseInfo>(json);
            }
            catch (Exception e)
            {
                Debug.LogError("解析购买JSON失败: " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// 解析购买历史JSON
        /// </summary>
        private List<PurchaseInfo> ParsePurchasesJson(string json)
        {
            List<PurchaseInfo> purchases = new List<PurchaseInfo>();

            try
            {
                if (string.IsNullOrEmpty(json) || json == "[]")
                {
                    return purchases;
                }

                purchases = Utility.Json.ToObject<List<PurchaseInfo>>(json);
            }
            catch (Exception e)
            {
                Debug.LogError("解析购买历史JSON失败: " + e.Message);
            }

            return purchases;
        }

        #endregion
    }
}