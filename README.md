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
![Alt text](image-2.png)

#### After Text Change
![Alt text](image-3.png)