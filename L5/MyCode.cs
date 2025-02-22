// using System.Collections.Generic;

// namespace L5
// {
//     abstract class Mom
//     {
//         string name;

//         protected Mom(string name)
//         {
//             this.name = name;
//         }
//         public virtual void Delete()
//         {
//             System.Console.WriteLine(base.GetType()+" "+name+" is Deleted"); 
//         }
//         public virtual void Move()
//         {
//             System.Console.WriteLine(base.GetType()+" "+name+" is Moved"); 
//         }
//     }
//     class MyDirectory : Mom
//     {
//         Mom[] subs = new Mom[10];

//         public MyDirectory(string name) : base(name)
//         {
//         }

//         public void Add(params Mom[] tt)
//         {
//             for (int i = 0; i < tt.Length; i++)
//             {
//                 subs[i] = tt[i];
//             }
//         }

//         public override void Delete()
//         {
//             foreach (var item in subs)
//             {
//                 if(item != null)
//                     item.Delete();
//             }
//             base.Delete();
//         }

//         public override void Move()
//         {
//             foreach (var item in subs)
//             {
//                 if(item != null)
//                     item.Move();
//             }
//             base.Move();
//         }
//     }

//     class MyFile : Mom
//     {
//         public MyFile(string name) : base(name)
//         {
//         }
//     }

//     class MyRar : Mom
//     {
//         public MyRar(string name) : base(name)
//         {
//         }
//     }
// }