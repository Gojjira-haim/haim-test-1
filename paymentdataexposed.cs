
#nullable disable

using Microsoft.AspNetCore.Mvc;

namespace Examples.GovernanceRuleExamples;

/// <summary>
/// Example that triggers the governance rule:
/// "Sensitive data of type Payments data is exposed by an API"
///
/// LIM flags this because:
/// 1. PaymentInfoResponse has payment-related fields (CardNumber, CardExpiry, etc.)
///    that the Predictor classifies as PaymentFields.
/// 2. GetPaymentInfo returns that type, so the API is linked as "exposing" that data.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PaymentExampleController : ControllerBase
{
    [HttpGet("payment/{id}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult<PaymentInfoResponse> GetPaymentInfo(string id)
    {
        return Ok(new PaymentInfoResponse
        {
            TransactionId = "tx-001",
            OrderId = 12345,
            Amount = 99.99,
            PaidOn = "2025-03-15",
            CardNumber = "************4242",
            CardOwnerName = "Jane Doe",
            CardType = "Visa",
            CardExpiry = "12/2027",
            Currency = "USD"
        });
    }
}

public class PaymentInfoResponse
{
    public string TransactionId { get; set; }
    public long OrderId { get; set; }
    public double Amount { get; set; }
    public string PaidOn { get; set; }
    public string CardNumber { get; set; }
    public string CardOwnerName { get; set; }
    public string CardType { get; set; }
    public string CardExpiry { get; set; }
    public string Currency { get; set; }
}
