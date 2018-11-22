namespace Stripe
{
    using System;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class AccountRequirements : StripeEntity
    {
        [JsonProperty("current_deadline")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CurrentDeadline { get; set; }

        [JsonProperty("currently_due")]
        public string[] CurrentlyDue { get; set; }

        [JsonProperty("disabled_reason")]
        public string DisabledReason { get; set; }

        [JsonProperty("eventually_due")]
        public string[] EventuallyDue { get; set; }

        [JsonProperty("past_due")]
        public string[] PastDue { get; set; }
    }
}
