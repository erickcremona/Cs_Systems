   M S B A M L   `   `   `  ����  Cs_Gerencial5    /Cs_Gerencial.Windows.ParametrosConfigDiretorios   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$$  Configurações de Diretórios��5   	   $	��343��6-   $	��592��6:    � Icon$3 -/Cs_Gerencial;component/Imagens/Gerencial.ico��6F    � 
ResizeMode$ NoResize=�6{    � ShowInTaskbar .   � WindowStartupLocation$ CenterOwner=�6�   ���	#FFF7CB96.��5      � $��0,0,0,-1q�6   .+�5   
   �� ���	#FFEEEEEE$
��Left=�6%   $	��138��6@   $��9,13,0,0q�6M   
���   �$	��Top=�6n   $	��558��6�   �� 5   
   $+��%Diretório dos Selos Não Importados:��6   $
��Left=�6>   $��	17,17,0,0q�6Y   $	��Top=�6l    J� RenderTransformOrigin$ 0.447,0.462&�6�   �� 5   
   -   5        $$��txtDiretorioSelosNaoImportados��5      $
��Left=�68   $��23��6S   $��	22,43,0,0q�6_    �� TextWrapping$
 Wrap=�6r    �� 
IsReadOnly . $	��Top=�6�   $	��451��6�   �� 5	   
   $&�� Diretório dos Selos Importados:��6   $
��Left=�6:   $��	17,79,0,0q�6U   $	��Top=�6h   $ 0.447,0.462&�6�   �� 5
   
   -   5        $!��txtDiretorioSelosImportados��5
      $
��Left=�65   $��23��6P   $��
22,105,0,0q�6\   $
 Wrap=�6p    . $	��Top=�6�   $	��451��6�   �� 5   
   -   5         ��Name$( "btnLocalizarDiretorioNaoImportados��5      $��0q�6=   $��0q�6I   	 � Cursor$
	 Hand��6]   
 � ToolTip$1
 +Selecione a pasta dos selos não importados��6k   $ 0.614,3.118&�6�   {�. $��46��6�   $	��Top=�6�   $
��Left=�6*  $��78��6E  $��
478,31,0,0q�6P  ��5      �� 5      ��5      �� 5      .R�5      �� 
���   �$��Center=�63   $��Center=�6P   $��0q�6l    �� Padding$ 0q�6w   $��34��6�   $��48��6�   ��5      �� 5       �� ImageSource$= 7/Cs_Gerencial;component/Imagens/Localizar Diretorio.png��6)   ��5      �� 5       �� 
TargetType" ��6$    �� Triggers 5   "   P� 5   &    P� Property �@J�IsMouseOver P� Value . . �5   *   ��  �� Property � �� �� Value
 ���� 6H   5   '   5      5      5      5!      �� 5"   
   -   5        $! btnLocalizarSelosImportados��5"      $��0q�66   $��0q�6B   $
	 Hand��6V   $,
 &Selecione a pasta dos selos importados��6d   $ 0.614,3.118&�6�   {�. $��46��6�   $	��Top=�6�   $
��Left=�6  $��78��64  $��
478,94,0,0q�6?  ��5#      �� 5$      ��5&      �� 5'      .R�5(      �� 
���   �$��Center=�63   $��Center=�6P   $��0q�6l   $ 0q�6w   $��34��6�   $��48��6�   ��5)      �� 5*      $= 7/Cs_Gerencial;component/Imagens/Localizar Diretorio.png��6)   ��5,      �� 5-      " ��6$    5.   "   P� 5/   &    �@J�IsMouseOver . . �50   *   ��  � ��
 ���� 6H   51   '   53      55      56      58      �� 59   
   -   5        $ 	btnSalvar��59      $��0q�6$   $��0q�60   $
	 Hand��6D   $
 Salvar��6R   $ 0.614,3.118&�6c   {�. $��46��6�   $	��Top=�6�   $
��Left=�6�   $��89��6�   $��479,250,0,0q�6�   ��5:      �� 5;      ��5=      �� 5>      .R�5?      �� 
���   �$��Center=�63   $��Center=�6P   $��0q�6l   $ 0q�6w   $��34��6�   $��48��6�   ��5@      �� 5A      $/ )/Cs_Gerencial;component/Imagens/Check.png��6)   ��5C      �� 5D      " ��6$    5E   "   P� 5F   &    �@J�IsMouseOver . . �5G   *   ��  � ��
 ���� 6H   5H   '   5J      5L      5M      5O      �� 5P   
   ���	#FFEEEEEE$
��Left=�6%   $��89��6@   $��	9,156,0,0q�6L   
���   �$	��Top=�6n   $	��558��6�   �� 5Q   
   $��Diretório do CENIB:��6   $
��Left=�6.   $��
17,170,0,0q�6I   $	��Top=�6]   $ 0.447,0.462&�6u   �� 5R   
   -   5         ��Name$ txtDiretorioCenib��5R      $
��Left=�6-   $��23��6H   $��
22,196,0,0q�6T   $
 Wrap=�6h    . $	��Top=�6�   $	��451��6�   �� 5S   
   -   5        $ btnLocalizarCenib��5S      $��0q�6,   $��0q�68   $
	 Hand��6L   $,
 &Selecione a pasta dos selos importados��6Z   $ 0.614,3.118&�6�   {�. $��46��6�   $	��Top=�6�   $
��Left=�6  $��78��6   $��478,185,0,0q�6+  ��5T      �� 5U      ��5W      �� 5X      .R�5Y      �� 
���   �$��Center=�63   $��Center=�6P   $��0q�6l   $ 0q�6w   $��34��6�   $��48��6�   ��5Z      �� 5[      $= 7/Cs_Gerencial;component/Imagens/Localizar Diretorio.png��6)   ��5]      �� 5^      " ��6$    5_   "   P� 5`   &    �@J�IsMouseOver . . �5a   *   ��  � ��
 ���� 6H   5b   '   5d      5f      5g      5i      5k      5l      