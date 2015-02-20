﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atomia.Store.Core
{
    public class OrderContext
    {
        private readonly Cart cart;
        private readonly IEnumerable<ContactData> contactData;
        private readonly PaymentData paymentData;
        private readonly IEnumerable<object> extraData;

        public OrderContext(Cart cart, IContactDataCollection contactDataCollection, PaymentData paymentData, IEnumerable<object> extraData)
        {
            if (cart == null)
            {
                throw new ArgumentNullException("cart");
            }

            if (contactDataCollection == null)
            {
                throw new ArgumentNullException("contactDataCollection");
            }

            if (paymentData == null)
            {
                throw new ArgumentNullException("paymentData");
            }

            this.cart = cart;
            this.contactData = contactDataCollection.GetContactData();
            this.paymentData = paymentData;
            this.extraData = extraData;
        }

        public Cart Cart
        {
            get 
            { 
                return cart; 
            }
        }

        public IEnumerable<ContactData> ContactData
        {
            get
            {
                return contactData;
            }
        }

        public PaymentData PaymentData
        {
            get
            {
                return paymentData;
            }
        }

        public IEnumerable<object> ExtraData
        {
            get
            {
                return extraData;
            }
        }
    }
}