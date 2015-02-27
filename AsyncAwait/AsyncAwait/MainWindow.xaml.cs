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

namespace AsyncAwait {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private Action<IMeasuringUnit, IResult> MeasureProcess2 = null;

        private void MeasurementProcess() {
            IMeasuringUnit ev = new Ev();
            IMeasuringUnit eh = new Eh();
            IResult pos = new Positioning();
            IResult str = new Straightness();

            MeasureProcess2 = new Action<IMeasuringUnit, IResult>((mu, r) => {
                double[] mv;
                mu.Measure(out mv);
                r.Add(mv);
            });

            if ( MeasureProcess2 != null ) {
                Parallel.Invoke(new []{MeasureProcess2(ev, pos)});
            }
        }


        private async void button1_Click(object sender, RoutedEventArgs e) {
            System.Diagnostics.Debug.WriteLine("Enter button1_Click");
            //await Task.Run(() => System.Threading.Thread.Sleep(10000));
            await Task.Run(() => MeasurementProcess());
            System.Diagnostics.Debug.WriteLine("Leave button1_Click");
        }

        private async void button2_Click(object sender, RoutedEventArgs e) {
            System.Diagnostics.Debug.WriteLine("Enter button2_Click");
            await Task.Run(() => System.Threading.Thread.Sleep(5000));
            System.Diagnostics.Debug.WriteLine("Leave button2_Click");
        }
    }

    public interface IMeasuringUnit {
        void Measure(out double[] values);
    }

    public interface IResult {
        void Add(double[] values);
        void Clear();
    }

    public class Ev : IMeasuringUnit {
        #region IMeasuringUnit メンバー

        public void Measure(out double[] values) {
            System.Diagnostics.Debug.WriteLine("EVが測定");
            values = new [] { 0.0, 1.0, 2.0 };
        }

        #endregion
    }

    public class Eh : IMeasuringUnit {
        #region IMeasuringUnit メンバー

        public void Measure(out double[] values) {
            System.Diagnostics.Debug.WriteLine("EHが測定");
            values = new[] { 0.0 };
        }

        #endregion
    }

    public class Positioning : IResult {
        private List<double> measuredValue = new List<double>();

        #region IResult メンバー

        public void Add(double[] values) {
            System.Diagnostics.Debug.WriteLine("Positioningに保存");
            foreach ( var v in values ) {
                measuredValue.Add(v);
            }
        }

        public void Clear() {
            measuredValue.Clear();
        }

        #endregion
    }

    public class Straightness : IResult {
        private List<double> measuredValue = new List<double>();

        #region IResult メンバー

        public void Add(double[] values) {
            System.Diagnostics.Debug.WriteLine("Positioningに保存");
            foreach ( var v in values ) {
                measuredValue.Add(v);
            }
        }

        public void Clear() {
            measuredValue.Clear();
        }

        #endregion
    }
}
