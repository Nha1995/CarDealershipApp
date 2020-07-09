﻿using CarDealershipApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Repository
{
    public interface ICarRepository
    {
        int Count();

        LinkedList<Car> List();

        bool Add(Car car);

        void Sell(Car car, Client client);

        Car GetCarByNumber(string carNumber);
    }
}