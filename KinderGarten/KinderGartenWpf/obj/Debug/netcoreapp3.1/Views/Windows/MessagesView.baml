   M S B A M L   `   `   `  ����  KinderGarten0    *KinderGartenWpf.Views.Windows.MessagesView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Уведомление��5   	   $	��100��5   	   $	��250��6   $	��115��6)   $	��300��66   
������ $��0q�5
   	    � AllowsTransparency$
 True��5   	    � WindowStyle$
 None=�5   	    � ShowInTaskbar$ False��5   	    � Topmost$
 True��5   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
   .��5      �� -   5        $��Message��5   %   $��10q�6    �� Padding$ 5q�6   
����iA� � UseLayoutRounding$
 True��5   $   ._�5   
   � 
������  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      	 � ColumnDefinitions	 5      �� 5      �� 5      $
��Auto �6#   .+�5      �� $��Уведомление��6   $��14(�6+   ��5      �� *
Foreground+
 �� ElementName$
 Content���� 5      -   5        $��Content��5      $
��Wrap=�6'   $��1��6;   $��14(�5"      ��5       �� *Message.Foreground1+ �� FallbackValue$ 
GhostWhite����5!      �� *Message.Content+$ Уведомление��5"      �� 5#      -   5        $��Close��5#      $��1��6"   
�������   ControlButtons#��[  5$   (   $��0q�5%      $��0q�6)   $��4q�64   $��21��6@   $	��✕��5&      $��14(�6=   5'      5(      5)      