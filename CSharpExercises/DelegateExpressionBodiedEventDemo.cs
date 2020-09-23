using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExercises
{
    class DelegateExpressionBodiedEventDemo
    {
        EventSubscriber subscriber;

        public DelegateExpressionBodiedEventDemo(float x, float y)
        {
            subscriber = new EventSubscriber();
            subscriber.PerformOperations(x, y);
        }

        public void DisplayEndMessage()
        {
            Console.WriteLine("The operations are over!");
        }
    }

    class EventSubscriber
    {
        private EventPublisher eventPublisher;
        public EventSubscriber()
        {
            eventPublisher = new EventPublisher();
            eventPublisher.MessageDisplayEvent += OnOperationsToBePerformed;
        }

        private void OnOperationsToBePerformed()
        {
            Console.WriteLine("The basic operations are about to be performed:");
        }

        public void PerformOperations(float x, float y)
        {
            eventPublisher.PerormOperations(x, y);
        }
    }

    class EventPublisher
    {
        public delegate void OperationPerformerDelegate(float x, float y);

        public delegate void MessageDisplayerDelegate();
        public event MessageDisplayerDelegate MessageDisplayEvent;

        private void Add(float x, float y) => Console.WriteLine($"{x} + {y} = {x + y}");
        private void Subtract(float x, float y) => Console.WriteLine($"{x} - {y} = {x - y}");
        private void Multiply(float x, float y) => Console.WriteLine($"{x} * {y} = {x * y}");
        private void Divide(float x, float y) => Console.WriteLine($"{x} / {y} = {x / y}");

        public void PerormOperations(float x, float y)
        {

            OperationPerformerDelegate del = new OperationPerformerDelegate(Add);
            del += new OperationPerformerDelegate(Subtract);
            del += new OperationPerformerDelegate(Multiply);
            del += new OperationPerformerDelegate(Divide);

            MessageDisplayEvent();
            del(x, y);
        }
    }

}
