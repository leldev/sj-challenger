Feature: Powerball
Powerball is an American lottery game where 5 out of 69 numbered white balls and 1 out of 26 numbered powerballs are chosen. 
As a lottery user
I want to get unique numbers
So I can offer a lottery game

Scenario: White balls
	Given A lottery game
	When A request lottery numbers
	Then I should get unique white numbers

Scenario: Power ball
	Given A lottery game
	When A request lottery numbers
	Then I should get unique powerball number