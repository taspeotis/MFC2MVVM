using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using MahApps.Metro.Controls;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Vestris.ResourceLib;

namespace Mfc2Mvvm.Module.Dialog2Wpf
{
    [ModuleExport(typeof (Dialog2WpfModule))]
    public sealed class Dialog2WpfModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public Dialog2WpfModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            using (var resourceInfo = new ResourceInfo())
            {
                resourceInfo.Load(@"C:\Temp\App.exe");

                var names = new List<string>();

                foreach (var dialogResource in resourceInfo[Kernel32.ResourceTypes.RT_DIALOG].Cast<DialogResource>())
                {
                    if (dialogResource.Name.Id != (IntPtr) 222)
                        continue;

                    var dialogTemplate = dialogResource.Template;

                    //if (dialogTemplate.Controls.Count < 30)
                        //continue;

                    var size = GetSize(dialogTemplate, dialogTemplate.cx, dialogTemplate.cy);

                    var canvas = new Canvas {Width = size.Width, Height = size.Height};

                    var window = new MetroWindow
                    {
                        Title = dialogTemplate.Caption,
                        Content = canvas,
                        SizeToContent = SizeToContent.WidthAndHeight,
                        WindowStartupLocation = WindowStartupLocation.CenterOwner
                    };

                    foreach (var control in dialogTemplate.Controls)
                    {
                        var size2 = GetSize(dialogTemplate, control.cx, control.cy);
                        var size3 = GetSize(dialogTemplate, control.x, control.y);

                        switch (control.ControlClass)
                        {
                            case User32.DialogItemClass.Button:
                                var button = new Button
                                {
                                    Content = control.CaptionId?.ToString(),
                                    Width = size2.Width,
                                    Height = size2.Height,
                                    Margin = new Thickness(size3.Width, size3.Height, 0, 0)
                                };

                                canvas.Children.Add(button);

                                continue;

                            case User32.DialogItemClass.Edit:
                                var edit = new TextBox
                                {
                                    Text = control.CaptionId?.ToString(),
                                    Width = size2.Width,
                                    Height = size2.Height,
                                    Margin = new Thickness(size3.Width, size3.Height, 0, 0)
                                };

                                canvas.Children.Add(edit);

                                continue;

                            case User32.DialogItemClass.Static:
                                var label = new TextBlock
                                {
                                    Text = control.CaptionId?.ToString(),
                                    Width = size2.Width,
                                    Height = size2.Height,
                                    Margin = new Thickness(size3.Width, size3.Height, 0, 0)
                                };

                                canvas.Children.Add(label);

                                continue;

                            case User32.DialogItemClass.ComboBox:

                                var comboBox = new ComboBox
                                {
                                    Width = size2.Width,
                                    Height = 21,
                                    MaxDropDownHeight = size2.Height,
                                    Margin = new Thickness(size3.Width, size3.Height, 0, 0)
                                };

                                canvas.Children.Add(comboBox);

                                continue;

                            default:
                                var z = 10;
                                continue;
                        }
                    }

                    var resourceDictionaries = window.Resources.MergedDictionaries;

                    resourceDictionaries.Add(new ResourceDictionary
                    {
                        Source = new Uri("pack://application:,,,/MahApps.Metro;component/Styles/VS/Colors.xaml")
                    });

                    resourceDictionaries.Add(new ResourceDictionary
                    {
                        Source = new Uri("pack://application:,,,/MahApps.Metro;component/Styles/VS/Styles.xaml")
                    });

                    window.Show();

                    //var z = XamlWriter.Save(window);

                }


            }
        }

        private static Size GetSize(DialogTemplateBase dialogTemplate, short x, short y)
        {
            return new Size(x*374.0/247, y*262.0/159);

            /*
            Might just have to pinvoke...

            var typeName = dialogTemplate.TypeFace ?? "MS Shell Dlg";
            var pointSize = dialogTemplate.PointSize != 0 ? dialogTemplate.PointSize : 8;

            // http://support.microsoft.com/kb/145994
            // http://stackoverflow.com/a/9266288/242520
            var typeface = new Typeface(typeName);

            var formattedText = new FormattedText("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz",
                CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, typeface, pointSize, Brushes.Black);

            var width = (int)formattedText.Width;
            var height = (int) formattedText.Height;
            var baseUnitX = (width/26 + 1)/2;
            var baseUnitY = height;

            //baseUnitX *= 5.0/4;
            //baseUnitY *= 4.0/3;

            /*return new Size(
                (int) Math.Round((x*baseUnitX)/4, MidpointRounding.AwayFromZero),
                (int) Math.Round((y*baseUnitY)/8, MidpointRounding.AwayFromZero));*/

            //return new Size((x*baseUnitX)/4, (y*baseUnitY)/8);
        }
    }
}