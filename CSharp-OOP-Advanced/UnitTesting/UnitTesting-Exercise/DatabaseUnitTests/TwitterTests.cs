using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class TwitterTests
{
    private const string Message = "Test";

    [Test]
    public void SendTweetToServerShouldSendTheMessageToItsServer()
    {
        var writer = new Mock<IWriter>();
        var tweetRepo = new Mock<ITweetRepository>();
        tweetRepo.Setup(tr => tr.SaveTweet(It.IsAny<string>()));
        var microwaveOven = new MicrowaveOven(writer.Object, tweetRepo.Object);
        
        microwaveOven.SendTweetToServer(Message);
        
        tweetRepo.Verify(tr => tr.SaveTweet(It.Is<string>(s => s == Message)),
            Times.Once,
            "Message is not sent to the server");
    }

    [Test]
    public void WriteTweetShouldCallItsWriterWithTheTweetsMessage()
    {
        var writer = new Mock<IWriter>();
        writer.Setup(w => w.WriteLine(It.IsAny<string>()));
        var tweetRepo = new Mock<ITweetRepository>();
        var microwaveOven = new MicrowaveOven(writer.Object, tweetRepo.Object);
        
        microwaveOven.WriteTweet(Message);
       
        writer.Verify(w => w.WriteLine(It.Is<string>(s => s == Message)),
            $"Tweet is not given to the {typeof(MicrowaveOven)}'s writer");
    }

    [Test]
    public void ReceiveMessageShouldInvokeItsClientToWriteTheMessage()
    {
        var client = new Mock<IClient>();
        client.Setup(c => c.WriteTweet(It.IsAny<string>()));
        var tweet = new Tweet(client.Object);
        
        tweet.ReceiveMessage("Test");
        
        client.Verify(c => c.WriteTweet(It.IsAny<string>()), Times.Once,
            "Tweet doesn't invoke its client to write the message");
    }

    [Test]
    public void ReceiveMessageShouldInvokeItsClientToSendTheMessageToTheServer()
    {
        var client = new Mock<IClient>();
        client.Setup(c => c.SendTweetToServer(It.IsAny<string>()));
        var tweet = new Tweet(client.Object);
        
        tweet.ReceiveMessage("Test");
        
        client.Verify(c => c.SendTweetToServer(It.IsAny<string>()), Times.Once,
            "Tweet doesn't invoke its client to send the message to the server");
    }
}