using Itmo.ObjectOrientedProgramming.Lab1.Sections.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections;

public record Station : ISection
{
    private readonly Speed _maxSpeed;
    private readonly PassengerCount _passengerCountIn;
    private readonly PassengerCount _passengerCountOut;

    public Station(Speed maxSpeed, PassengerCount passengerCountIn, PassengerCount passengerCountOut)
    {
        _maxSpeed = maxSpeed;
        _passengerCountIn = passengerCountIn;
        _passengerCountOut = passengerCountOut;
    }

    public PassResult PassSection(ITrain train)
    {
        if (train.Speed > _maxSpeed)
        {
            return new PassResult.Failure();
        }

        return new PassResult.Succes(new Time((_passengerCountIn.ValueT + _passengerCountOut.ValueT) / train.PassengerFlow.ValueT));
    }
}