   M S B A M L   `   `   `  ����  Cs_Notas&     Cs_Notas.Windows.SelosReservados   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Selos Reservados��5   	   $	��340��69   $	��684��6F    � 
ResizeMode$ NoResize=�6R    � Icon$+ %/Cs_Notas;component/Imagens/Notas.ico��6h    � WindowStartupLocation$ CenterOwner=�6�    � ShowInTaskbar .  .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridSelosReservados��5   �      AutoGenerateColumns .   �� AlternationCount$ 2��6/      RowBackground
 �����	   AlternatingRowBackground	 �	#FF8DE1FF
   
IsReadOnly
 .    SelectionMode$ Single=�6�    J� 	AllowDrop .     HeadersVisibility$	 All=�6�      CanUserResizeRows .     SelectionUnit$ FullRow=�6     GridLinesVisibility$
 None=�6%     ClipboardCopyMode$ ExcludeHeader=�6@  $   HorizontalScrollBarVisibility$
 Auto=�6b   � UseLayoutRounding . ��. $��0,71,0,0q�6�  ��6�  Z�    RowStyle 5      �� 5	       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5
      -   5        5         	CellStyle 5      �� 5      *  $System.Windows.Controls.DataGridCell"  6    �� Triggers 5      P� 5       P� Property �@ 
IsSelected P� Value . . �5      ��  �� Property � �� �� Value �	#FF0086FF6;   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Letra��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 64      CanUserResize .      
Visibility$  Visible=�6o   1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 6?   �� *Letra+6o     5      $ Número��6%   $ 60 65    .  ! 6@   �� *Numero+" �� StringFormat$" 	{0:00000}��6u     5      $ 
Aleatório��6%   $ 60 68    .  ! 6C   �� *	Aleatorio+6a     5      $
 Data��6%   $ 70 63    .  ! 6>   �� *DataReservado+$" 
dd/MM/yyyy��6y     5      $ Usuário��6%   $	 160 66    .  $  Visible=�6}   ! 6B   �� *UsuarioReservado+6}     5      $ Livro��6%   $ 60 64    .  $  Visible=�6o   ! 6?   �� *Livro+6o     5      $ Fls. Ini��6%   $ 60 67    .  $  Visible=�6z   ! 6B   �� *FolhaInicial+6z     5      $ Fls. Fim��6%   $ 60 67    .  $  Visible=�6x   ! 6B   �� *
FolhaFinal+6x     5      $	 Ato��6%   $ 50 62    .  $  Visible=�6r   ! 6=   �� *	NumeroAto+6r   5!      �� 5"   
   ���	#FFB2ECFD$
��Left=�6%   $��55��6@   $��	29,10,0,0q�6L   
���   �$	��Top=�6n   $	��616��6�   �� 5#   
   -   5        $��lblTexto��5#   9   $&�� SELOS RESERVADOS DE PROCURAÇÃO��6   $
��Left=�6I   $��
107,20,0,0q�6d   $	��Top=�6x   # J� RenderTransformOrigin$# 0.474,0.538&�6�   $	��470��6�   $��24(�6�   $��46��6�   $
��Bold"�6�   $��Italic$�6�   $��PMingLiU-ExtB)�6�   5%      5&      