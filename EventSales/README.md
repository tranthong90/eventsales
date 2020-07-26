# EventSales

This is a system that allows for users to apply discount to events

## Getting Started

Live demo: https://eventsales.azurewebsites.net/
The repository lives here: <https://github.com/tranthong90/eventsales>

Clone the repository

```bash
git clone https://github.com/tranthong90/eventsales
```

### Prerequisites

* NetCore 3.1:         <https://dotnet.microsoft.com/download>
* Visual Studio:       <https://visualstudio.microsoft.com/downloads/>

## Run the project locally

1. Clone the repo
2. Go the folder and run EventSales.sln

## My approach to the problem

Right now, I can see we have 2 type of discounts:

1. Group Discount (Buy x number of events for this y amount)
2. Next Item Percentage discount (Buy x number of events, the next will get y % discount)

So I build an abstract class called "BaseDiscount" and have 2 children GroupDiscount and NextItemDiscount which each has thier own way of calculate the discount amount.

I also have a UnitTest project to check my calculation.


In term of persist data and defining the discounts

I use a master data source which is stored in App_Data folder.
In there I have a json file to define the events and thier discount.

Giving the time for this test, I didn't use a proper database.
