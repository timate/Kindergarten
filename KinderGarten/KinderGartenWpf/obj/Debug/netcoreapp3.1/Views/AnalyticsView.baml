   M S B A M L   `   `   `  ����  KinderGarten)    #KinderGartenWpf.Views.AnalyticsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  CabinetView��5       � UseLayoutRounding$
 True��5	       � DataContext 5
      �� *AnlayticsVM+   ViewModelLocator �� Source# [  .��5      � $
 True��6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   ��   	HeaderOne#��[ 6   $��Аналитика��67   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Right=�6>   $��Bottom=�6Z   .+�5      	�  d� 	IsChecked$
 TrueY�6   $%��Финансовый отчет��6+     Tab#���  6F   $��1��5      ��5      �� *ChangeTabCommand+5      	� 5      $��Посещаемость��6   #���  61   $��2��5      $��3��5      ��5   -   �� *ChangeTabCommand+5      5        � 5"   
   $��1��6   $��2��6     � NavigationUIVisibility$ Hidden=�6M   ��61   �� *	TabView+6M   5$      5&      