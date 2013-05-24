(function() {
  var Employee, Person, emp, person,
    __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  Person = (function() {
    function Person(name) {
      this.name = name;
    }

    Person.prototype.getPersonName = function() {
      return console.log('My name is ' + this.name);
    };

    return Person;

  })();

  Employee = (function(_super) {
    __extends(Employee, _super);

    function Employee(name, company) {
      this.name = name;
      this.company = company;
    }

    Employee.prototype.getEmployeeCompany = function() {
      return console.log('I\'m working at ' + this.company);
    };

    return Employee;

  })(Person);

  person = new Person('John');

  person.getPersonName();

  emp = new Employee('John Doe', 'ACME Inc.');

  emp.getPersonName();

  emp.getEmployeeCompany();

}).call(this);
