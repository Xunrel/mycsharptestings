;(function($) {
    $(document).ready(function () {
        var $srcBtn = $('button#showSource');
        var $srcView = $('pre#classJsSource');

        var defaultPName = 'John Doe';
        var defaultPAge = 20;
        var defaultECompany = 'ACME IT Solutions';
        var defaultEPosition = 'Trainee Developer';

        $srcView.hide();

        $srcBtn.bind('click', function() {
            $srcView.slideToggle();
        });

        // Defining person class
        var Person = function() {
            var self = this;

            self.pName = 'No name';
            self.pAge = 0;
        };

        // Defining sayHello method
        Person.prototype.sayHello = function() {
            var self = this;
            return 'Hello, my name is ' + this.pName + '. My age is ' + this.pAge;
        };

        // Defining employee class
        var Employee = function() {
            var self = this;

            // Calling base class
            Person.call(self);
            
            self.pAge = 18;
            self.eCompany = 'Currently unemployed';
            self.ePosition = 'Currently no position';
        };

        // Inheriting from person
        Employee.prototype = Object.create(Person.prototype);

        // Overriding sayHello method from person
        Employee.prototype.sayHello = function() {
            var self = this;
            return 'Hello, my name is ' + this.pName + '. ' + 
                   'My age is ' + this.pAge + '. ' + 
                   'I am working at ' + self.eCompany +
                   ' and my position is ' + self.ePosition;
        };

        // Helper variables to get buttons and inputs
        // Divs for showing info
        var $personInfo = $('div#classShowCase #person');
        var $empInfo = $('div#classShowCase #employee');
        
        // Create buttons
        var $personBtn = $('p#classDemo #createPerson');
        var $employeeBtn = $('p#classDemo #createEmployee');
        var $clearBtn = $('p#classDemo #clearInputs');

        // Input fields
        var $nameInput = $('p#classDemo #personName');
        var $ageInput = $('p#classDemo #personAge');
        var $companyInput = $('p#classDemo #empCompany');
        var $positionInput = $('p#classDemo #empPosition');

        $nameInput.val(defaultPName);
        $ageInput.val(defaultPAge);
        $companyInput.val(defaultECompany);
        $positionInput.val(defaultEPosition);

        // Hiding divs for info
        $personInfo.toggle();
        $empInfo.toggle();

        // Clears inputs
        $clearBtn.bind('click', function() {
            $nameInput.val('');
            $ageInput.val('');
            $companyInput.val('');
            $positionInput.val('');

            $personInfo
                .children('.sayHello')
                .text('');
            
            $personInfo
                .children('.toJson')
                .text('');
            
            $empInfo
                .children('.sayHello')
                .text('');
            
            $empInfo
                .children('.toJson')
                .text('');

            $personInfo.toggle(500);
            $empInfo.toggle(500);
        });

        // Binding create buttons for custom functions - here
        $personBtn.bind('click', function() {
            var person = new Person();
            if ($nameInput.val()) {
                person.pName = $nameInput.val();
            }
            if ($ageInput.val()) {
                person.pAge = parseInt($ageInput.val(), 10);
            }

            $personInfo
                .children('.sayHello')
                .text(person.sayHello());
            $personInfo
                .children('.toJson')
                .text('JSON output: ' + JSON.stringify(person));

            $personInfo.show(500);
        });

        $employeeBtn.bind('click', function() {
            var employee = new Employee();
            if ($nameInput.val()) {
                employee.pName = $nameInput.val();
            }
            if ($ageInput.val()) {
                employee.pAge = parseInt($ageInput.val(), 10);
            }
            if ($companyInput.val()) {
                employee.eCompany = $companyInput.val();
            }
            if ($positionInput.val()) {
                employee.ePosition = $positionInput.val();
            }

            $empInfo
                .children('.sayHello')
                .text(employee.sayHello());
            $empInfo
                .children('.toJson')
                .text('JSON output: ' + JSON.stringify(employee));

            $empInfo.show(500);
        });
    });
})(jQuery);
