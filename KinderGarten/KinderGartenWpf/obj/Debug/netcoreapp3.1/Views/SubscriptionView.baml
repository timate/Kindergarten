   M S B A M L   `   `   `  ����  KinderGarten,    &KinderGartenWpf.Views.SubscriptionView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  SubscriptionView��5       � UseLayoutRounding$
 True��5	       � DataContext 5
      �� *SubscriptionVM+   ViewModelLocator �� Source# [  .��5      �  � 	Resources 5   
     VisibilityConverter��%   &	       �� 5      6+   5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $)��#Оформить абонимент��6   $��Right=�5      ��5      �� *
AddCommand+y�5      �� *AddVisibility+ �� 	Converter# [ �� 5   
    �� Padding$ 10q�6    
 Shadow J� Effect# [ 6   
�������$��1��6R   ._�5   
   �� .+�5      �� $��5q�6   
���������6"   �� *Subscriptions+	 �� View	 5      �� 5      .P�5      �� $��Название��6)   
 �� Width$	
 200��6;    �� DisplayMemberBinding 5    )   �� *Subscription.Name+�� 5!      $$��Стоимость за час��6)   $	
 130��6C    5"   )   �� *Subscription.Amount+ �� StringFormat$ {0:C2}�� �� ConverterCulture$ Ru-ru���� 5#      $��Действует с��6)   $	
 130��6>    5$   )   �� *Subscription.Start+$ {0: d MMMM yyyy} года��$ RU-ru���� 5%      $��Действует до��6)   $	
 130��6?    5&   )   �� *Subscription.End+$ {0: d MMMM yyyy} года��$ RU-ru��5'      5)      �� 5*      $��0 100q�6   y�6(   �� *GridEmptyVisibility+# [ .+�5+      �� $!��/Assets/Images/NotFound.png��6   $��Uniform=�6=   $	��150��6O   $	��150��6[   �� 5,      $R��LРанее оформленные абонементов не найдено��6   $��Center=�5-      $��Center=�5.        	HeaderTwo#��[ 5/      $��SemiBold"�50        ForegroundBrush#��[ 51      52      53      54      55      56      