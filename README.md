# A-Journey-Home
A project done for University using C# utilizing A* search with different heuristics to solve a graph traversing. 

## Overview
The main ppbjective of the problem is to traverse from one specified node on the graph to another specified one without using all of your resources.
The resources are: Time, Money and Energy.

Each path from a node to the other has shared properties with other paths such as:
* Distance
* Name
* Type

As well as properties spicefic to the path's type:
* Speed
* Waiting time

The amount of resourses used is dependent on the type of the path and the types are the following:
* Taxi route fastest and least energy consuming yet coslty.
* Bus route fast and consume moderate amount of energy with relativly low cost.
* Walking route slow and consume a lot of energy but is FREE.

there are three distinct objectives:
* Lowest cost possible without running out of energy.
* Highest energy possible without spending the available amount of money.
* fastest time possible and lowest cost possible and highest energy possible


## Implentation
The lanuage is C# and using the state space approach with A* algorithm and custom heuristics.

* The Solver folder include the algorithm clases.
* The State folder include the State and all relevant classes.
* The Station folder is for the station class in the state

## Code
`UPPERCASE_SNAKECASE` for constants.

`lowerCamelCase` for variables.

`UpperCamelCase` for public variables and class names

## Collabrators
* [Redwan Alloush](https://github.com/RedWn)
* [Hasan Mothaffar](https://github.com/HasanMothaffar)
* [Yaman Qassas](https://github.com/YamanQD)
* [Iyad Alanssary](https://github.com/IyadAlanssary)
