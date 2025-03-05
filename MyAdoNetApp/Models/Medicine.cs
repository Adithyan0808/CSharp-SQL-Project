using MyAdoNetAPP;
using System;

namespace Models.Medicine
{
    public class Medicine
    {
        public int MedID {get; set;}
        public string MedName {get; set;}
        public string Manufacturer {get; set;}
        public string BatchNumber {get; set;}
        public string ExpiryDate {get; set;}
        public int Quantity {get; set;}
        public decimal UnitPrice {get; set;}
        public decimal TotalPrice => UnitPrice * Quantity;


        public Medicine()
        {

        }


        public Medicine(string medName,string manufacturer,
                        string batchNumber,string expiryDate,int quantity,
                        decimal unitPrice)
        {
            MedName = medName;
            Manufacturer = manufacturer;
            BatchNumber = batchNumber;
            ExpiryDate = expiryDate;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }





    }
}





