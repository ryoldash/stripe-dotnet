namespace Stripe
{
    using System;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class AccountBusinessProfile : StripeEntity
    {
        #region Expandable Logo
        public string LogoFileId { get; set; }

        [JsonIgnore]
        public File Logo { get; set; }

        [JsonProperty("logo")]
        internal object BusinessLogo
        {
            set
            {
                StringOrObject<File>.Map(value, s => this.LogoFileId = s, o => this.Logo = o);
            }
        }
        #endregion

        [JsonProperty("mcc")]
        public string Mcc { get; set; }

        [JsonProperty("name")]
        public string[] Name { get; set; }

        [JsonProperty("product_description")]
        public string[] ProductDescription { get; set; }

        [JsonProperty("support_address")]
        public Address SupportAddress { get; set; }

        [JsonProperty("support_email")]
        public string SupportEmail { get; set; }

        [JsonProperty("support_phone")]
        public string SupportPhone { get; set; }

        [JsonProperty("support_url")]
        public string SupportUrl { get; set; }

        [JsonProperty("url")]
        public string[] Url { get; set; }
    }
}
