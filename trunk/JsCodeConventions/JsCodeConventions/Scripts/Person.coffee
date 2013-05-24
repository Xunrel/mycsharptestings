class Person
    constructor: (@name) ->

    getPersonName: ->
        console.log 'My name is ' + @name

class Employee extends Person
    constructor: (@name, @company) ->

    getEmployeeCompany: ->
        console.log 'I\'m working at ' + @company


person = new Person('John')
person.getPersonName()

emp = new Employee('John Doe', 'ACME Inc.')
emp.getPersonName()
emp.getEmployeeCompany()