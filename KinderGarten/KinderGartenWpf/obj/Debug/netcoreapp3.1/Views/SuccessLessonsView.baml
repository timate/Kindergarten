   M S B A M L   `   `   `  ����  KinderGarten.    (KinderGartenWpf.Views.SuccessLessonsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  SuccessLessonsView��5       � UseLayoutRounding$
 True��5	       � DataContext 5
      �� *SuccessLessonsVM+   ViewModelLocator �� Source# [  .��5      �� $
 True��6   .+�5   
   � .+�5      ��  �� Orientation$ 
Horizontal=�6   $��5q�62   $��Bottom=�6=   .+�5      �� 
 � Tag$ 
Поиск��6   $	��150��6&   ��62   �� *Search+ �� Mode$ TwoWay=�(  "System.Windows.Controls.DatePicker  5      $! Начало периода��6   $	��150��6^      SelectedDate 62   �� *Start+$ TwoWay=�6^     5      $ Конец периода��6   $	��150��6[    61   �� *End+$ TwoWay=�6[   �� 5      $��Показать��6   $��Bottom=�6,   ��5      �� *ViewCommand+5      �� 5       �� Padding$ 5q�6   
�������$
��5 10q�6=   	 �� CornerRadius$	 4��6K   $��Right=�6\   $��Bottom=�6x   ._�5      �� $����Занятие считается проведенным, если для него заполнен журнал посещении.��6   $��SemiBold"�5        ForegroundBrush#��[ 6*   5      5      �� 5   
   $ 10q�6   $��5q�6   
������� 
 Shadow
 J� Effect#
 [ 6<   ._�5   
   ��  � 	Resources 5         VisibilityConventer��%   &	       �� 5!      63   5"      .+�5#      �� ��6   �� *SuccessLessons+ �� View 5$      �� 5%      P�5&      �� 5'   "   $��Занятие��61    �� Width$	 100��6t    �� DisplayMemberBinding 6B   ��  �� Path$ Lesson.Name�6t   �� 5(   "   $��Группа��61   $	 100��6y    6A   �� $ Lesson.Group.Name�6y   �� 5)   "   $��Дата��61   $	 100��6�    6?   �� $
 Date� �� StringFormat$ {0:d MMMM yyyy}�� �� ConverterCulture$ Ru��6�   5+      5-      �� 5.      $��0 100q�6   y�6,   �� *EmptyVisibility+ �� 	Converter# [ .+�5/      �� $!��/Assets/Images/NotFound.png��6   $��Uniform=�6A   $	��150��6S   $	��150��6_   �� 50      $?��9Проведенных занятий не найдено��6    $��Center=�51      $��Center=�52        	HeaderTwo#��[ 53      $��SemiBold"�54      #��[ 55      56      57      58      59      5:      