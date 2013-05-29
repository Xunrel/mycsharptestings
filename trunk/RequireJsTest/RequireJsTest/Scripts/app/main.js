require(['entities/person', 'entities/company'], function (Person, Company) {
    console.log('Trying to fetch deps for main');
    var company = new Company('busitec GmbH');

    company.hireEmployee('Henning Eiben', 37);
    company.hireEmployee('Daniel Trott', 25);
    
    for (var i = 0; i < company.employees.length; i++) {
        console.log('CompanyInfo: ' + company.employees[i].getEmployeeInfo());
        console.log('PersonInfo: ' + company.employees[i].getPersonInfo());
    }
});
