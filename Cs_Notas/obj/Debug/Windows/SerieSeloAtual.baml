   M S B A M L   `   `   `  ����  Cs_Notas%    Cs_Notas.Windows.SerieSeloAtual   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Série Selo Atual��5   	   $	��321��6"   $	��471��6/    � WindowState$ Normal=�6;    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6f    � WindowStartupLocation$ CenterOwner=�6|    � Icon$+ %/Cs_Notas;component/Imagens/Notas.ico��6�   ���	#FFE6F2F9.��5      �  J� RenderTransformOrigin$ 0.475,0.504&�6   .+�5   
   �� -   5         ��Name$ 	btnSalvar��5      $��6��6$   $��0q�61   $��0q�6=    � Cursor$
 Hand��6Q   	 � ToolTip$	 Salvar��6_   $��50��6p   $	��Top=�6|   $ -0.357,0.569&�6�   $��200,223,0,0q�6�   $
��Left=�6�   $��65��6  ��5      �� 5      ��5
      �� 5      .R�5      �� 
���   �$��Center=�63   $��Center=�6P   $��0q�6l   
 �� Padding$
 0q�6w   $��40��6�   $��50��6�   ��5      �� 5       �� ImageSource$+ %/Cs_Notas;component/Imagens/Check.png��6)   ��5      �� 5       �� 
TargetType" ��6$    �� Triggers 5   "   P� 5   &    P� Property �@J�IsMouseOver P� Value . . �5   *   ��  �� Property � �� �� Value
 ���� 6H   5   '   5      5      5      5      �� 5   
   $��Série Selecionda��6   $	��107��6-   $��	9,111,0,0q�6:   $	��Top=�6M   $
��Left=�6e   $	��435��6�   .��5      � $��	0,0,-2,-1q�6   .+�5      �� $��Letra:��6   $
��Left=�6)   $��	11,10,0,0q�6D   $	��Top=�6W   $ 	0.474,0.5&�6o   $��24��6�   $��47��6�   �� 5       -   5         ��Name$ txtSerieLetra��5       $
��Left=�61   $��24��6L   $��	62,10,0,0q�6X    �� TextWrapping$
 Wrap=�6k   $	��Top=�6   $��79��6�    �� 
IsReadOnly .  �� IsReadOnlyCaretVisible . ���	#FFD6F7F76�   �� 5!      $��Inicial:��6   $
��Left=�6+   $��
146,10,0,0q�6F   $	��Top=�6Z   $ 	0.474,0.5&�6r   $��24��6�   $��51��6�   �� 5"      -   5        $ txtSerieInicial��5"      $
��Left=�63   $��24��6N   $��
199,10,0,0q�6Z   $
 Wrap=�6n   $	��Top=�6�   $��79��6�    .  . ���	#FFD6F7F76�   �� 5#      $��Final:��6   $
��Left=�6)   $��
282,10,0,0q�6D   $	��Top=�6X   $ 	0.474,0.5&�6p   $��24��6�   $��46��6�   �� 5$      -   5        $ txtSerieFinal��5$      $
��Left=�61   $��24��6L   $��
332,10,0,0q�6X   $
 Wrap=�6l   $	��Top=�6�   $��79��6�    .  . ���	#FFD6F7F76�   �� 5%      $
��Qtd:��6   $
��Left=�6'   $��	19,48,0,0q�6B   $	��Top=�6U   $ 	0.474,0.5&�6m   $��24��6�   $��39��6�   �� 5&      -   5        $ txtSerieQtd��5&      $
��Left=�6/   $��24��6J   $��	62,48,0,0q�6V   $
 Wrap=�6i   $	��Top=�6}   $��79��6�    .  . ���	#FFD6F7F76�   �� 5'      $��Utiliz.:��6   $
��Left=�6+   $��
146,48,0,0q�6F   $	��Top=�6Z   $ 	0.474,0.5&�6r   $��24��6�   $��51��6�   �� 5(      -   5        $ txtSerieUtilizado��5(      $
��Left=�65   $��24��6P   $��
199,48,0,0q�6\   $
 Wrap=�6p   $	��Top=�6�   $��79��6�    .  . ���	#FFD6F7F76�   �� 5)      $��Livre:��6   $
��Left=�6)   $��
282,48,0,0q�6D   $	��Top=�6X   $ 	0.474,0.5&�6p   $��24��6�   $��46��6�   �� 5*      -   5        $ txtSerieLivre��5*      $
��Left=�61   $��24��6L   $��
332,48,0,0q�6X   $
 Wrap=�6l   $	��Top=�6�   $��79��6�    .  . ���	#FFD6F7F76�   5+      5,      &   System.Windows.Controls.DataGrid  5-   
   -	   5          Name$ dataGridSeriesDisponiveis��5-   �      AutoGenerateColumns .  $
 Hand��6/    �� AlternationCount$ 2��6=      RowBackground
 �����   AlternatingRowBackground �	#FFD0E8B9   
IsReadOnly .    SelectionMode$ Single=�6�    J� 	AllowDrop .     HeadersVisibility$	 All=�6�      CanUserResizeRows .      SelectionUnit$  FullRow=�6  !   GridLinesVisibility$
! None=�65  "   ClipboardCopyMode$" ExcludeHeader=�6P  $#   HorizontalScrollBarVisibility$
# Auto=�6r  $ � UseLayoutRounding$ . ��. $	��106��6�  $	��Top=�6�  $
��Left=�6:  $	��433��6U  $��11,0,0,0q�6a  ��6�  Z� %   	CellStyle% 5.      �� 5/      *  $System.Windows.Controls.DataGridCell"  6    50      P� 51       �@ 
IsSelected . . �52      ��  � �� �	#FF0086FF6;   53      55      &   Columns& 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn'   Header$' 	Id Série��6%   (   Width5  /System.Windows.Controls.DataGridLengthConverter$	( 105 67   )   CanUserResize) .  *   
Visibility$* Visible=�6u   1  +System.Windows.Controls.DataGridBoundColumn+   Binding+ 6C   �� *	SerieId+6u     59      $' Letra��6%   $	( 100 64   ) .  + 6@   �� *Letra+6Z     5:      $' Inicial��6%   $	( 100 66   ) .  + 6B   �� *	Inicial+, �� StringFormat$, 	{0:00000}��6x     5;      $' Final��6%   $	( 100 64   ) .  + 6@   �� *Final+$, 	{0:00000}��6t   5=      5?      5@      