   M S B A M L   `   `   `  ���� I  ESkEditorRemake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SkEditorRemakeSkEditorRemake  #    SkEditorRemake.OKDialogWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:SkEditorRemake     ^ ZICSharpCode.AvalonEdit, Version=6.1.2.30, Culture=neutral, PublicKeyToken=9cc39be672370310?
avalonedit.http://icsharpcode.net/sharpdevelop/avalonedit  -     � Title$  SkEditor Remake�� � Icon$ Images/SkEditor.ico�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�
������  � AllowsTransparency .  � WindowStyle$
 None=�$��268.146��$��139.679�� � Triggers :�  :� RoutedEvent$ Window.Loaded��.[��� .���� .��W�  �� TargetProperty$ Opacity�	 W� From$	 0X�	
 W� To$
 1X� g� Duration$ 0:0:0.2D� g� FillBehavior$ HoldEnd=� � 	Resources    Button1 �� 
TargetType ��Name �� CornerRadius J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value  Buttons �� 
TargetType �� Triggers N� EnterActions N� ExitActions��%�  &	        &	     �� " ��.R��� $ Border��$ 5�����#23272A���#23272A$��1q� . ._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ Border�� � �� �#2a4a5b�� $ Border�� � �� �#26a0da��  �@�Cursor$
 Hand���� " A�.���  �@J�Opacity$
 0.25Q� P�  �@J�IsMouseOver .  �� .���� .��W� $ Opacity�$
 1X�$ 0:0:0.2D� �� .���� .��W� $ Opacity�$

 0.25X�$ 0:0:0.2D�.���� ���#2C2F33$ 10��._�� .+��� $��Images/SkEditor.png�� �� BitmapScalingMode$ HighQuality=�$	��Top=�$
��Left=� J� RenderTransformOrigin$ 28.887,-0.097&�$��26��$��	10,10,0,0q�$��23��$��2���� -    ��Name$ closeButton��$��Images/close2.png��$ HighQuality=�$ 28.887,-0.097&�$��20��$��0,7,10,0q�$��20�� � Cursor$
 Hand��$��1��$��Right=�$	��Top=��� -   $��	TextLabel��$	��236��$��55��$,��&/GlitchCode;component/Fonts/#Open Sans)�$
��None��
�������$��10,36,10,35q�$��13(�
������ $
��Wrap=���   �� IsCancel  . #��[  $��207,111,10,8q�$��OK��$,��&/GlitchCode;component/Fonts/#Open Sans)�
�������