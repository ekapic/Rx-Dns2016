using EventsObservables.DictionarySuggestService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.PlatformServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsObservables
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var moves = Observable.FromEventPattern<MouseEventArgs>(sender, "MouseMove")
                .Select(evt => evt.EventArgs.Location);
            var input = Observable.FromEventPattern<EventArgs>(this.textBox1, "TextChanged")
                .Select(evt => ((TextBox)evt.Sender).Text)
                .Do(x => Console.WriteLine("TextChanged event {0}", x))
                .Throttle(TimeSpan.FromMilliseconds(250))
                .DistinctUntilChanged();
            
            var movesSubscription = moves.Subscribe(pos => Console.WriteLine("Mouse at: " + pos)); 
            var inputSubscription = input.Subscribe(inp => Console.WriteLine("User wrote: " + inp));

            var svc = new DictServiceSoapClient("DictServiceSoap");
            var matchInDict = Observable
                .FromAsyncPattern<string, string, string, DictionaryWord[]>
                (svc.BeginMatchInDict, svc.EndMatchInDict);
            Func<string, IObservable<DictionaryWord[]>> matchInWordNetByPrefix = 
                term => matchInDict("wn", term, "prefix");

            var res = from term in input 
                      from words in matchInWordNetByPrefix(term) 
                      select words;

            var scheduler = new ControlScheduler(lst);

            res.ObserveOn(scheduler)
                .Subscribe(words =>
                {
                    lst.Items.Clear();
                    lst.Items.AddRange((from word in words select word.Word).ToArray());
                }
            );
        }
    }
}
