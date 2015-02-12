﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atomia.Store.PublicBillingApi.Ports;
using Atomia.Web.Plugin.OrderServiceReferences.AtomiaBillingPublicService;
using Atomia.Store.Core;

namespace Atomia.Store.Payment.DibsFlexwin
{
    public class DibsFlexwinHandler : PaymentMethodHandler
    {
        private readonly PaymentUrlProvider urlProvider;

        public DibsFlexwinHandler(PaymentUrlProvider urlProvider)
        {
            if (urlProvider == null)
            {
                throw new ArgumentNullException("urlProvider");
            }

            this.urlProvider = urlProvider;
        }

        public override string Id
        {
            get { return "DibsFlexwin"; }
        }

        public override PaymentMethodEnum PaymentMethodType
        {
            get { return PaymentMethodEnum.PayByCard; }
        }

        public override void AmendTransaction(PublicPaymentTransaction transaction, List<AttributeData> attributes)
        {
            transaction.ReturnUrl = urlProvider.PaymentRedirectUrl;
            transaction.Attributes.First(item => item.Name == "CancelUrl").Value = urlProvider.CancelUrl;
        }
    }
}