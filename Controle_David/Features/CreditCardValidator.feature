Feature: CreditCardValidator
	Validate credit card inputs

Scenario: All inputs are good
    Given all input are clear
    And credit card number is sixteen digits long
    And expiration date is at format MM/YYYY
    And cvc is three digits long
    When submit button is pressed
    Then user is on page paymentConfirmed

Scenario: Credit card number is not 16 digits long
    Given all input are clear
    And credit card number is not sixteen digits long
    And expiration date is at format MM/YYYY
    And cvc is three digits long
    When submit button is pressed
    Then user is on homePage

Scenario: Expiration is not at format MM/YYYY
    Given all input are clear
    And credit card number is sixteen digits long
    And expiration date is not at format MM/YYYY
    And cvc is three digits long
    When submit button is pressed
    Then user is on homePage

Scenario: CVC is not three digits long
    Given all input are clear
    And credit card number is sixteen digits long
    And expiration date is at format MM/YYYY
    And cvc is not three digits long
    When submit button is pressed
    Then user is on homePage

Scenario: User don't fill CVC input
    Given all input are clear
    And credit card number is sixteen digits long
	And expiration date is at format MM/YYYY
	When submit button is pressed
    Then user is on homePage

Scenario: User don't fill credit card number input
	Given all input are clear
	And expiration date is at format MM/YYYY
	And cvc is three digits long
	When submit button is pressed
	Then user is on homePage

Scenario: User don't fill expiration date input
    Given all input are clear
    And credit card number is sixteen digits long
    And cvc is three digits long
	When submit button is pressed
	Then user is on homePage

Scenario: User don't fill any input
	Given all input are clear
	When submit button is pressed
	Then user is on homePage
