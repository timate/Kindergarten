   M S B A M L   `   `   `  ����  KinderGarten$    KinderGartenWpf.Views.MainView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � UseLayoutRounding$
  True��5       N� Title$ MainView��5	       � DataContext 5
      �� *MainVM+   ViewModelLocator �� Source# [  .��5      �� $
  True��6    � 	Resources 5   
     VisibilityConverter��%   &	       �� 5      6+   5      .+�5   
   �� $��Главная��6     	HeaderOne#��[ 6#     ForegroundBrush#��[ 5      $��SemiBold"�5      � 5   
    � Orientation$ 
Horizontal=�6   .+�5      �� $��5q�6   y�6$   �� *FinancesVisibility+ �� 	Converter# [ .+�5      ��   	HeaderTwo#��[ 6   #��[ 6?   $7��1Финансы за последний месяц��5      $��SemiBold"�5      � 5      $��0 0 0 0q�6   .+�5      ��  
 Shadow J� Effect# [ 6   
�������$	��300��6Q    �� Padding$ 10q�6`   $��5q�6m   ._�5      �� 	 �� TextAlignment$	 Center=�6%   .+�5      �� $!��Чистая прибыль��6(   #��[ 6>   #��[ 5       �� 5       $��40(�5!       $��SemiBold"�5"         AccentBrush#��[ 5#       ��5    (   �� *Pribl+
 �� StringFormat$
 {0:C2}�� �� ConverterCulture$ Ru�� �� FallbackValue$ Загрузка...��5#       5$      5%      �� 5&      # [ 6   
�������$	��300��6Q   $ 10q�6`   $��5q�6m   ._�5'      �� $��1��6%   $	 Center=�5(   !   .+�5)      �� $��Общий доход��6(   #��[ 6;   #��[ 5*   $   �� 5+      $��SemiBold"�5,   $   $��40(�5-   !   
����� ���5+   (   �� *Income+$
 {0:C2}��$ Ru��$ Загрузка...��5.   !   5/      50      �� 51      # [ 6   
�������$	��300��6Q   $ 10q�6`   $��5q�6m   ._�52      �� $��2��6%   $	 Center=�53   !   .+�54      �� $��Общий расход��6(   #��[ 6<   #��[ 55   $   �� 56      $��40(�57   $   $��SemiBold"�58   $   
���\\����56   (   �� *Cunsumption+$
 {0:C2}��$ Ru��$ Загрузка...��59   $   5:      5;      5<      5=      �� 5?      $��5q�6   y�6$   �� *BirthDayVisibility+# [ .+�5@      �� #��[ 6   $H��BБлижайшие дни рождения вашей группы��5A      #��[ 5B      $��SemiBold"�5C      �� 5D      # [ 6   
�������$ 10q�6M   $��5q�6Z   ._�5E      �� .+�5F      �� ��6#   �� *	Childrens+ �� View 5G      �� 5H   "   .P�5I   &   �� $��ФИО��65    �� DisplayMemberBinding 5J   *   `� 5K   .   $
 {0} {1}. {2}.��6;   .1�5L   2   ��  �� Path$ Person.Lastname�6:   �� 5M   2   $ Person.Firstname[0]�6:   �� 5N   2   $ Person.Middlename[0]�6:   5O   /   5Q   '   �� 5R   &   $��Дата��65    6C   �� *Person.BirthDay+$
 {0:d MMMM yyyy}��$ Ru��5S   #   5U      5V      5W      5X      �� 5Z      $��5q�6   y�6$   �� *LessonsVisibility+# [ .+�5[      �� #��[ 6   $0��*Ваши ближайшие занятия��5\      #��[ 5]      $��SemiBold"�5^      �� 5`      # [ 6   
�������$ 10q�6M   $��5q�6Z   ._�5a      �� 5b      5c      5d      �� 5f      $��5q�6   y�6$   �� *GroupLessonsVisibility+# [ .+�5g      �� #��[ 6   $?��9Ближайшие занятия вашей группы��5h      #��[ 5i      $��SemiBold"�5j      �� 5k      # [ 6   
�������$ 10q�6M   $��5q�6Z   ._�5l      �� 5m      5n      5o      5q      5s      5t      