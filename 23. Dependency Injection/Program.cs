IClassC objectC = new ClassC();
IClassB objectB = new ClassB(objectC);
ClassA objectA = new ClassA(objectB);

objectA.ActionA();

// Kết quả:
// Action in ClassA
// Action in ClassB
// Action in ClassC


interface IClassB
{
  public void ActionB();
}



interface IClassC
{
  public void ActionC();
}


class ClassC : IClassC
{
  public void ActionC() => Console.WriteLine("Action in ClassC");
}

class ClassB : IClassB
{
  // Phụ thuộc của ClassB là ClassC
  IClassC c_dependency;

  public ClassB(IClassC classc) => c_dependency = classc;
  public void ActionB()
  {
    Console.WriteLine("Action in ClassB");
    c_dependency.ActionC();
  }
}

class ClassA
{
  // Phụ thuộc của ClassA là ClassB
  IClassB b_dependency;

  public ClassA(IClassB classb) => b_dependency = classb;
  public void ActionA()
  {
    Console.WriteLine("Action in ClassA");
    b_dependency.ActionB();
  }
}