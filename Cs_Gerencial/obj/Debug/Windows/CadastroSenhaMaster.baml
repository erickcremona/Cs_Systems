   M S B A M L   `   `   `  ����  Cs_Gerencial.    (Cs_Gerencial.Windows.CadastroSenhaMaster   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Senha Master��5      $	��257��6   $	��174��6(    � Icon$3 -/Cs_Gerencial;component/Imagens/Gerencial.ico��64    � 
ResizeMode$ NoResize=�6i    � ShowInTaskbar .   � WindowStartupLocation$ CenterOwner=�6�   ���	#FFFFECCB.��5      � .+�5   
   �� -   5        $��gropBoxSenhaAtual��5   2   $��Informe a senha atual��6   $
��Left=�6K   $��66��6f   $��	10,19,0,0q�6r   $	��Top=�6�   $	��136��6�   .��5      G� -   5        $��passSenhaAtual��5      $
��Left=�60   $��	10,10,0,0q�6K   $	��Top=�6^   $	��104��6v   6�   5      �� 5	   
   $��Informe a nova senha��6   $
��Left=�61   $��66��6L   $��	10,90,0,0q�6X   $	��Top=�6k   $	��136��6�   .��5
      G� -   5        $��passSenhaNova��5
   ;    G� 	MaxLength$ 10��6   {�.   � ToolTip$4 .Mínimo de 4 dígitos e Máximo de 10 dígitos��6P   $
��Left=�6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��104��6�   6  5      �� 5   
   -   5         ��Name$ 	btnSalvar��5      {�.  $��
40,161,0,0q�66   $��0q�6J   $��0q�6V    � Cursor$
 Hand��6j   $ Salvar��6x   	 J� RenderTransformOrigin$	 0.513,0.512&�6�   $��48��6�   $	��Top=�6�   $
��Left=�6�   $��78��6  ��5      �� 5      ��5      �� 5      .R�5      �� 
���   �$��Center=�64   $��Center=�6Q   $��0q�6m   
 �� Padding$
 0q�6x   $��34��6�   $��66��6�   ��5      �� 5       �� ImageSource$/ )/Cs_Gerencial;component/Imagens/Check.png��6)   ��5      �� 5       �� 
TargetType" ��6$    �� Triggers 5   "   P� 5   &    P� Property �@J�IsMouseOver P� Value . . �5   *   ��  �� Property � �� �� Value
 ���� 6H   5   '   5      5      5       5"      5$      5%      