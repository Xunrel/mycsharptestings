define(['entities/person'], function(Person) {
    console.log('Trying to fetch deps for employee');
    var Employee = function (name, age, company) {
        var self = this;
        Person.call(self);
        self.name = name;
        self.age = age;
        self.company = company;
    };

    Employee.prototype = Object.create(Person.prototype);

    Employee.prototype.getEmployeeInfo = function() {
        return this.getPersonInfo() + " employed at: " + this.company;
    };

    return Employee;
});
