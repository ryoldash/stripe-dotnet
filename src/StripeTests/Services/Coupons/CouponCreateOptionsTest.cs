namespace StripeTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Stripe;
    using Stripe.Infrastructure;
    using Xunit;

    public class CouponCreateOptionsTest : BaseStripeTest
    {
        private CouponService service;

        public CouponCreateOptionsTest()
        {
            this.service = new CouponService();
        }

        [Fact]
        public void Serialize()
        {
            var options = new CouponCreateOptions
            {
                PercentOff = 25,
                Duration = "forever",
            };

            var url = this.service.ApplyAllParameters(options, string.Empty, false);
            Assert.Equal("?percent_off=25&duration=forever", url);
        }
    }
}
