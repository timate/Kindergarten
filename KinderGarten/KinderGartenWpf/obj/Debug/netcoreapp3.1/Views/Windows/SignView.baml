   M S B A M L   `   `   `  ����  KinderGarten,    &KinderGartenWpf.Views.Windows.SignView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5      Q MControlzEx, Version=4.0.0.0, Culture=neutral, PublicKeyToken=69f1c32f803d307e
controlzexurn:controlzex  6=   ^ ZSharpVectors.Converters, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b532964b8548be771svgc&http://sharpvectors.codeplex.com/svgc/  6_   -   5          �Name$
  Sign��5   	    � AllowsTransparency$
 True��5       � WindowStyle$
 None=�5	         DialogStyle#��[  5
      $	��600��5      $	��400��5       � WindowStartupLocation$ CenterScreen=�5       � Title$. (Ласточка: авторизация��5   	    � DataContext 5      �� *SignVM+  ViewModelLocator �� Source# [ '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
   *  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5      /  )ControlzEx.Behaviors.WindowChromeBehavior  5   
   .��5      � 	 � ColumnDefinitions	 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $&�� /Assets/Images/SignViewImage.jpg��6   $��Uniform=�6:   
 �� StretchDirection$

 Both=�6L   �� 5   
   $��1��6     BackgroundBrush#��[ 6!    �� Padding$ 15q�6P    
 Shadow J� Effect# [ 6]   ._�5       �� $��Center=�6   .+�5"      (  "SharpVectors.Converters.SvgViewbox   (� Stretch$ Uniform=�6"      Source$ /Assets/Images/Logo.svg?�64   $��46��6U   $��50��6`   $��Center=�6l   �� 5$      $��ЛАСТОЧКА��6   $��24(�6,   $��0 0 0 0q�6:    �� TextAlignment$ Center=�6K     ForegroundBrush#��[ 5%      $��SemiBold"�6J   �� 5&      $��АВТОРИЗАЦИЯ��6   $��14(�6/   $��0 0 0 0q�6=   $ Center=�6N   #��[ 5'      $��SemiBold"�6J   �� 5*      $ Center=�65    �� Padding$ 10q�6L   
���\\��$��14(�5+   7   $��Medium"�5,      ��5*      �� *	Message+y�5+   E   �� *ErrorVisibility+5,      �� 50      
 � Tag$ 
Логин��6   $��10 15q�6J   ��6&   �� *Login+ �� Mode$ TwoWay=�6J   �� 54      $ Пароль��6   $��10 15q�6N   ��6'   �� *
Password+$ TwoWay=�6N   �� 56      $��
Войти��6   $��Right=�6)   $��
10 15 10 0q�6E     AccentButton#��[ 6Y   ��57      �� *SignCommand+��58      ��  �� RelativeSource ��  �� AncestorType" � �� Mode$ FindAncestor=�59      5:      �� 5<   
    
 Loader#��[ 6   $��1��65   $
��Left=�6E   $��Bottom=�6`   $��2��6{     AccentBrush#��[ 6�   5=      5>      