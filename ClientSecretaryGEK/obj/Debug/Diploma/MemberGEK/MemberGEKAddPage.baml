   M S B A M L   `   `   `  ����M  IClientSecretaryGEK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:ClientSecretaryGEK.Diploma.MemberGEK$ClientSecretaryGEK.Diploma.MemberGEK  5      ;    5ClientSecretaryGEK.Diploma.MemberGEK.MemberGEKAddPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:ClientSecretaryGEK.Diploma.MemberGEK     5        N� Title$  MemberGEKAddPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   .+�5   
   �� $��Место работы��6   $��30��6(   $	��100��64   �� 5   
   $��Должность��6   $��1��6%   $��30��62   $	��100��6>   �� 5   
   $��Личные данные��6   $��2��6)   $��30��66   $	��100��6B   �� 5   
   $ ��Специальность��6   $��3��6)   $��30��66   $	��100��6B   �� 5   
   -   5         ��Name$ ComboSurmane��5   g   $��1��6>   $��2��6N   $��30��6[   $��0,0,10,0q�6~    �� DisplayMemberPath$ Фамилия��6�    �� SelectedItem 6   �� *MemberGEKTableALL+6�   �� 5   
   -   5        $ ComboSP��5   g   $��1��6>   $��3��6N   $��30��6[   $��0,0,10,0q�6y   $1 +Название_Специальности��6�    6   �� *MemberGEKTableALL+6�   �� 5!   
   -   5         ��Name$ Work_PM��5!      $��1��6#   $��30��64   $��0,0,10,0q�6@   �� 5"   
   -   5        $ Post_PM��5"      $��1��6#   $��1��63   $��30��6@   $��0,0,10,0q�6L   �� 5#   
   -   5        $��BtnAdd��5#   o   $��Сохранить��6   $��2��6%   $��9��69   $��0��6F   $	��200��6W   $��25��6c   6}   � 5$   
    K� ZIndex$ -2��6   ���#add3e6$��9��66   $��2��6C   5%      5&      