   M S B A M L   `   `   `  ����  Cs_Notas3    -Cs_Notas.Windows.Escritura.ConsultaServentias   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Consultar Serventias��5   	   $��546.875��6&   $	��589��67    � WindowState$ Normal=�6D    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6o    � WindowStartupLocation$ CenterOwner=�6�    � Icon$+ %/Cs_Notas;component/Imagens/Notas.ico��6�   .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF81F1F1��6   	 � Offset$	 0Q�61   � 5	      $ 	#FFBCC0C3��6   $	 1Q�61   5
      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        
  Name$
 dataGridServentias��5   �      AutoGenerateColumns .   � Cursor$
 Hand��6/    �� AlternationCount$ 2��6=      RowBackground
 �����   AlternatingRowBackground �	#FF8DE1FF   
IsReadOnly .    SelectionMode$ Single=�6�    J� 	AllowDrop .     HeadersVisibility$	 All=�6�      CanUserResizeRows .     SelectionUnit$ FullRow=�6     GridLinesVisibility$
 None=�6.     ClipboardCopyMode$ ExcludeHeader=�6I  $   HorizontalScrollBarVisibility$
 Auto=�6k   � UseLayoutRounding . ��. $��
7,54,10,10q�6�  ��6�  Z�    RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      -   5        5         	CellStyle 5      �� 5      *  $System.Windows.Controls.DataGridCell"  6    �� Triggers 5      P� 5       P� Property �@ 
IsSelected P� Value . . �5      ��   �� Property  � ��! �� Value! �	#FF0086FF6;   5      5      "   Columns" 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn#   Header$# Código��6%   $   Width5  /System.Windows.Controls.DataGridLengthConverter$	$ 100 65   %   CanUserResize% .  1  +System.Windows.Controls.DataGridBoundColumn&   Binding& 6A   �� *Codigo+6\     5      $# Descrição��6%   $	$ 430 68   % .  & 6D   �� *	Descricao+6b   5      �� 5    
   -   5        $��txtConsultaServentia��5       $��23��6.   $��	7,26,10,0q�6:   ' �� TextWrapping$
' Wrap=�6M   $	��Top=�6a   6y   �� 5!   
   $��Consultar Serventia:��6   $
��Left=�6/   $��10,0,0,0q�6J   $	��Top=�6\   $	��261��6t   5"      5#      