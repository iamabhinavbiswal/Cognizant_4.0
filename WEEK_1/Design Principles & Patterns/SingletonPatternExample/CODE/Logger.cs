using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternExample
{
    using System;

    namespace SingletonPatternExample
    {
        public class Logger
        {
            private static Logger _instance;
            private static readonly object _lock = new object();
            private Logger()
            {
                Console.WriteLine("Logger instance created.");
            }
            public static Logger GetInstance()
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                return _instance;
            }
            public void Log(string message)
            {
                Console.WriteLine($"[Log]: {message}");
            }
        }
    }

    }
