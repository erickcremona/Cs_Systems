   M S B A M L   `   `   `  ����  Cs_Notas0    *Cs_Notas.Windows.Escritura.OrigemEscritura   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Origem��5      $��294.672��6   $��568.119��6%    � WindowState$ Normal=�65    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6`    � WindowStartupLocation$ CenterOwner=�6v    � Icon$+ %/Cs_Notas;component/Imagens/Notas.ico��6�   ���	#FFE6F2F9.��5      � $��0,0,0,3q�6   .+�5   
   �� ���	#FFC9C9C9$
��Left=�6%   $	��182��6@   $��	10,10,0,0q�6M   
���   �$	��Top=�6o   $	��530��6�   �� 5   
   $��Desconhecido:��6   $
��Left=�6(   $��	35,20,0,0q�6C   $	��Top=�6V   $	��123��6n   �� 5   
   -   5        $��txtDesconhecido��5      $��1��6    �� CharacterCasing$ Upper=�66   $
��Left=�6N   $��23��6i   $��	35,46,0,0q�6u    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��483��6�   6�   �� 5	   
   -   5        $��lblLivro��5	      $��Livro Ref.:��6!   $
��Left=�67   $��	35,74,0,0q�6R   $	��Top=�6e   $��86��6}   ���	#FFFD00006�   �� 5
   
   -   5        $��txtLivroReferente��5
      $��2��6   $ Upper=�68   $
��Left=�6P   $��23��6k   $��
35,100,0,0q�6w   $
 Wrap=�6�   $	��Top=�6�   $��86��6�   6�   �� 5   
   -   5        $��lblFolhaRef��5      $��Folha Ref.:��6#   $
��Left=�69   $��
141,74,0,0q�6T   $	��Top=�6h   $��86��6�   ���	#FFFD00006�   �� 5   
   -   5        $��txtFolhaReferente��5      $��3��6   $ Upper=�68   $
��Left=�6P   $��23��6k   $��141,100,0,0q�6w   $
 Wrap=�6�   $	��Top=�6�   $��86��6�   6�   �� 5   
   -   5        $��lblUf��5      $	��UF:��6   $
��Left=�6+   $��
247,74,0,0q�6F   $	��Top=�6Z   $��81��6r   ���	#FFFD00006}   �� 5   
   -   5        $��cmbUf��5       $��4��6   $
��Left=�6-   $��247,100,0,0q�6H   $	��Top=�6]   $��81��6u   6�   �� 5   
   -	   5        $��	lblCidade��5      $��Cidade:��6!   $
��Left=�63   $��
342,74,0,0q�6N   $	��Top=�6b   $	��109��6z   ���	#FFFD00006�   �� 5   
   -
   5        $��	cmbCidade��5       $��5��6   $
��Left=�61   $��342,100,0,0q�6L   $	��Top=�6a   $	��176��6y   6�   �� 5   
   -   5        $��lblServentia��5      $��
Serventia:��6$   $
��Left=�69   $��141,127,0,0q�6T   $	��Top=�6i   $��77��6�   ���	#FFFD00006�   �� 5   
   -   5         ��Name$ btnSairSemSalvar��5      $��0q�6+   $��0q�67   	 � Cursor$
	 Hand��6K   
 � ToolTip$
 Cancelar sem salvar��6Y   $��421,215,0,0q�6w   $
��Left=�6�   $��45��6�   $��38��6�   $	��Top=�6�   ��5      �� 5      ��5      �� 5      .R�5      �� 
���   �$��Center=�64   $��Center=�6Q   $��0q�6m    �� Padding$ 0q�6x   $��32��6�   $��39��6�   ��5      �� 5       �� ImageSource$. (/Cs_Notas;component/Imagens/Cancelar.png��6)   ��5      �� 5       �� 
TargetType" ��6$    �� Triggers 5   "   P� 5   &    P� Property �@J�IsMouseOver P� Value . . �5    *   ��  �� Property � �� �� Value
 ���� 6H   5!   '   5#      5%      5&      5(      �� 5)   
   -   5        $ btnSalvarSair��5)      $��8��6   $��0q�65   $��0q�6A   $
	 Hand��6U   $
 Sair e Salvar Escritura��6c   $��490,215,0,0q�6�   $
��Left=�6�   $��45��6�   $��38��6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.495,0.118&�6   ��5*      �� 5+      ��5-      �� 5.      .R�5/      �� 
���   �$��Center=�64   $	��Top=�6Q   $��0q�6j   $ 0q�6u   $��22��6�   $��33��6�   ��50      �� 51      $+ %/Cs_Notas;component/Imagens/Check.png��6)   ��53      �� 54      " ��6$    55   "   P� 56   &    �@J�IsMouseOver . . �57   *   ��  � ��
 ���� 6H   58   '   5:      5<      5=      5?      �� 5@   
   -   5         ��Name$ 	txtCodigo��5@      $��6��6   $
��Left=�62   $��32��6M    �� 	MaxLength$ 4��6Y   $
 Wrap=�6g   $	��Top=�6{   $��72��6�   
�������$��18(�6�   $��
35,153,0,0q�6�   6�   �� 5A   
   -   5        $ btnConsultarServentia��5A      $��0q�60   $��0q�6<   $
	 Hand��6P   $
 Consultar Serventia��6^   $��107,153,0,0q�6|   $
��Left=�6�   $��34��6�   $��32��6�   $	��Top=�6�   $ 0.433,0.571&�6�   ��5B      �� 5C      ��5E      �� 5F      .R�5G      �� 
���   �$��Center=�64   $��Center=�6Q   $��0q�6m   $ 0q�6x   $��24��6�   $��25��6�   ��5H      �� 5I      $1 +/Cs_Notas;component/Imagens/LupaPequena.png��6)   ��5K      �� 5L      " ��6$    5M   "   P� 5N   &    �@J�IsMouseOver . . �5O   *   ��  � ��
 ���� 6H   5P   '   5R      5T      5U      5W      �� 5X   
   -   5        $ txtServentia��5X   1   |�.  $��7��6$   $
��Left=�6G   $��32��6b    �� 
IsReadOnly . $
 Wrap=�6�   $	��Top=�6�   $	��377��6�   
�������$��141,153,0,0q�6�   6�   �� 5Y   
   -   5        $��	lblCodigo��5Y      $��Código:��6!   $
��Left=�63   $��
35,127,0,0q�6N   $	��Top=�6b   $��67��6z   ���	#FFFD00006�   5[       � 	Resources 5\         Flat_ComboBox  ComboBoxToggleButton �� 
TargetType � ColumnDefinitions ��Name �� CornerRadius F�Name �� Triggers �� 
TargetName  ComboBoxTextBox �� 	ClickMode  d� 	IsChecked! �� Path" �� Mode# �� RelativeSource$ J� IsHitTestVisible% �� SelectionBoxItem& �� SelectionBoxItemTemplate' �� 
IsReadOnly( �� IsDropDownOpen) � AllowsTransparency* J� SnapsToDevicePixels+ � ActualWidth, �� MaxDropDownHeight- K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation.   DirectionalNavigation/ P� 
SourceName0 �� Padding��%?  &	        &	 J    &	 I    '�� �    7  7  '�� �    �� 5]   
   " ��6   .�5^      ��  � ��$ Stretch=�64   �� 5_       � ��$	 Top=�62   �� 5`       � ��$ 30��6)   �� 5a       �@J�SnapsToDevicePixels . 6>   �� 5b       � ��$ Disabled=�6K   �� 5c       � ��$
 Auto=�6I   �� 5d       � �� . 6>   �� 5e       � ��
 �   �67   �� 5f       �@�FocusVisualStyle 6B   Z� �� 5g       � ��$ 0q�60   �� 5h       � ��
 �����6+    5j      P� 5k       �@J�IsMouseOver . . �5l      ��  � ��
 ��·�63   5m      5p      �� 5s   
   " d�67   .R�5t      �  5u      �� 5v      �� 5w      $��20 �6'   .+�5y      �� $ Border��5z      $��2��5{      $ 2��5|      ���	#FF72A8A3���#404040$��1q�5      �� 5�      $��0��5�      $ 2,0,0,2��5�      $��1q�5�      ���#FFFFFF���#404040$��0,0,1,0q�5�      F� 5�      $ Arrow��5�      $��1��5�      ���#404040$��Center=�5�      $��Center=�5�      "����        � 	=  	= � z     	5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      �� $ Border��6    � �� �#8080806G   5�      P� 5�       �@d�	IsChecked$
 trueY�6<   . �5�      �� $ Border��6    � �� �#E0E0E06G   5�      P� 5�       � {� .  . �5�      �� $ Border��6    � �� �#EEEEEE6G   �� 5�      $ Border��6    � �� �#AAAAAA6H   �� 5�       � �� �#88888863   �� 5�      $ Arrow��6    � �� �#8888886@   5�      5�      �� 5�   
   " ��62   .R�5�      �� $ PART_ContentHost��6   |�.  #��z��6A   5�      �� 5�   
   " ��6*   .�5�      ��  �@J�SnapsToDevicePixels . 64   �� 5�       �@�OverridesDefaultStyle . 66   �� 5�       � ��$
 Auto=�6K   �� 5�       � ��$
 Auto=�6I   �� 5�       � �� . 6>   �� 5�       � ��$ 30��6)   �� 5�       � ��$ 20��6*   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      � .+�5�      d� $��ToggleButton��5�   	   8��  $��2��5�   	   |�.  $ Press=�5�   	     5�   	   �� $! IsDropDownOpen�$" TwoWay=�# �� *TemplatedParent+5�      �� 5�      $��ContentSite��5�   	   $ .  #��z% 5�   	   #��z& 5�   	   #��z��5�   	   $��3,3,23,3q�5�   	   $��Center=�5�   	   $
��Left=�5�   	   �� 5�      $ PART_EditableTextBox��6&   8�� $
��Left=�5�   	   $��Center=�5�   	   $��3,3,23,3q�5�   	   |�. 
������ $y�Hidden=�5�   	   # z' 5�   	   ��5�   	   Z� 5�   	   � 5�      $��Popup��5�   	   $��Bottom=�5�   	   #��z( 5�   	   ) . |�.  $��Slide=�5�   	   .��5�   "   � $��DropDown��5�      * . #��z+ 5�      #��z, 5�      .+�5�   &   �� $ DropDownBorder��5�      ���#FFFFFF$��1q�5�      ���#8888885�      �� 5�   &   $��4,6,4,6q�63   * . .��5�   *   �� - . $. 	Contained=�6H   5�   '   5�   #   5�      5�       5�      P� 5�       �@��HasItems .  . �5�   "   �� $ DropDownBorder��6)    � ��$ 95��6Z   5�      P� 5�       � {� .  . �5�   "   ��  � �� �#8888886?   5�      P� 5�       �@��
IsGrouping . . �5�   "   ��  � �� .  6R   5�      P� 5�      $/ Popup��6&    �@�AllowsTransparency . . �5�   "   �� $ DropDownBorder��6)    �@��CornerRadius$ 4��6]   �� 5�   "   $ DropDownBorder��6)    � ��$ 0,2,0,0q�6W   5�      P� 5�       �@��
IsEditable . . �5�   "   ��  � �� .  6>   �� 5�   "   $ PART_EditableTextBox��6)    � y�$ Visible=�6a   �� 5�   "   $ ContentSite��6)    � y�$ Hidden=�6X   5�      5�      5�       5�      5�      �� 5�   
   " ��6.   .�5�      ��  �@J�SnapsToDevicePixels . 64   �� 5       �@�OverridesDefaultStyle . 66   �� 5      � �� 5     �� 5     " ��6&   .R�5     �� $��Border��5     $0 2q�5     * . ._�5     �� 5	      5
     P� 5      �@��IsHighlighted . . �5  "   �� $ Border��6)    � �� �#DDDDDD6S   5     P� 5      � {� .  . �5  "   ��  � �� �#8888886?   5     5     5     5     5     5     