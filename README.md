# BehaviorHelper

## Purpose

Helper that can assist in behavior processing of View in MVVM patterns

## Example

### View
```xml
<Window x:Class="MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:FrameworkTest"
        xmlns:viewModels="clr-namespace:ViewModels"
        xmlns:helper="clr-namespace:BehaviorHelper;assembly=BehaviorHelper"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">

    <Window.Resources>
        <viewModels:ViewModel x:Key="viewModel"/>
    </Window.Resources>
    
    <Grid DataContext="{Binding Source={StaticResource viewModel}}">
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        
        <TextBox Grid.Row="0" Width="200" Height="200"
                 VerticalAlignment="Center"
                 HorizontalAlignment="Center"
                 helper:TextBox_CheckForChangeBehavior.Color="Red"
                 Text="{Binding Name}"/>

        <Button Grid.Row="1"
                Content="click"
                Command="{Binding Click}"/>
    </Grid>
</Window>
```

### Behavior


```c#
public class TextBox_CheckForChangeBehavior
{
    // Property
   public static readonly DependencyProperty CheckForChangeProperty = DependencyProperty.RegisterAttached("CheckForChange", typeof(Brush), typeof(TextBox_CheckForChangeBehavior),
                                                                      new UIPropertyMetadata(new SolidColorBrush(Colors.Black), ApplyChangeEvent));

    ...

    public static void SetColor(DependencyObject obj, Brush value)
    {
        obj.SetValue(CheckForChangeProperty, value);
    }

    ...
}
```


### Result

#### Before Text Change
![Before](https://github.com/donpp237/BehaviorHelper/assets/137162873/98dd5425-ca9d-4a79-a0cb-1bf1b8741caa)

#### After Text Change
![After](https://github.com/donpp237/BehaviorHelper/assets/137162873/69aa0cb6-4ee1-4381-b815-a716702f68f4)
