using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Mydatas
{
    #region a
    public class product 
    {
        public string name;
        public int price;
        public string photo;
        public int number = 0;
        // public string isAvailable = "Available";
    }

    public static class cart
    {
        public static List<product> products_list = new List<product>();
        public static int sum_value = 0;
    }
    public static class Fcart
    {
        public static int MJ = 0;public static int WJ = 0;public static int MT = 0;public static int WT = 0;
        public static int MS = 0;public static int WS = 0;public static int MJA = 0;public static int WJA = 0;public static int sum_value = 0;
    }

    public class User  
    {  
        [Required]  
        [StringLength(50)]  
        public string FirstName { get; set; }  
        [Required]  
        [StringLength(50)]  
        public string LastName { get; set; }  
        // [Required]  
        [EmailAddress]  
        public string EmailAddress { get; set; }  
        [Required]  
        [Phone]  
        public string PhoneNumber { get; set; }  
        [Required]  
        [CreditCard]  
        public string CreditCardNumber { get; set; }  
        [Required]
        public string Address;
    }  
    #endregion

}