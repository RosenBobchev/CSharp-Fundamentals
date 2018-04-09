using System;
using System.Collections.Generic;
using System.Text;

public interface IClient
{
    void WriteTweet(string message);

    void SendTweetToServer(string message);
}