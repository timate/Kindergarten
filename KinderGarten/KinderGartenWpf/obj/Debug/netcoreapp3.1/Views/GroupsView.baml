   M S B A M L   `   `   `  ����  KinderGarten&     KinderGartenWpf.Views.GroupsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5        N� Title$  
GroupsView��5	       � UseLayoutRounding$
 True��5
       � DataContext 5      �� *
GroupsVM+   ViewModelLocator �� Source# [  .��5      ��  � 	Resources 5   
     VisibilityConverter��%   &	       �� 5      6+   5      .+�5   
   �� $��1��6    �� Orientation$ 
Horizontal=�6%   $��Right=�6>   .+�5      �� $��5 20 5 5q�6   $��Изменить��6'   y�5      �� *ChangeBtnVisibility+ �� 	Converter# [  �� FallbackValue$ 	Collapsed����5      �� *RemoveCommand+�� 5      $��5 20 5 5q�6   $��Изменить��6'   y�5      �� *ChangeBtnVisibility+# [ $ 	Collapsed����5      �� *ChangeCommand+�� 5      $��5 20 5 5q�6   $��Добавить��6'   ��5      �� *
AddCommand+5      �� 5   
   $��5q�6    
 Shadow J� Effect# [ 6   
�������$
 True��6P   ._�5   
   �� $��5q�6   .+�5      �� -   5        $��ListView��5      ��5      �� *Groups+*  $Microsoft.Xaml.Behaviors.Interaction	   Triggers	 5       +  %Microsoft.Xaml.Behaviors.EventTrigger  5!      
   	EventName$
 MouseDoubleClick��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5"      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   �� *GridDoubleCommand+   CommandParameter 5#   0   �� *SelectedItem+ �� ElementName$ ListView��5$       �� View 5&      �� 5'      P�5(      �� 5)      $��Название��6-    �� Width$	 100��6j    �� DisplayMemberBinding 6?   ��  �� Path$
 Name�6j   5+      5-      5.      5/      51      52      