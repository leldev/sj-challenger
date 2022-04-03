Feature: TextFormat
As a given text
I want to check if the text contains enclosing chars
So I can have well formatted text

Scenario: Check valid formatted text
	Given A <Text> with format
	When A validate if text is formatted
	Then I should get formatter <Result>

Examples:
	| Text                         | Result |
	| Hello                        | True   |
	| Hello World                  | True   |
	| <Hello>                      | True   |
	| (Hello)                      | True   |
	| [Hello]                      | True   |
	| {Hello}                      | True   |
	| {Hello                       | False  |
	| Hello}                       | False  |
	| (Hello world                 | False  |
	| Hello world)                 | False  |
	| {[Hello]}                    | True   |
	| {(Hello)}                    | True   |
	| ({[Hello]})                  | True   |
	| {([Hello]})                  | False  |
	| .[(Hello)].                  | True   |
	| .[{Hello)].                  | False  |
	| My name id ([Hello]) world   | True   |
	| {My name id ([Hello]) world} | True   |
	| {My name id ([Hello]) world] | False  |
	| {My name id ([Hello]) world  | False  |
	| ... ({Hello]] world          | False  |
	| ({Hello]] world  ...         | False  |