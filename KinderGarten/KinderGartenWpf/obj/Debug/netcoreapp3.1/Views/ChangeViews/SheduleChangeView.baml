   M S B A M L   `   `   `  ����G  CKinderGarten, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:KinderGartenWpf.ConvertersKinderGartenWpf.Converters  5   a   4    .KinderGartenWpf.Views.Dialog.SheduleChangeView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5   	   Q MControlzEx, Version=4.0.0.0, Culture=neutral, PublicKeyToken=69f1c32f803d307e
controlzexurn:controlzex  6?   9
converters(clr-namespace:KinderGartenWpf.Converters  6a     � AllowsTransparency$
  True��5   
    � WindowStyle$
 None=�5	         DialogStyle#��[  5
      $	��350��5      $	��600��5       � WindowStartupLocation$ CenterScreen=�5   Y    � Title 5   	   �� *Title+ � DataContext 5      �� *SheduleChangeVM+  ViewModelLocator �� Source# [ '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
   *  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5      /  )ControlzEx.Behaviors.WindowChromeBehavior  5   
   .��5      � $��0 25 0 0q�6    � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $
��Auto=�6   .��5      �� $��Center=�6   $��10q�64   .+�5      ��   	HeaderOne#��[ 63   ��6   �� *Title+63   �� 5      $��
Общее��6     	HeaderTwo#��[ 6)   �� 5!      .+�5"      �� $��Тип: ��6    $��5 5 5 5q�6-   �� 5#      	 �� Orientation$	 
Horizontal=�6!   .+�5$      	� 
 d� 	IsChecked$

 TrueY�6&   $��Обязательный��67   $��5q�6N   	� 5%      $"��Дополнительный��6S   $��5q�6l   
 6&   �� *	DopLesson+ �� Mode$ TwoWay=�6l   5&      5'      �� 5)      -   5        
 � Tag$ Название��5)      ��6-   �� *Lesson.Name+y�5*      �� *EmployeeVisibility+5+      �� 5-      $ Педагог��6   $��5 0 5 5q�6�   y�6-   �� *EmployeeVisibility+��6W   �� *	Employees+ �� SelectedItem 6y   �� *Lesson.Employee+��5.      �� 5/      .R�50   "   �� �� 51   &   �6*   �� *Person.Lastname+ �� 52   &   �6*   �� *Person.Firstname+ �� 53   &   �6*   �� *Person.Middlename+54   #   55      57      �� 59      $ Группа��6    �� DisplayMemberPath$
 Name��5;      ��5:      �� *Groups+ 5<      �� *Lesson.Group+�� 5>      $ Помещение��6   $
 Name��5@      ��5?      �� *Rooms+ 5A      �� *Lesson.Room+�� 5C      $ Абонеменет��6   $
 Name��5E      ��5D      �� *Subscriptions+ 5F      �� *Lesson.Tariff+y�5G      �� *SubscriptionsVisibility+�� 5I      $��
Время��6   #��[ 6)   �� 5K       � 	Resources 5L      -   'KinderGartenWpf.Converters.DayConventer  	conventer��%   &	         5M      62   5N      .+�5O      �� $ День недели��6    �� Text$ День недели��61    �� SelectedIndex 5P      �� *Lesson.DayOfWeek+$ TwoWay=� �� 	Converter# [ .@�5Q      �� .��6'   Понедельник64   �� 5R      .��6'   Вторник60   �� 5S      .��6'   
Среда6.   �� 5T      .��6'   Четверг60   �� 5U      .��6'   Пятница60   �� 5V      .��6'   Суббота60   5W      (  "System.Windows.Controls.DatePicker  5Y      $ В период с��6!      SelectedDate 62   �� *Lesson.DateStart+y�5Z   !   �� *EmployeeVisibility+  5[      $
 по��6!    6*   �� *Lesson.DateEnd+y�5\   !   �� *EmployeeVisibility+5^      �� 5`      -   5        $ Номер занятия��5`       �� 	MaxLength$ 1��5a   <   ��5`   2   �� *Lesson.LessonNumber+5a   <   5b      5c      �� 5d   
   $��1��6    
 Shadow J� Effect# [ 6     BackgroundBrush#��[ 6?   ._�5e      �� $	 
Horizontal=�6   $��Center=�62   .+�5f      �� $��Добавить��6   y�5g      �� *AddVisibility+��5h      �� *
AddCommand+��5i      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" ��� 5j      $��Изменить��6   y�5k      �� *ChangeVisibility+��5l      �� *ChangeCommand+��5m      ��  �� $ FindAncestor=�" ��� 5n      $��Удалить��6   y�5o      �� *ChangeVisibility+��5p      �� *RemoveCommand+��5q      ��  �� $ FindAncestor=�" �5r      5s      5t      5u      