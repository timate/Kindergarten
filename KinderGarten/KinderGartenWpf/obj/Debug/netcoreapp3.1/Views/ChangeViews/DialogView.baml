   M S B A M L   `   `   `  ����  KinderGarten2    ,KinderGartenWpf.Views.ChangeViews.DialogView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5   	   Q MControlzEx, Version=4.0.0.0, Culture=neutral, PublicKeyToken=69f1c32f803d307e
controlzexurn:controlzex  6?   $	��350��5   	   $	��200��5	   	     � WindowStyle$
  None=�5
   	      DialogStyle#��[  5   	    � AllowsTransparency$
 True��5   	    � Title 5   	   �� *Title+ � DataContext 5   	   �� *SingleDialogVM+  ViewModelLocator �� Source# [ '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
   *  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5      /  )ControlzEx.Behaviors.WindowChromeBehavior  5   
   .��5      �� $��10q�6   .+�5   
   ��   	HeaderOne#��[ 5      ��5      �� *Title+5      �� 5   
   y�6   �� *TextVisibility+.+�5      �� ��6   �� *Name+�� 5      ��6   �� *Text+ �� Mode$ TwoWay=�5      �� 5   
   y�6   �� *ComboVisibility+.+�5      �� $��Ученик��6   �� 5      ��6   �� *	Childrens+ �� SelectedItem 69   �� *
Children+��5       �� 5!      .R�5"      �� �� 5#      �6"   �� *Person.Lastname+ �� 5$      �6"   �� *Person.Firstname+ �� 5%      �6"   �� *Person.Middlename+5&      5'      5)      5*      �� 5,   
   $
��Ок��6   $��2��6   $	��100��6+   $��Right=�5-      $��Bottom=�5.      ��5/      �� *	OkCommand+��50      �� 	 �� RelativeSource	 �� 
 �� Mode$
 FindAncestor=� �� AncestorType" �51      52      