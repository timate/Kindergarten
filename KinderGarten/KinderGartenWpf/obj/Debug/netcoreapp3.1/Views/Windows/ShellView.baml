   M S B A M L   `   `   `  ����  KinderGarten%    KinderGartenWpf.Views.ShellView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5   	   Q MControlzEx, Version=4.0.0.0, Culture=neutral, PublicKeyToken=69f1c32f803d307e
controlzexurn:controlzex  5   	     � Title$  Ласточка��5	   	   $	��600��5
   	   $	��800��5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	      WindowStyle#��[  5   	    � UseLayoutRounding$
 True��5   	   ��5   	   �� *WindowWidth+ �� Mode$ TwoWay=� � 
ResizeMode 5   	   �� *WindowResize+$ TwoWay=� � WindowState 5   	   �� *WindowState+$ TwoWay=�y�5   	   �� *WindowVisible+$ TwoWay=� � DataContext 5   	   �� *	ShellVM+  ViewModelLocator �� Source# [ '  !System.Windows.Shell.WindowChrome	   WindowChrome	 5        5   
   
   CaptionHeight$
 25Q�6   *  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5      /  )ControlzEx.Behaviors.WindowChromeBehavior  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5!   
   �� $��1��6   $
��True��6'   ! �� IsDeferredScrollingEnabled$
 True��6?   $
��Auto=�6a   .��5"       � -   5        $��	MainFrame��5"   �   $
��True��6     � Source$ ../CabinetView.xaml?�69   $��Visible=�6V     � NavigationUIVisibility$ Hidden=�6�   $��10q�6�   5#      5$      5%      