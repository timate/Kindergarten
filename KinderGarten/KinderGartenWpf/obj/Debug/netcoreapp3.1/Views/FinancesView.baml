   M S B A M L   `   `   `  ����  KinderGarten(    "KinderGartenWpf.Views.FinancesView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  CabinetView��5       � UseLayoutRounding$
 True��5	       � DataContext 5
      �� *
FinancesVM+   ViewModelLocator �� Source# [  .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��Финансы��6     	HeaderOne#��[ 5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��1��6J   $��Bottom=�6Z   .+�5      	� $��Доходы��6     Tab#���  6+   $��1��5        d� 	IsChecked$
 TrueY�5!      ��5      �� *ChangeTabCommand+5!      	� 5"      $��Расходы��6   #���  6,   $��1��5#      $��2��5$      ��5#   *   �� *ChangeTabCommand+5$      5%       � 5'   
     � NavigationUIVisibility$ Hidden=�6,   $��1��6L   $��2��6Y   ��6   �� *	TabView+6Y   5(      5*      