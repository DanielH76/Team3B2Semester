   M S B A M L   `   `   `  ����D  @TheMovies, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TheMovies.ViewsTheMovies.Views  5   	   (    "TheMovies.Views.AddEditMovieDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:TheMovies.Views     5   	     � Title$  AddEditMovieDialog��5   	   $	��287��6$   $	��414��61   .��5	      � .+�5
   
   �� $��
Filmtitel:��6   $
��Left=�6%   $��	26,28,0,0q�6@   $	��Top=�6S   �� 5   
   $��
Filmgenre:��6   $
��Left=�6%   $��	26,59,0,0q�6@   $	��Top=�6S   �� 5   
   $��Filmvarighed:��6   $
��Left=�6(   $��	26,90,0,0q�6C   $	��Top=�6V   �� 5   
   $��Filminstruktør:��6   $
��Left=�6*   $��
26,121,0,0q�6E   $	��Top=�6Y   �� 5   
   $��Filmpremieredato:��6   $
��Left=�6,   $��
26,152,0,0q�6G   $	��Top=�6[   �� 5   
   -   5         ��Name$ tbMovieTitle��5      $��148,32,47,0q�6(    �� TextWrapping$
 Wrap=�6=   $	��Top=�6Q   �� 5   
   -   5        $ tbMovieGenre��5      $��148,63,47,0q�6(   $
 Wrap=�6=   $	��Top=�6Q   �� 5   
   -   5        $ tbMovieDuration��5      $��148,94,47,0q�6+   $
 Wrap=�6@   $	��Top=�6T   �� 5   
   -   5        $ tbMovieDirector��5      $��148,125,47,0q�6+   $
 Wrap=�6A   $	��Top=�6U   �� 5   
   -   5         ��Name$ btnOK��5      $��OK��6    $��0,216,158,0q�6-   $	��Top=�6B    �� 	IsDefault$
 True��6Z   $��Right=�6k   $��78��6�   6�   �� 5   
   $��Fortryd��6   $��
0,216,58,0q�6#   $	��Top=�67    �� IsCancel$
 True��6O   $��Right=�6_   $��84��6{   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpMovieReleaseDate��5      $
��Left=�61   $��148,153,0,0q�6L   $	��Top=�6a   $	��219��6y   5      5      