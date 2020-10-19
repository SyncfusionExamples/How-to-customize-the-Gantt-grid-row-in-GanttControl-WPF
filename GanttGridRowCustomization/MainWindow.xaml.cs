using Syncfusion.Windows.Controls.Gantt;
using Syncfusion.Windows.Controls.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GanttGridRowCustomization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GanttControl ganttControl;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
            ganttControl = new GanttControl
            {
                ItemsSource = (this.DataContext as ViewModel).TaskDetails,
                RowHeight = 60
            };
            ganttControl.Loaded += GanttControl_Loaded;
            this.Content = ganttControl;
        }

        private void GanttControl_Loaded(object sender, RoutedEventArgs e)
        {
            ganttControl.GanttGrid.Model.QueryCellInfo += this.Model_QueryCellInfo;
            ganttControl.GanttGrid.InternalGrid.InvalidateCells();
        }

        private void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            var lightpen = new Pen(e.Style.Background, 0);

            e.Style.Borders.Right = lightpen;
            e.Style.Borders.Left = lightpen;
            e.Style.Borders.Bottom = lightpen;
            e.Style.Borders.Top = lightpen;

            e.Style.Foreground = new SolidColorBrush(Colors.Green);
            System.Windows.Media.FontFamily fontFamily = new System.Windows.Media.FontFamily("Comic Sans MS");
            e.Style.Font = new GridFontInfo() { FontSize = 10, FontFamily = fontFamily, FontStyle = FontStyles.Italic };
            
        }
    }
}
