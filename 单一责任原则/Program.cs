using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单一责任原则
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
interface IStudentWork
{
    void Teacher();//生活指导
    
}
interface IStudentWork1
{
    void Teachar();//学业指导
}

public class Teachers : IStudentWork//辅导员
{
    public void Teacher()
    {
        throw new NotImplementedException();
    }
}
class Teachars : IStudentWork1//学业导师
{
    public void Teachar()
    {
        throw new NotImplementedException();
    }
}
public class TestClass
{
    private IStudentWork studentWork;
    private IStudentWork1 studentWork1;

}