   M S B A M L   `   `   `  ���� I  ESkEditorRemake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SkEditorRemakeSkEditorRemake  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem     SkEditorRemake.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:SkEditorRemake     ^ ZICSharpCode.AvalonEdit, Version=6.1.2.30, Culture=neutral, PublicKeyToken=9cc39be672370310?
avalonedit.http://icsharpcode.net/sharpdevelop/avalonedit  3System&clr-namespace:System;assembly=mscorlib  -     � Title$  SkEditor Remake��$	��450��#��Z��$	��450��$	��800��$	��800�� � Icon$ Images/SkEditor.ico�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ 	CanResize=�
������  � WindowStyle$
 None=� � AllowsTransparency . '  !System.Windows.Shell.WindowChrome   WindowChrome      GlassFrameThickness$ 0q�   CornerRadius$ 5��	   CaptionHeight$	 0Q�
   UseAeroCaptionButtons
 .     ResizeBorderThickness$ 7q� � 	Resources    Roboto-Mono �� Property �� Value  ContextMenu �� 
TargetType �� CornerRadius J� SnapsToDevicePixels  MenuItem ��Name J� IsManipulationEnabled � ForceCursor � OverridesDefaultStyle � AllowsTransparency �� RelativeSource �� Triggers P� Property P� Value �� 
TargetName �� 
TargetType  ScrollBarThumb �� Triggers N� EnterActions �� TargetProperty	  W� To! g� Duration" N� ExitActions# � RowDefinitions$ ]�Name% ]� Thumb��%  &	        &	 .     &	 �     &	 +    '�� 4    7  �� .���  � ��$ Fonts/#Roboto Mono)��� " ��.R��� $ 5�����	#FF2C2F33$��1q����	#FF2C2F33 . ._��� �� " m�.R��� $ Border��#��z��#��z��#��z�� . ._�� .+��� #��z��#��z�� .   .  ��.   .  �  . #��� -����� *IsSubmenuOpen+ �� *TemplatedParent+.���� $ 5�����	#FF2C2F33$��1q����	#FF2C2F33 .  .  ._���  P�  �@m�IsHighlighted . . ��� $ Border�� � �� �#2a4a5b�� $ Border�� � �� �#26a0da��  �@�Cursor$
 Hand���� " n�.���  � �� �� " n�.R��� $ 2�����#595959��  �@J�Opacity$	 0.4Q� P�  �@J�IsMouseOver .  �� .���� .��W� $ Opacity�$
  0.75X�$! 0:0:0.2D�" �� .���� .��W� $ Opacity�$	  0.4X�$! 0:0:0.2D��� " ��.���  � �� �� " ��.R�� # �� $��0.00001* �.+��� $��1��]� $$ 
PART_Track��$��1����. % n� 8��  $��1,0,1,0q�& J� CommandBindings& )  #System.Windows.Input.CommandBinding  -   '   Command$' ApplicationCommands.New��  -   $' ApplicationCommands.Open��  -   $' ApplicationCommands.Save��  -   $ ' ApplicationCommands.SaveAs��  -   $' ApplicationCommands.Close��( J� InputBindings( �� ) �� 	Modifiers$
) Ctrlf�
* �� Key$* N��+ �� Command$+ ApplicationCommands.New���� $
) Ctrlf�$* O��$+ ApplicationCommands.Open���� $
) Ctrlf�$* S��$+ ApplicationCommands.Save���� $) 
Ctrl+Shiftf�$* S��$ + ApplicationCommands.SaveAs���� $
) Ctrlf�$* W��$+ ApplicationCommands.Close��.���� -   $ Border�����#2C2F33$ 10��._�� -   , �Name$, 
editorGrid��- � ColumnDefinitions- �� $
��587* ��� $
��213* �# �� $	��88* ��� $
��137* �.+��� -	   . ��Name$. SkEditorLogo��$��Images/SkEditor.png��$	��Top=�$
��Left=�/ J� RenderTransformOrigin$/ 50.887,-0.097&�$��27��$��10,7,0,0q�$��27��0 �� BitmapScalingMode$0 HighQuality=�o� -
   1 o�Name$1 	MenuStrip��
������ 
�������2 o� 
IsMainMenu2 . $��42,11,327,142q�$��OpenSans)�$��23��.@�m� -   3 m�Name$3 fileMenuStripItem��
�������$
��File��#��[ .@�m� -   $3 newFileMenuItem��4 � Cursor$
4 Hand��
�������$	��New�����#2C2F33���#2C2F335 m� InputGestureText$5 Ctrl+N��m� -   $3 openFileMenuItem��$
4 Hand��
�������$
��Open�����#2C2F33���#2C2F33$5 Ctrl+O��m� -   $3 saveMenuItem��$
4 Hand��
�������$
��Save�����#2C2F33���#2C2F33$5 Ctrl+S��m� -   $3 saveAsMenuItem��$
4 Hand��
�������$��Save As�����#2C2F33���#2C2F33$5 Ctrl+Shift+S���� m� -   $3 publishMenuItem��$
4 Hand��
�������$��Publish Code�����#2C2F33���#2C2F33�� m� -   $3 closeMenuItem��$
4 Hand��
�������$��Close�����#2C2F33���#2C2F33$5 Ctrl+W��m� -   $3 exitMenuItem��$
4 Hand��
�������$
��Exit�����#2C2F33���#2C2F33$5 Alt+F4��m� -   $3 editMenuStripItem��
�������$
��Edit��#��[ .@�m� -   $3 undoMenuItem��$
4 Hand��
�������$
��Undo�����	#FF2C2F33���	#FF2C2F33$5 Ctrl+Z��m� -   $3 redoMenuItem��$
4 Hand��
�������$
��Redo�����	#FF2C2F33���	#FF2C2F33$5 Ctrl+Y���� m� -   $3 cutMenuItem��$
4 Hand��
�������$	��Cut�����	#FF2C2F33���	#FF2C2F33$5 Ctrl+X��m� -   $3 copyMenuItem��$
4 Hand��
�������$
��Copy�����	#FF2C2F33���	#FF2C2F33$5 Ctrl+C��m� -   $3 pasteMenuItem��$
4 Hand��
�������$��Paste�����	#FF2C2F33���	#FF2C2F33$5 Ctrl+V���� m� -   $3 selectAllMenuItem��$
4 Hand��$��
Select all�����	#FF2C2F33���	#FF2C2F33$5 Ctrl+A��m� -   $3 otherMenuStripItem��
�������$��Other��#��[ .@�m� -   $3 settingsMenuItem��$��Settings��m� -   $3 informationsMenuItem��$��About���� -   $. closeAppButton��$��Images/close2.png��$0 HighQuality=�$/ 28.887,-0.097&�$��20��$��0,7,10,0q�$��20��$
4 Hand��$��1��$��Right=�$	��Top=��� -   $. minimizeButton��$��Images/minimize2.png��$0 HighQuality=�$/ 28.887,-0.097&�$��20��$��0,7,60,0q�$��20��$
4 Hand��$��1��$��Right=�$	��Top=��� -   $. maximizeButton��$��Images/maximize2.png��$0 HighQuality=�$/ 28.887,-0.097&�$��20��$��0,7,35,0q�$��20��$
4 Hand��$��1��6 J� Opacity$
6 0.98Q�$��Right=�$	��Top=��� -    7 ��Name$7 tabControl1��$��10,38,10,10q����#1F1F1F$��2��$��2��$��0q���Z�  8 ��Name��%�  '��       �� " ��.���  � �� �� " ��.R�� $��Panel��.+��� $��Border��
�������$ 4,4,0,0��$	��2,0q�._��� $8 ContentSite��$��Center=�$��Center=�$��Header��$
��10,2q� P�  �@��
IsSelected .  . ��� $ Panel�� � �� �#1F1F1F�� $ Panel�� � ��
 �����P�  �@��
IsSelected . . ��� $ Panel�� � �� �	#FF4C74E0�� $ Panel�� � ��
 �����