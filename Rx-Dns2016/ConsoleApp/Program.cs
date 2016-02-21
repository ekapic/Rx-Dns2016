using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo 1: Hello World
            //IObservable<char> obs = "Hello, world!".ToObservable();
            //obs.Subscribe(x => Console.WriteLine(x));

            // Ejemplo 2: IObservable, IObserver
            //var numbers = new MySequenceOfNumbers();
            //var observer = new MyConsoleObserver<int>();
            //numbers.Subscribe(observer);

            // Ejemplo 3: Subject
            //var subject = new Subject<string>();
            //subject.Subscribe(value => Console.WriteLine(value));
            //subject.OnNext("a");
            //subject.OnNext("b");
            //subject.OnNext("c");

            // Ejemplo 4: ReplaySubject
            //var subject = new ReplaySubject<string>();
            //subject.OnNext("a");
            //subject.Subscribe(value => Console.WriteLine(value));
            //subject.OnNext("b");
            //subject.OnNext("c");

            // Ejemplo 4: ReplaySubject con buffer
            //var bufferSize = 2;
            //var subject = new ReplaySubject<string>(bufferSize);
            //subject.OnNext("a");
            //subject.OnNext("b");
            //subject.OnNext("c");
            //subject.Subscribe(Console.WriteLine);
            //subject.OnNext("d");

            // Ejemplo 5: Gestión del ciclo de vida y errores
            //var values = new Subject<int>();
            //values.Subscribe(
            //    value => 
            //        Console.WriteLine("1st subscription received {0}", value),
            //    ex => 
            //        Console.WriteLine("Caught an exception : {0}", ex)
            //);
            //values.OnNext(0);
            //values.OnError(new Exception("Dummy exception"));

            // Ejemplo 6: Gestión del ciclo de vida de una suscripción
            //var values = new Subject<int>();
            //var firstSubscription = values.Subscribe(value =>
            //    Console.WriteLine("1st subscription received {0}", value));
            //var secondSubscription = values.Subscribe(value =>
            //    Console.WriteLine("2nd subscription received {0}", value));
            //values.OnNext(0);
            //values.OnNext(1);
            //values.OnNext(2);
            //values.OnNext(3);
            //firstSubscription.Dispose();
            //Console.WriteLine("Disposed of 1st subscription");
            //values.OnNext(4);
            //values.OnNext(5);

            // Ejemplo 7: Creación de secuencias
            //var range = Observable.Range(10, 15);
            //range.Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));

            // Ejemplo 8: Creación de secuencias
            //var interval = Observable.Interval(TimeSpan.FromMilliseconds(250));
            //interval.Subscribe(
            //Console.WriteLine,
            //() => Console.WriteLine("completed"));

            // Ejemplo 9: Creación de secuencias desde eventos
            //var metronome = new Metronome();
            //var metronomeTicks = Observable.FromEventPattern<Metronome.TickHandler, TimeOfTick>(
            //   h => metronome.Tick += h,
            //   h => metronome.Tick -= h
            //);
            //// El scheduler es necesario para poder observar el evento en otro thread
            //var scheduler = NewThreadScheduler.Default;
            //metronomeTicks
            //    .SubscribeOn(scheduler)
            //    .Subscribe(x => Console.WriteLine(x.EventArgs.Time));
            //metronome.Start();

            // Ejemplo 10: Filtros
            //var oddNumbers = Observable.Range(0, 10)
            //.Where(i => i % 2 == 0)
            //.Subscribe(
            //Console.WriteLine,
            //() => Console.WriteLine("Completed"));

            // Ejemplo 11: Distinct
            //var subject = new Subject<int>();
            //var distinct = subject.Distinct();
            //subject.Subscribe(
            //i => Console.WriteLine("{0}", i),
            //() => Console.WriteLine("subject.OnCompleted()"));
            //distinct.Subscribe(
            //i => Console.WriteLine("distinct.OnNext({0})", i),
            //() => Console.WriteLine("distinct.OnCompleted()"));
            //subject.OnNext(1);
            //subject.OnNext(2);
            //subject.OnNext(3);
            //subject.OnNext(1);
            //subject.OnNext(1);
            //subject.OnNext(4);
            //subject.OnCompleted();

            // Ejemplo 12: DistinctUntilChanged
            //var subject = new Subject<int>();
            //var distinct = subject.DistinctUntilChanged();
            //subject.Subscribe(
            //i => Console.WriteLine("{0}", i),
            //() => Console.WriteLine("subject.OnCompleted()"));
            //distinct.Subscribe(
            //i => Console.WriteLine("distinct.OnNext({0})", i),
            //() => Console.WriteLine("distinct.OnCompleted()"));
            //subject.OnNext(1);
            //subject.OnNext(2);
            //subject.OnNext(3);
            //subject.OnNext(1);
            //subject.OnNext(1);
            //subject.OnNext(4);
            //subject.OnCompleted();

            // Ejemplo 13: SkipUntil
            //var subject = new Subject<int>();
            //var otherSubject = new Subject<Unit>();
            //subject
            //.SkipUntil(otherSubject)
            //.Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));
            //subject.OnNext(1);
            //subject.OnNext(2);
            //subject.OnNext(3);
            //otherSubject.OnNext(Unit.Default);
            //subject.OnNext(4);
            //subject.OnNext(5);
            //subject.OnNext(6);
            //subject.OnNext(7);
            //subject.OnNext(8);
            //subject.OnCompleted();

            // Ejemplo 14: GroupBy
            //var source = Observable.Interval(TimeSpan.FromSeconds(0.1)).Take(10);
            //var group = source.GroupBy(i => i % 3);
            //group.Subscribe(
            //    grp =>
            //        grp.Min().Subscribe(
            //            minValue =>
            //                Console.WriteLine("{0} min value = {1}", grp.Key, minValue)
            //        ),
            //    () => Console.WriteLine("Completed")
            //);

            // Ejemplo 15: Select
            //var source = Observable.Range(1, 5);
            //var output = source.Select(i => (char)(i + 64));
            //output.Subscribe(x => Console.WriteLine(x));
            
            // Ejemplo 16: SelectMany
            //var source = Observable.Range(1, 3)
            //    .SelectMany(i => Observable.Range(1, i));
            //source.Subscribe(x => Console.WriteLine(x));

            // Ejemplo 17: Min & Average
            //var numbers = new Subject<int>();
            //numbers.Subscribe(x => Console.WriteLine("Numbers: {0}", x));
            //numbers.Min().Subscribe(x => Console.WriteLine("Min: {0}", x));
            //numbers.Average().Subscribe(x => Console.WriteLine("Average: {0}", x));
            //numbers.OnNext(1);
            //numbers.OnNext(2);
            //numbers.OnNext(3);
            //numbers.OnCompleted();

            // Ejemplo 18: Scan & Aggregate
            //var numbers = new Subject<int>();
            //var scan = numbers.Scan(0, (acc, current) => acc + current);
            //var aggregate = numbers.Aggregate(0, (acc, current) => acc + current);
            //numbers.Subscribe(x => Console.WriteLine("Numbers: {0}", x));
            //scan.Subscribe(x => Console.WriteLine("Scan: {0}", x));
            //aggregate.Subscribe(x => Console.WriteLine("Aggregate: {0}", x));
            //numbers.OnNext(1);
            //numbers.OnNext(2);
            //numbers.OnNext(3);
            //numbers.OnCompleted();

            // Ejemplo 19: Concat
            //var s1 = new Subject<int>();
            //var s2 = new Subject<int>();
            //var result = Observable.Concat(s1, s2);
            //result.Subscribe(
            //    Console.WriteLine,
            //    () => Console.WriteLine("Completed")
            //);
            //s1.OnNext(1);
            //s1.OnNext(2);            
            //s1.OnCompleted();
            //s2.OnNext(3);
            //s2.OnNext(4);            
            //s2.OnCompleted();


            // Ejemplo 20: Merge
            //var s1 = new Subject<int>();
            //var s2 = new Subject<int>();
            //var result = Observable.Merge(s1, s2);
            //result.Subscribe(
            //    Console.WriteLine,
            //    () => Console.WriteLine("Completed")
            //);
            //s1.OnNext(1);
            //s2.OnNext(3);
            //s1.OnNext(2);
            //s2.OnNext(4);
            //s1.OnCompleted();
            //s2.OnCompleted();

            // Ejemplo 21: Scheduler por defecto
            //var clock = Observable.Interval(TimeSpan.FromSeconds(1));
            //clock.Subscribe(now =>
            //    {
            //        Console.WriteLine("Clock: {0}", now);
            //    }
            //);

            // Ejemplo 22: Scheduler explícito
            //var scheduler = NewThreadScheduler.Default;
            //var clock = Observable.Interval(TimeSpan.FromSeconds(1), scheduler);
            //clock.Subscribe(now =>
            //    {
            //        Console.WriteLine("Clock: {0}", now);
            //    }
            //);

            // Ejemplo 23: SubscribeOn & ObserveOn
            //Thread.CurrentThread.Name = "Main";
            //IScheduler thread1 = new NewThreadScheduler(x => new Thread(x) { Name = "Thread1" });
            //IScheduler thread2 = new NewThreadScheduler(x => new Thread(x) { Name = "Thread2" });
            //Observable.Create<int>(o =>
            //{
            //    Console.WriteLine("Subscribing on " + Thread.CurrentThread.Name);
            //    o.OnNext(1);
            //    return Disposable.Create(() => { });
            //})
            //.SubscribeOn(thread1)
            //.ObserveOn(thread2)
            //.Subscribe(x => Console.WriteLine("Observing '" + x + "' on " + Thread.CurrentThread.Name));

            

            // Esperar el INTRO para acabar el programa
            Console.ReadLine();
        }
    }
}
