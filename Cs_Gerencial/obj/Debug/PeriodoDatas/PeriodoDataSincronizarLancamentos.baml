   M S B A M L   `   `   `  ����  Cs_GerencialA    ;Cs_Gerencial.PeriodoDatas.PeriodoDataSincronizarLancamentos   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$!  Período de Sincronização��5   	    � 
ResizeMode$ NoResize=�6*    � WindowState$ Normal=�6@    � WindowStartupLocation$ CenterOwner=�6U    � ShowInTaskbar .   � Icon$3 -/Cs_Gerencial;component/Imagens/Gerencial.ico��6�   ���	#FFFFF5E9$	��149��6�   $	��402��6�   .��5      � .+�5   
   �� $��Período��6   $��	10,10,0,0q�6$   $��85��67   $	��Top=�6C   $
��Left=�6[   $	��369��6v   .��5      � $��0,0,-2,1q�6   .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ dpSincronizarInicio��5      $��	19,22,0,0q�6:   $��24��6�   $	��Top=�6�   $
��Left=�6�   $	��101��6�     5	      -   5        $ dpSincronizarFim��5	      $��
138,22,0,0q�67   $��24��6�   $	��Top=�6�   $
��Left=�6�   $	��101��6�   �� 5
      $��Data Inicial:��6   $
��Left=�60   $	��Top=�6K   $��19,0,0,0q�6c   �� 5      $��Data Final:��6   $
��Left=�6.   $	��Top=�6I   $��	144,0,0,0q�6a   �� 5      -   5         ��Name$ btnSincronizar��5      $��0q�61   $��0q�6=    � Cursor$
 Hand��6Q   	 � ToolTip$	 Sincronizar��6_   
 J� RenderTransformOrigin$
 -0.357,0.569&�6u   $��	259,6,0,0q�6�   $��51��6�   $	��Top=�6�   $
��Left=�6�   $��81��6	  ��5      �� 5      ��5      �� 5      .R�5      �� 
���   �$��Center=�6;   $��Center=�6X   $��0q�6t    �� Padding$ 0q�6   $��40��6�   $��64��6�   ��5   "   �� 5   &    �� ImageSource$5 //Cs_Gerencial;component/Imagens/Sincronizar.png��61   ��5   "   �� 5   &    �� 
TargetType" ��6,    �� Triggers 5   *   P� 5   .    P� Property �@J�IsMouseOver P� Value . . �5   2   ��  �� Property � �� �� Value
 ���� 6P   5   /   5   '   5      5       5"      5#      5$      5&      5'      