   M S B A M L   `   `   `  ����  KinderGartenF    @KinderGartenWpf.Views.ChangeViews.SubscriptionTemplateChangeView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5   	   Q MControlzEx, Version=4.0.0.0, Culture=neutral, PublicKeyToken=69f1c32f803d307e
controlzexurn:controlzex  6?     � AllowsTransparency$
  True��5   
    � WindowStyle$
 None=�5	         DialogStyle#��[  5      $	��350��5      $	��500��5       � WindowStartupLocation$ CenterScreen=�5   Z    � Title 5
   	   �� *Title+ � DataContext 5      �� *TemplateChangeVM+  ViewModelLocator �� Source# [ '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
   *  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5      /  )ControlzEx.Behaviors.WindowChromeBehavior  5   
   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $
��Auto=�6   .��5      �� $��Center=�6   $��10q�64   .+�5      ��   	HeaderOne#��[ 63   ��6   �� *Title+63   �� 5      -   5        
	 � Tag$	 Название��5      $��5 0 5 5q�6M   ��6*   �� *Subscription.Name+5       �� 5!      $	 Воспитатель��6   $��5 0 5 5q�6~   ��6-   �� *	Employees+
 �� SelectedItem
 6O   �� *Subscription.Employee+��5"      �� 5#      .R�5$      �� �� 5%   &   �6*   �� *	Role.Name+ �� StringFormat$
 {0}:�� �� 5&   &   �6*   �� *Person.Lastname+ �� 5'   &   �6*   �� *Person.Firstname+ �� 5(   &   �6*   �� *Person.Middlename+5)   #   5*      5,      (  "System.Windows.Controls.DatePicker  5-      $	 Действует с��6      SelectedDate 6/   �� *Subscription.Start+  5.      $	 Действует до��6    60   �� *Subscription.End+�� 5/      $%	 Количество часов��6   ��61   �� *Subscription.HoursCount+�� 50      $	 Стоимость��6   ��6*   �� *Subscription.Amount+52      53      �� 54   
   $��1��6    
 Shadow J� Effect# [ 6     BackgroundBrush#��[ 6?   ._�55      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�56      �� $��Добавить��6   y�57      �� *AddVisibility+��58      �� *
AddCommand+��59      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" ��� 5:      $��Изменить��6   y�5;      �� *ChangeVisibility+��5<      �� *ChangeCommand+��5=      ��  �� $ FindAncestor=�" ��� 5>      $��Удалить��6   y�5?      �� *ChangeVisibility+��5@      �� *RemoveCommand+��5A      ��  �� $ FindAncestor=�" �5B      5C      5D      5E      