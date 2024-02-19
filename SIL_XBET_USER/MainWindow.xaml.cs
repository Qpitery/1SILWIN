using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SIL_XBET_USER
{
    public partial class MainWindow : Window
    {
        private const int NUM_ZONES = 6;
        private Line[] zones = new Line[NUM_ZONES];

        public MainWindow()
        {
            InitializeComponent();

            // Заполняем массив зон
            zones[0] = new Line() { X1 = 300, Y1 = 150, X2 = 240, Y2 = 30 }; // !--зона границы между -10$ и 100$ -->
            zones[1] = new Line() { X1 = 240, Y1 = 30, X2 = 75, Y2 = 20 }; //  < !--зона границы между -10$ и 1000$ -->
            zones[2] = new Line() { X1 = 75, Y1 = 20, X2 = 0, Y2 = 150 }; // < !--зона границы между 1000$ и - 300$ -->
            zones[3] = new Line() { X1 = 0, Y1 = 150, X2 = 75, Y2 = 275 }; //  !--зона границы между -300$ и 10$ -->
            zones[4] = new Line() { X1 = 75, Y1 = 275, X2 = 240, Y2 = 270 }; // < !--зона границы между 10$ и - 1000$ -->
            zones[5] = new Line() { X1 = 240, Y1 = 270, X2 = 300, Y2 = 150 }; // < !--зона границы между -1000$ и 100$ -->
        }

        private void SpinButton_Click(object sender, RoutedEventArgs e)
        {
            RandomRotateArrow();
        }

        private void RandomRotateArrow()
        {
            Random random = new Random();
            int randomRotations = random.Next(5, 10); // Случайное количество оборотов от 5 до 10
            int randomAngle = random.Next(1 * 1000, 360 * 10);

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = randomRotations * 360 + randomAngle / 10; // Учитываем случайное количество оборотов
            animation.Duration = new Duration(TimeSpan.FromSeconds(5));

            animation.Completed += (sender, e) =>
            {
                double arrowX = 150; // Получаем координату X стрелки
                double arrowY = 10; // Получаем координату Y стрелки
                int randomNumber = GetZoneNumber(arrowX, arrowY);
                MessageBox.Show($"Выпавшее число: {GetRouletteValue(randomNumber)}");
            };

            RotateTransform rotateTransform = new RotateTransform();
            rotateTransform.CenterX = 150; // Установка центра вращения по оси X в центр круга
            rotateTransform.CenterY = 150; // Установка центра вращения по оси Y в центр круга
            arrowTransform.BeginAnimation(RotateTransform.AngleProperty, animation);
        }

        private int GetZoneNumber(double x, double y)
        {
            if (IsInZone(x, y, zones[0])) return 3; // -10$
            else if (IsInZone(x, y, zones[1])) return 0; // 1000$
            else if (IsInZone(x, y, zones[2])) return 1; // -300$
            else if (IsInZone(x, y, zones[3])) return 4; // 10$
            else if (IsInZone(x, y, zones[4])) return 5; // -1000$
            else return 2; // 100$
        }

        private bool IsInZone(double x, double y, Line zone)
        {
            // Определение принадлежности точки (x, y) зоне, заданной линией
            double minX = Math.Min(zone.X1, zone.X2);
            double maxX = Math.Max(zone.X1, zone.X2);
            double minY = Math.Min(zone.Y1, zone.Y2);
            double maxY = Math.Max(zone.Y1, zone.Y2);

            return x >= minX && x <= maxX && y >= minY && y <= maxY;
        }

        public string GetRouletteValue(int number)
        {
            switch (number)
            {
                case 0:
                    return "100$";
                case 1:
                    return "1000$";
                case 2:
                    return "-300$";
                case 3:
                    return "-10$";
                case 4:
                    return "10$";
                case 5:
                    return "-1000$";
                default:
                    return "Unknown";
            }
        }
    }
}
