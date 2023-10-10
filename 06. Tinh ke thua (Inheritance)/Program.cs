/*
Phạm vi truy cập

- private : KHÔNG truy cập bên ngoài - KHÔNG truy cập từ lớp kế thừa

- proctectd: KHÔNG truy cập từ bên ngoai - ĐƯỢC truy cập bởi lớp kế thùa

*/

Cat cat = new Cat();
cat.Showlegs();
cat.Eat();
cat.ShowInfo();



/******************************************************************
*******************************************************************
Chuyển kiểu, áp kiểu giữa các đối tượng lớp thuộc cây kế thừa;

- biến thuộc lớp cha được gán thành đối tương lớp cơ sở

- biến thuộc lớp con không thể được gán thành đối tượng lớp c
*******************************************************************
*******************************************************************/
A a;
B b;
C c;


a = new B();
// b = new A(); // Error: Không thể được gán từ class cha










// SEALED class Animal // Lớp này không thể kết thừa từ lớp khác
class Animal
{
  public int Legs
  {
    set; get;
  }

  public int Weight
  {
    set; get;
  }

  public Animal()
  {
    Console.WriteLine("Khoi tao Animal");
  }

  public Animal(string name)
  {
    Console.WriteLine($"Khoi tao Animal {name}");
  }

  protected void Showlegs()
  {
    Console.WriteLine($"Legs: {Legs}");
  }
}



// class Cat kế thừa từ clas : Animal
class Cat : Animal
{

  public string Food;

  public Cat() : base("KingKong")
  {
    this.Food = "Mouse";
    this.Legs = 4;
  }

  public void Eat()
  {
    Console.WriteLine($"{Food}");
  }

  // KHai báo lại phương thức của lớp cha
  public new void Showlegs()
  {
    Console.WriteLine($"Loai meo co {this.Legs} chan");
  }

  public void ShowInfo()
  {
    base.Showlegs(); // Gọi phương thức Showlegs của class Animal
    Showlegs(); // Gọi phương thức Sho0wlegs của class Cat
  }
}





class A { }

class B : A { }

class C : B { }

// A -> B -> C

