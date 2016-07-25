namespace WpfApplication1
{
    public class Model
    {
        //Base class for viewmodel
        public double X { get; set; }
        public double Y { get; set; }

        public Model(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}

