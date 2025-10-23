using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.Payment.Google.Runtime
{
    [Preserve]
    public class GameFrameXGooglePaymentCroppingHelper : MonoBehaviour
    {
        [Preserve]
        void Start()
        {
            _ = typeof(GooglePaymentManager);
            _ = typeof(GooglePlayBilling);
            _ = typeof(PricingPhase);
            _ = typeof(ProductInfo);
            _ = typeof(PurchaseInfo);
            _ = typeof(SubscriptionOffer);
        }
    }
}