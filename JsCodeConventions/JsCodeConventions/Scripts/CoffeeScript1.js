(function() {
  var Employee, Person,
    __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  Person = (function() {
    function Person(name) {
      this.name = name;
    }

    Person.prototype.getPersonName = function() {
      return console.log(this.name);
    };

    return Person;

  })();

  Employee = (function(_super) {
    __extends(Employee, _super);

    function Employee(company) {
      this.company = company;
    }

    Employee.prototype.getEmployeeCompany = function() {
      return console.log(this.company);
    };

    return Employee;

  })(Person);

}).call(this);
