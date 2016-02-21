using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{

    public class MySequenceOfNumbers : IObservable<int>
    {
        public IDisposable Subscribe(IObserver<int> observer)
        {
            observer.OnNext(1);
            observer.OnNext(2);
            observer.OnNext(3);
            observer.OnCompleted();
            return Disposable.Empty;
        }
    }

}
