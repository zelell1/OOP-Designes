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

    public PassResult PassSection(Train train)
    {
        return train.Speed.Value > _maxSpeed.Value
            ? new PassResult.Failure()
            : new PassResult.Success(new Time((_passengerCountIn.Value + _passengerCountOut.Value) / train.PassengerFlow.Value));
    }
}