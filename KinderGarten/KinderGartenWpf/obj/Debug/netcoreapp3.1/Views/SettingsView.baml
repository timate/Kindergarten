   M S B A M L   `   `   `  ����  KinderGarten(    "KinderGartenWpf.Views.SettingsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  CabinetView��5       � UseLayoutRounding$
 True��5	       � DataContext 5
      �� *
SettingsVM+   ViewModelLocator �� Source# [  .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��Настройки��6     	HeaderOne#��[ 6%   $��5q�6H   �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��Bottom=�6J   $��1��6e   .+�5      	� $��Основные��6     Tab#���  6-   $��1��5       d� 	IsChecked$
 TrueY�5      ��5      �� *ChangeTabCommand+5      	� 5      $��Абонементы��6   #���  6/   $��2��5!      ��5       �� *ChangeTabCommand+5!      	� 5"      $��Группы��6   #���  6+   $��3��5$      ��5#      �� *ChangeTabCommand+5$      5%       � 5'   
   $��1��6,   $��2��69   $��0 10 0 0q�6M   $
��True��6_     � NavigationUIVisibility$ Hidden=�6�   ��6   �� *	TabView+6�   5)      5+      