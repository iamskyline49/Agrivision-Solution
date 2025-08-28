using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriProject
{
    internal class Item
    {
        // Fields
        private string itemId;
        private string itemType;
        private double itemQuantity;
        private double itemPrice;
        private byte[] picture;
        private string description;
        private string deliveryOption;
        private string itemStatus;

        // Constructor
        public Item(string itemId, string itemType, double itemQuantity, double itemPrice, byte[] picture, string description, string deliveryOption, string itemStatus)
        {
            this.ItemId = itemId;
            this.ItemType = itemType;
            this.ItemQuantity = itemQuantity;
            this.ItemPrice = itemPrice;
            this.Picture = picture;
            this.Description = description;
            this.DeliveryOption = deliveryOption;
            this.ItemStatus = itemStatus;
        }

        // Properties
        public string ItemId
        {
            get { return itemId; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ItemId cannot be null or empty.");
                itemId = value;
            }
        }

        public string ItemType
        {
            get { return itemType; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ItemType cannot be null or empty.");
                itemType = value;
            }
        }

        public double ItemQuantity
        {
            get { return itemQuantity; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("ItemQuantity must be greater than zero.");
                itemQuantity = value;
            }
        }

        public double ItemPrice
        {
            get { return itemPrice; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("ItemPrice must be greater than zero.");
                itemPrice = value;
            }
        }

        public byte[] Picture
        {
            get { return picture; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentNullException("Picture cannot be null or empty.");
                picture = value;
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Description cannot be null or empty.");
                description = value;
            }
        }

        public string DeliveryOption
        {
            get { return deliveryOption; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("DeliveryOption cannot be null or empty.");
                deliveryOption = value;
            }
        }

        public string ItemStatus
        {
            get { return itemStatus; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ItemStatus cannot be null or empty.");
                itemStatus = value;
            }
        }

     
    }
}
