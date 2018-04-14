using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IWriter
{
    string StoredMessage { get; }

    void WriteLine(string output);

    void StoreMessage(string message);
}