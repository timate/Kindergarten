using GalaSoft.MvvmLight;
using System;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenWpf.Models.Objects
{
    public class Transaction : ViewModelBase
    {
        [Key]
        public int Id { get; set; }
        public Person Person { get; set; } // Сделка с компанией / человеком
        public decimal Amount { get; set; } // Cумма
        public DateTime DateProcess { get; set; } // Дата сделки
        public bool Payment { get; set; } //Оплачено, не оплачено
        public string Comment { get; set; } // Описание
        public bool Type { get; set; } // Доход или расход
        public PaymentMethod PaymentMethod { get; set; } // Метод оплаты
    }
}
