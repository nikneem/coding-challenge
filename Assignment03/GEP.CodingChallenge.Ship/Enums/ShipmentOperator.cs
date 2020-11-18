using System;
using System.Linq;
using GEP.CodingChallenge.Ship.Contracts;
using GEP.CodingChallenge.Ship.Models;

namespace GEP.CodingChallenge.Ship.Enums
{
    public abstract class ShipmentOperator
    {
        public static ShipmentOperator PostNL;
        public static ShipmentOperator BelgioPosto;
        public static ShipmentOperator DHL;
        public static ShipmentOperator[] All;




        public abstract string Operator { get; }
        public abstract decimal MaxWeight { get; }
        public abstract string TargetCountry { get; }
        public abstract decimal WeightMultiplier { get; }
        public abstract decimal ShipmentBasePrice { get; }
        public abstract int GetShipmentDuration(IOrder order);

        public virtual decimal GetShipmentPrice(IOrder order)
        {
            return ShipmentBasePrice + WeightMultiplier * order.Weight;
        }

        public static ShipmentOperator Parse(IOrder order)
        {
            var shipmentOperator = All.FirstOrDefault(o =>
                o.TargetCountry.Equals(order.Country, StringComparison.InvariantCultureIgnoreCase) &&
                o.MaxWeight > order.Weight);

            return shipmentOperator ?? DHL;
        }

        static ShipmentOperator()
        {
            All = new[]
            {
                PostNL = new PostNLShipmentOperator(),
                BelgioPosto = new BelgioPostoShipmentOperator(),
                DHL = new DHLShipmentOperator()
            };
        }

    }

    public class PostNLShipmentOperator : ShipmentOperator
    {
        public override string Operator => "PostNL";
        public override decimal MaxWeight => 10;
        public override string TargetCountry => "Netherlands";
        public override decimal WeightMultiplier => 0;
        public override decimal ShipmentBasePrice => 6.95M;

        public override int GetShipmentDuration(IOrder order)
        {
            return 1;
        }

        public override decimal GetShipmentPrice(IOrder order)
        {
            return ShipmentBasePrice;
        }
    }
    public class BelgioPostoShipmentOperator : ShipmentOperator
    {
        public override string Operator => "BelgioPosto";
        public override decimal MaxWeight => int.MaxValue;
        public override string TargetCountry => "Belgium";
        public override decimal WeightMultiplier => 1;
        public override decimal ShipmentBasePrice => 1.95M;

        public override int GetShipmentDuration(IOrder order)
        {
            return 2;
        }

    }
    public class DHLShipmentOperator : ShipmentOperator
    {
        public override string Operator => "DHL";
        public override decimal MaxWeight => int.MaxValue;
        public override string TargetCountry => "All";
        public override decimal WeightMultiplier => 1.5M;
        public override decimal ShipmentBasePrice => 12.95M;

        public override int GetShipmentDuration(IOrder order)
        {
            return order.Weight < 10 ? 4 : 8;
        }

    }

}