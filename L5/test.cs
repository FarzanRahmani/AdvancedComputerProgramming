abstract class Mom
{
    string name;

    protected Mom(string name)
    {
        this.name = name;
    }
    public virtual void Delete()
    {
        System.Console.WriteLine(base.GetType()+name+"is Deleted"); 
    }
    public virtual void Move()
    {
        System.Console.WriteLine(base.GetType()+name+"is Moved"); 
    }
}
class MyDirectory : Mom
{
    List<Mom> subs = new List<Mom>();
    public void Add(params List<Mom> tt)
    {
        foreach (var item in tt)
        {
            subs.Add(item);
        }
    }

    public override void Delete()
    {
        foreach (var item in tt)
        {
            item.Delete();
        }
        base.Delete();
    }
}

class MyFile : Mom
{
    
}

class MyRar : Mom
{
    
}