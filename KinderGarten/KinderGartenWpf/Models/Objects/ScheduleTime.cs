using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenWpf.Models.Objects
{
    public class ScheduleTime : ViewModelBase
    {
        [Key]
        public int Id { get; set; }
        //Длительность занятии 45
        [MaxLength(2, ErrorMessage = "Hi")]
        public byte LessonDuration { get; set; }
        //Длительность перемен 10
        public byte TurnDuration { get; set; }
        //Длительность обеда 50
        public byte DinnerDuration { get; set; }
        //Обед после n-го занятия 2
        public byte DinnerAfter { get; set; }
        //Послеобеденная перемена 20
        public byte AfterDinnerTurnDuration { get; set; }
        //Время начала рабочего дня 8
        public byte WorkingHourStart { get; set; }
        //Время конца рабочего дня 18
        public byte WorkingHourEnd { get; set; }


        // 8:00-8:45 Начало рабочего дня:00 - x + Длительность занятия
        // 8:55-9:40 + Длительность перемены - x + Длительность занятия
        // 10:30-11:15 if(Обед после занятия) то + Длительность обеда - x + Длительность занятия
        // 11:35-12:20 if(Обед после занятия+1) то + Длительность послеобеденной перемены - x + Длительность занятия
        // 12:30-13:15 + Длительность перемены - x + Длительность занятия
        // 13:25-14:05 + Длительность перемены - x + Длительность занятия
    }
}
