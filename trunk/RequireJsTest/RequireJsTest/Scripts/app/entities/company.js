define(['entities/employee'], function(Employee) {
    console.log('Trying to fetch deps for company');
    var Company = function (company) {
        var self = this;
        self.company = company;
        self.employees = [];
    };

    Company.prototype.hireEmployee = function(name, age) {
        this.employees.push(new Employee(name, age, this.company));
    };

    return Company;
});
