   M S B A M L   `   `   `  ����  Cs_Notas5    /Cs_Notas.Windows.Escritura.MovelOutrosEscritura   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  MovelOutrosEscritura��5   	   $	��413��6&   $	��640��63    � WindowState$ Normal=�6?    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6j    � WindowStartupLocation$ CenterOwner=�6�    � Icon$+ %/Cs_Notas;component/Imagens/Notas.ico��6�   ���	#FFE6F2F9.��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF81F1F1��6   	 � Offset$	 0Q�61   � 5	      $ 	#FFBCC0C3��6   $	 1Q�61   5
      .+�5   
   �� $e��_Selecione os Atos para adicionar este participante. Duplo clique para marcar ou desmarcar o ato��6   $
��Left=�6|   $��	6,204,0,0q�6�   $	��Top=�6�   $	��112��6�   $	��611��6�   .��5      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 dataGridAtoConjunto��5   w      AutoGenerateColumns .  $��3��63      EnableRowVirtualization .    RowDetailsVisibilityMode$ VisibleWhenSelected=�6�    J� 	AllowDrop .     HeadersVisibility$	 All=�6�      CanUserResizeRows .     SelectionUnit$ FullRow=�6     GridLinesVisibility$	 All=�6     ClipboardCopyMode$ ExcludeHeader=�69  $   HorizontalScrollBarVisibility$
 Auto=�6[   � UseLayoutRounding . ��. $��
-1,0,-2,-2q�6�     
IsReadOnly .    SelectionMode$ Single=�6�  ���	#FF466787��6_   �� ��6�  Z�    RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      -   5        5       � ContextMenu 5      �� 5      -   5         ��Name$
 menu��5   P    �� 
IsSelected .  � ForceCursor . .@�5      m� -   5         m�Name$ MenuItemMarcarTodos��5   9   $��Marcar todos��6#    m� Icon 5      �� 5   "   $1��+/Cs_Notas;component/Imagens/check_23832.png��6(   5      m� 5      -   5        $ MenuItemDesmarcarTodos��5   <   $��Desmarcar todos��6#    5      �� 5   "   $1��+/Cs_Notas;component/Imagens/check_24016.png��6(   5      5          	CellStyle  5!      �� 5"      *  $System.Windows.Controls.DataGridCell"  6   ! �� Triggers! 5#      P� 5$      " P� Property" �@ 
IsSelected# P� Value# . . �5%   "   �� $ �� Property$ � ��% �� Value% �	#FF0086FF6?   5&      5(      &   Columns& 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn'   Header$' 	Id Série��6)   (   Width5  /System.Windows.Controls.DataGridLengthConverter$( 70 6;   )   CanUserResize) .  *   
Visibility$* Hidden=�6{   +   
IsReadOnly+ . 1  +System.Windows.Controls.DataGridBoundColumn,   Binding, 6F   �� *
ConjuntoId+6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5,      $' #��6-   $( 20 68   ) .  + . , 6C   �� *	IsChecked+6x     5-      $
' Data��6)   $( 70 67   ) .  + . , 6B   �� *Data+- �� StringFormat$- 
dd/MM/yyyy��6�     5.      $
' Selo��6)   $( 80 67   ) .  + . , 6B   �� *Selo+$- 	{0:00000}��6�     5/      $' 
Aleatório��6)   $( 60 6<   ) .  + . , 6G   �� *	Aleatorio+6|     50      $' Descrição��6)   $	( 360 6<   ) .  + . , 6H   �� *	TipoAto+6{   53      54      �� 55   
   $��Valor do Bem��6   $
��Left=�6)   $��58��6D   $��	452,5,0,0q�6P   $	��Top=�6c   $	��165��6{   .��56      � $��42��6   $��10,0,0,0q�6   $	��Top=�61   $
��Left=�6I   $	��132��6d   .+�57      �� -   5        . ��Name$. txtValorBemImovel��57   a   $��1��6   / �� 	MaxLength$/ 9��6'   0 �� CharacterCasing$0 Upper=�65   1 �� TextWrapping$
1 Wrap=�6M   $��0,7,0,10q�6|   $��14(�6�   
���   �$
��Left=�60  $	��130��6K  58      59      �� 5:   
   -   5        $��	txtObjeto��5:   �   $
��Left=�6   $	��131��6-   $��2��6:   $	/ 250��6G   $��6,68,0,0q�6W   $0 Upper=�6i   $
1 Wrap=�6�   $	��Top=�6�   $	��611��6�   ���	#FF01185B2 �� SelectionBrush
2 �   �6�   �� 5;   
   -	   5        3 ��Name$3 	btnSalvar��5;      $��4��6$   $��0q�61   $��0q�6=   4 � Cursor$
4 Hand��6Q   5 � ToolTip$5 Salvar��6_   $��533,321,0,0q�6p   $
��Left=�6�   $��84��6�   $��47��6�   $	��Top=�6�   6 J� RenderTransformOrigin$6 0.5,0.5&�6�   ��5<      �� 5=      ��5?      �� 5@      .R�5A      �� 
���   �$��Center=�64   $��Center=�6Q   $��0q�6m   7 �� Padding$7 0q�6x   $��40��6�   $��57��6�   ��5B      �� 5C      8 �� ImageSource$-8 '/Cs_Notas;component/Imagens/Salvar2.png��6)   ��5E      �� 5F      " ��6$   ! 5G   "   P� 5H   &   " �@J�IsMouseOver# . . �5I   *   �� $ � ��
% ���� 6H   5J   '   5L      5N      5O      5Q      �� 5R   
   $��Descrição do Objeto:��6   $
��Left=�6/   $��	10,42,0,0q�6J   $	��Top=�6]   $	��202��6u   5T      5U      