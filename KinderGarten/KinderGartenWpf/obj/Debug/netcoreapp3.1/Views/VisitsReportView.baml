   M S B A M L   `   `   `  ����G  CKinderGarten, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:KinderGartenWpf.ViewsKinderGartenWpf.Views  5      G(clr-namespace:KinderGartenWpf.ConvertersKinderGartenWpf.Converters  69   [ WSystem.IO.FileSystem, Version=4.1.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aC5clr-namespace:System.IO;assembly=System.IO.FileSystem	System.IO 6u   ,    &KinderGartenWpf.Views.VisitsReportView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:KinderGartenWpf.Views     5      ?
converters(clr-namespace:KinderGartenWpf.Converters     69   Dio5clr-namespace:System.IO;assembly=System.IO.FileSystem     6u   -   5        $��	VistisRep��5
        N� Title$  VisitsReportView��5	       � DataContext 5      �� *VisitsReportVM+   ViewModelLocator �� Source# [  .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      (  "System.Windows.Controls.DatePicker  
 � Tag$! Начало периода��6      SelectedDate 5      �� *Start+  5      $ Конец периода��6    5      �� *End+�� 5      $ Группа��6    �� DisplayMemberPath$
 Name��5      ��5   $   �� *Groups+	 �� SelectedItem	 5      �� *SelectedGroup+5      �� 5       $��Показать��6   $��Bottom=�5"      ��5!      �� *ViewCommand+5"      5#      �� 5%   
   $,��&Составить отчет в Excel��6   $��Right=�5&      $��1��5'      $��Bottom=�5)      ��5(      �� *ExportCommand+5)      �� 5+   
   
 �� Padding$
 10q�6   $��1��6   $��2��6+   $	��Top=�6<   $��1��6T   
������� 
 Shadow J� Effect# [ 6w   $��0 20 0 0q�6�   ._�5,      �� .+�5-      �� $+��%Составленные отчеты��6     	HeaderTwo#��[ 5.      $
��Left=�5/        ForegroundBrush#��[ 50      �� 51      ��6   �� *Files+ � 	Resources 52      8   2KinderGartenWpf.Converters.FullNameToIconConverter  IconConverter �� DataType  System.IO.FileInfo �� ElementName �� 	Converter��%e  &	       (��      54   '   *, +)7    53      6=   �� 54      "  6'   .R�55      �� $	��0 5q�6�   ��6%   �� *DataContext.OpenReportCommand+$ 	VistisRep����6n   �� *
FullName+.��56   "   �� $ 
Horizontal=�6-   .+�57   &   �� ��6,   �� *
FullName+8   �� 58   &   ��60   �� *Name+59   #   5:      5;      5<      5=      5>      5?      �� 5A   
   $��1��62   
�������# [ 6R   $��10q�6s   $��	5 20 10 5q�6�   ��6   �� *Visits+ �� View 5B      �� 5C      .P�5D      �� $��Фамилия��6%    �� DisplayMemberBinding 66   �� *
Lastname+�� 5E      $��Имя��6%    62   �� *	Firstname+�� 5F      $��Отчество��6%    67   �� *
Middlename+�� 5G      $��Статус��6%    65   �� *Status+�� 5H      $��Количество��6%    69   �� *CountUnvisit+5I      5K      5M      5N      