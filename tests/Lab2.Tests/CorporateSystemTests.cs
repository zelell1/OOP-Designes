using Itmo.ObjectOrientedProgramming.Lab2.Adresse;
using Itmo.ObjectOrientedProgramming.Lab2.Adresse.AdresseEnteties;
using Itmo.ObjectOrientedProgramming.Lab2.Adresse.AdresseEnteties.Filter;
using Itmo.ObjectOrientedProgramming.Lab2.Adresse.AdresseEnteties.Logger;
using Itmo.ObjectOrientedProgramming.Lab2.Archiver.ArchiverEnteties;
using Itmo.ObjectOrientedProgramming.Lab2.Logger;
using Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Messages.MessageStatuses;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Users.ResultType;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class CorporateSystemTests
{
    [Fact]
    public void GetMessage_UserGetMessage_MessageSavedWithUnreadStatus()
    {
        // Arrange
        string header = "Greetings";
        string body = "Hello, new workers! Congratulations on your first day at work.";
        var importance = new ImportanceLevel(5);

        var message = new Message(
            header,
            body,
            importance);

        var user = new User();

        // Act
        user.GetMessage(message);
        MessageStatus messageStatus = user.CheckStatus(message);

        // Assert
        Assert.IsType<MessageStatus.NotRead>(messageStatus);
    }

    [Fact]
    public void GetMessage_UserGetMessageAndRead_MessageSavedWithReadStatus()
    {
        // Arrange
        string header = "Greetings";
        string body = "Hello, new workers! Congratulations on your first day at work.";
        var importance = new ImportanceLevel(5);

        var message = new Message(
            header,
            body,
            importance);

        var user = new User();

        // Act
        user.GetMessage(message);
        MessageStatus messageStatus = user.CheckStatus(message);
        ReadResult readResult = user.ReadMessage(message);

        // Assert
        Assert.IsType<MessageStatus.NotRead>(messageStatus);
        Assert.IsType<ReadResult.WasRead>(readResult);
    }

    [Fact]
    public void GetMessage_UserReadMessageThatWasReadBefore_ReturnsError()
    {
        // Arrange
        string header = "Greetings";
        string body = "Hello, new workers! Congratulations on your first day at work.";
        var importance = new ImportanceLevel(5);

        var message = new Message(
            header,
            body,
            importance);

        var user = new User();

        // Act
        user.GetMessage(message);
        MessageStatus messageStatus = user.CheckStatus(message);
        ReadResult readResult = user.ReadMessage(message);
        ReadResult readResultAfterRead = user.ReadMessage(message);

        // Assert
        Assert.IsType<MessageStatus.NotRead>(messageStatus);
        Assert.IsType<ReadResult.WasRead>(readResult);
        Assert.IsType<ReadResult.AlreadyRead>(readResultAfterRead);
    }

    [Fact]
    public void GetMessage_ImportanceBelowFilter_AddresseeNotGetMessage()
    {
        // Arrange
        string header = "Greetings";
        string body = "Hello, new workers! Congratulations on your first day at work.";
        var importance = new ImportanceLevel(4);

        var message = new Message(
            header,
            body,
            importance);

        var importanceForUser = new ImportanceLevel(5);
        IAdresse baseAdresse = Substitute.For<IAdresse>();
        var filterAdresse = new AdresseImportanceFilter(importanceForUser, baseAdresse);

        // Act
        filterAdresse.GetMessage(message);

        // Assert
        baseAdresse.DidNotReceive().GetMessage(Arg.Any<Message>());
    }

    [Fact]
    public void LogMessage_WhenUserGetMessage_Logged()
    {
        // Arrange
        string header = "Greetings";
        string body = "Hello, new workers! Congratulations on your first day at work.";
        var importance = new ImportanceLevel(4);

        var message = new Message(
            header,
            body,
            importance);

        ILogger logger = Substitute.For<ILogger>();
        IAdresse baseAdresse = Substitute.For<IAdresse>();
        var adresseLogger = new AdresseLogger(
            logger,
            baseAdresse);

        // Act
        adresseLogger.GetMessage(message);

        // Assert
        logger.Received(1).Log(Arg.Any<string>());
        baseAdresse.Received(1).GetMessage(Arg.Any<Message>());
    }

    [Fact]
    public void Archive_UsingFormattingArchiver_FormatsAndArchivesMessage()
    {
        // Arrange
        string header = "Greetings";
        string body = "Hello, new workers! Congratulations on your first day at work.";
        var importance = new ImportanceLevel(4);

        var message = new Message(
            header,
            body,
            importance);

        IMessageFormatter formatter = Substitute.For<IMessageFormatter>();
        var archiver = new FormatterArchiver(formatter);

        // Act
        archiver.Archive(message);

        // Assert
        formatter.Received(1).FormatMessageHeader(Arg.Any<string>());
        formatter.Received(1).FormatMessageBody(Arg.Any<string>());
    }

    [Fact]
    public void GetMessage_TwoAddresseesOneWithImportanceFilter_GetOnce()
    {
        // Arrange
        string header = "Greetings";
        string body = "Hello, new workers! Congratulations on your first day at work.";
        var importanceFirst = new ImportanceLevel(4);
        var importanceSecond = new ImportanceLevel(3);

        var messageFirst = new Message(
            header,
            body,
            importanceFirst);

        var messageSecond = new Message(
            header,
            body,
            importanceSecond);

        var importanceForUser = new ImportanceLevel(5);
        var user = new User();
        var adresse = new AdresseUser(user);
        var filter = new AdresseImportanceFilter(importanceForUser, adresse);

        // Act
        adresse.GetMessage(messageFirst);
        filter.GetMessage(messageSecond);
        MessageStatus adresseStatus = user.CheckStatus(messageFirst);
        ReadResult filterStatus = user.ReadMessage(messageSecond);

        // Assert
        Assert.IsType<MessageStatus.NotRead>(adresseStatus);
        Assert.IsType<ReadResult.NotFound>(filterStatus);
    }
}