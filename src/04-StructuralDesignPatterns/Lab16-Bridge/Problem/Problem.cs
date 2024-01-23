public class Problem
{
    class Shape
    {
        public string Name { get; set; }
    }

    class Circle : Shape { }
    class Square : Shape { }

    class RedCircle : Circle { }
    class RedSquare : Square { }
    class BlueCircle : Circle { }
    class BlueSquare : Square { }

    //Adding a new variant will create dozen of classes
    class RedMetalCircle : Circle { }
    class RedMetalSquare : Square { }
    class BlueMetalCircle : Circle { }
    class BlueMetalSquare : Square { }
}
