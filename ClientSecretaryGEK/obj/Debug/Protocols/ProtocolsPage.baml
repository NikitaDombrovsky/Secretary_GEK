   M S B A M L   `   `   `  ����M  IClientSecretaryGEK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ClientSecretaryGEK.ProtocolsClientSecretaryGEK.Protocols  5      0    *ClientSecretaryGEK.Protocols.ProtocolsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:ClientSecretaryGEK.Protocols     5        N� Title$  ProtocolsPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��* �6   .+�5   
   �  K� ZIndex$ -2��6   ���#add3e6$��0��66   $��-1,0,1,0q�6C   .+�5      �� -   5         ��Name$ BtnAdd��5   (   $��Добавить��6   $
��Left=�69   $	��125��6T   $��32��6`   $��Bottom=�6l   $��
141,0,0,13q�6�   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $	��dgv��5      $��1��6   $��10,69,10,10q�6+   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
DatePick_1��5      $
��Left=�6�   $��	10,10,0,0q�6�   $��1��6�   $	��Top=�6�   $��39��6�   $	��271��6�      SelectedDate 6)   �� *Date+ �� Mode$ OneWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6�   �� 5   
   -   5        	 ��Name$	 
ComboGroup��5   B   
 �� DisplayMemberPath$1
 +Название_Специальности��6V   $
��Left=�6�   $��
303,14,0,0q�6�   $��1��6�   $	��Top=�6�   $	��271��6�   $��30��6�    �� SelectedItem 6   �� *StudentTableProtocols+6�   5      5      