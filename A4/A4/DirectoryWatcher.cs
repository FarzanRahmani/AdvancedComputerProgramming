using System;
using System.IO;

namespace A4
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    {
        FileSystemWatcher Watcher;
        public DirectoryWatcher(string dir)
        {
            Watcher = new FileSystemWatcher(dir);
            Watcher.EnableRaisingEvents = true;
            Watcher.Created += WaCr;
            Watcher.Deleted += WaDe;
        }

        Action<string> CreateDelegates;
        public void WaCr(object sender, FileSystemEventArgs e) 
        {
            if (CreateDelegates != null)
                CreateDelegates(e.FullPath);
        }
        Action<string> DeleteDelegates;
        public void WaDe(object sender, FileSystemEventArgs e) 
        {
            if (DeleteDelegates != null)
                DeleteDelegates(e.FullPath);
        }

        public void Register(Action<string> action,ObserverType ot)
        {
            if (ot == ObserverType.Create)
                CreateDelegates += action;
            else
                DeleteDelegates += action;
        }

        public void Unregister(Action<string> action,ObserverType ot)
        {
            if (ot == ObserverType.Create)
                CreateDelegates -= action;
            else
                DeleteDelegates -= action;
        }

        public void Dispose()
        {
            if (Watcher != null)
                Watcher.Dispose();
        }

        #region TODO
        #endregion
    }
}