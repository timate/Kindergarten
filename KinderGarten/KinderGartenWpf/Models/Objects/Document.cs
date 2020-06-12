using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenWpf.Models.Objects
{
    public class Document : ViewModelBase
    {
        [Key]
        public int Id { get; set; }
        public bool Type { get; set; } //Тип документа: 1-паспорт, 0-другое
        [MaxLength(50)]
        public string Number { get; set; } //Номер документа
        [MaxLength(100)]
        public string Information { get; set; } //Информация
        public string Comment { get; set; } //Комментарии

    }
}
