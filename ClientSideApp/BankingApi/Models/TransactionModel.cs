﻿using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class TransactionModel
    {
        [Required(ErrorMessage = "Customer Name cannot be null.")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "TypeOfTransaction cannot be null.")]
        public string? TypeOfTransaction { get; set; }

        [Required(ErrorMessage = "AccountIBAN cannot be null.")]
        public string? AccountIBAN { get; set; }

        [Required(ErrorMessage = "Ammount cannot be null or 0.")]
        public int? Amount { get; set; }

        [Required(ErrorMessage = "Recipient Name cannot be null.")]
        public string? Recipient { get; set; }
    }
}
