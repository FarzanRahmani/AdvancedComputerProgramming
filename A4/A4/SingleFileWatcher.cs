using System;
using System.IO;

namespace A4
{

    public class SingleFileWatcher: IDisposable
    {
        private FileSystemWatcher Watcher;
        #region TODO

        public SingleFileWatcher(string fileName)
        {
            this.Watcher = new FileSystemWatcher(Path.GetDirectoryName(fileName),Path.GetFileName(fileName));
            Watcher.Changed += OnChange; // Delegates nemishe chon voroodi haye mored nazar ro nemigire
            Watcher.EnableRaisingEvents = true; // default == false
        }

        Action Delegates = null;
        void OnChange(object sender, FileSystemEventArgs e) 
        {
            if(Delegates != null)
                Delegates();
        }
        public void Register(Action a)
        {
            Delegates += a;
            // Watcher.Changed += (object sender, FileSystemEventArgs e) => a(); // nemishe chon tabe nashenakhte (lambda) ee va zaman -= nemitoone esmesho peyda kone
        }
        public void Unregister(Action a)
        {
            Delegates -= a;
            // Watcher.Changed -= (object sender, FileSystemEventArgs e) => a();  // nemishe chon tabe nashenakhte (lambda) ee va zaman -= nemitoone esmesho peyda kone
        }

        public void Dispose()
        {
            if (Watcher != null)
                Watcher.Dispose();
        }

        #endregion
    }
}