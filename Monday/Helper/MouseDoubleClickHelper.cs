﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Monday.Helper
{
    public class MouseDoubleClickHelper
    {
        public static DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command",
                                                typeof(ICommand),
                                                typeof(MouseDoubleClickHelper),
                                                new UIPropertyMetadata(CommandChanged));

        public static DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter",
                                                typeof(object),
                                                typeof(MouseDoubleClickHelper),
                                                new UIPropertyMetadata(null));

        public static void SetCommand(DependencyObject target, ICommand value)
            => target.SetValue(CommandProperty, value);

        public static void SetCommandParameter(DependencyObject target, object value)
            => target.SetValue(CommandParameterProperty, value);

        public static object GetCommandParameter(DependencyObject target)
            => target.GetValue(CommandParameterProperty);

        private static void CommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (target is Control control)
            {
                if ((e.NewValue != null) && (e.OldValue == null))
                {
                    control.MouseDoubleClick += OnMouseDoubleClick;
                }
                else if ((e.NewValue == null) && (e.OldValue != null))
                {
                    control.MouseDoubleClick -= OnMouseDoubleClick;
                }
            }
        }

        private static void OnMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            var control = sender as Control;
            var command = (ICommand)control.GetValue(CommandProperty);

            var commandParameter = control.GetValue(CommandParameterProperty);
            command.Execute(commandParameter);
        }
    }
}