   M S B A M L   `   `   `  ����[  WSystem.IO.FileSystem, Version=4.1.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aC5clr-namespace:System.IO;assembly=System.IO.FileSystem	System.IO  5      G CKinderGarten, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:KinderGartenWpf.ConvertersKinderGartenWpf.Converters 6H   -   'KinderGartenWpf.Views.FinanceReportView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dio5clr-namespace:System.IO;assembly=System.IO.FileSystem     5      ?
converters(clr-namespace:KinderGartenWpf.Converters     6H   -   5        $��Finance��5        � UseLayoutRounding$
  True��5	       � DataContext 5
      �� *FinanceReportVm+   ViewModelLocator �� Source# [  .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      (  "System.Windows.Controls.DatePicker  
 � Tag$! Начало периода��6      SelectedDate 5      �� *	StartDate+  5      $ Конец периода��6    5      �� *	EndDate+�� 5      $��Показать��6   $��Bottom=�5      ��5      �� *ViewCommand+5      5      �� 5!   
   $,��&Составить отчет в Excel��6   $��Right=�5"      $��1��5#      $��Bottom=�5%      ��5$      �� *ExportCommand+5%      � 5'   
   $��0 20 0 0q�6   $��1��5(       � Orientation$ 
Horizontal=�6   $	��Top=�5)      .+�5+      ��  
 Shadow	 J� Effect#	 [ 6   
�������
 �� Padding$
 10q�6I   $	��300��6V   $��0 0 10 0q�6b   ._�5,      ��  �� TextAlignment$ Center=�6   .+�5-      �� $!��Чистая прибыль��6      	HeaderTwo#��[ 66     ForegroundBrush#��[ 5.       �� 5/      $��40(�50       $��SemiBold"�51         AccentBrush#��[ 52       ��5/       �� *Pribl+ �� StringFormat$ {0:C2}�� �� ConverterCulture$ Ru�� �� FallbackValue$ Загрузка...��52       53      54      �� 55      #	 [ 6   
�������$
 10q�6I   $	��300��6V   $��0 0 10 0q�6b   ._�56      �� $��1��6   $ Center=�57      .+�58      �� $��Общий доход��6    #��[ 63   #��[ 59       �� 5:      $��SemiBold"�5;       $��40(�5<      
����� ���5:       �� *Income+$ {0:C2}��$ Ru��$ Загрузка...��5=      5>      5?      �� 5@      #	 [ 6   
�������$
 10q�6I   $	��300��6V   $��0 0 10 0q�6b   ._�5A      �� $��2��6   $ Center=�5B      .+�5C      �� $��Общий расход��6    #��[ 64   #��[ 5D       �� 5E      $��40(�5F       $��SemiBold"�5G       
���\\����5E       �� *Cunsumption+$ {0:C2}��$ Ru��$ Загрузка...��5H       5I      5J      5K      �� 5M   
   $
 10q�6   $��1��6   $��2��6+   $	��Top=�6<   $��1��6T   
�������#	 [ 6w   $��0 20 0 0q�6�   ._�5N      �� .+�5O      �� $+��%Составленные отчеты��6   #��[ 5P      $
��Left=�5Q      #��[ 5R      �� 5S      ��6   �� *Files+ � 	Resources 5T      8  2KinderGartenWpf.Converters.FullNameToIconConverter  IconConverter �� DataType   System.IO.FileInfo �� ElementName �� 	Converter��%c  &	       (��      5V   '   *, +)7    5U      6=   �� 5V      "  6'   .R�5W      �� $	��0 5q�6�   ��6%   �� *DataContext.OpenReportCommand+$ Finance����6l   �� *
FullName+.��5X   "   �� $ 
Horizontal=�6-   .+�5Y   &   �� ��6,   �� *
FullName+8   �� 5Z   &   ��60   �� *Name+5[   #   5\      5]      5^      5_      5`      5a      �� 5c   
   $��2��6   $��0 9 10 0q�6   $	
 0 5q�60     BackgroundBrush#��[ 6>    K� ZIndex$ 1��6l   $	��Top=�6}   ._�5d      �� $ 
Horizontal=�6   $	��Top=�62   $��Right=�6J   $��0 10 0 0q�6f   .+�5f      	� $��Доходы��6     Tab#���  6/   $��1��5h       d� 	IsChecked$
 TrueY�5i      ��5g      �� *ChangeTabCommand+5i      	� 5j      $��Расходы��6   #���  60   $��1��5k      $��2��5l      ��5k   -   �� *ChangeTabCommand+5l      5m      5n       � 5p   
     � Source$ IncomeView.xaml?�6   $��10q�5q      $��-10 -10 0 0q�6   $��2��62   $	��Top=�6?   5s      5t      