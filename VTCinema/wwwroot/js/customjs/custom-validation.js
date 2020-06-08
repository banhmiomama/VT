//validation settings in formvalidation page
'use strict'
$('.ui.form1').form({
    fields: {
        name: {
            identifier: 'name',
            rules: [{
                type: 'empty',
                prompt: 'Please enter your name'
            }]
        },
        skills: {
            identifier: 'skills',
            rules: [{
                type: 'minCount[2]',
                prompt: 'Please select at least two skills'
            }]
        },
        branchwarehouse: {
            identifier: 'branchwarehouse',
            rules: [{
                type: 'minCount[1]',
                prompt: 'Please select at least two skills'
            }]
        },
        gender: {
            identifier: 'gender',
            rules: [{
                type: 'empty',
                prompt: 'Please select a gender'
            }]
        },
        username: {
            identifier: 'username',
            rules: [{
                type: 'empty',
                prompt: 'Please enter a username'
            }]
        },
        password: {
            identifier: 'password',
            rules: [{
                type: 'empty',
                prompt: 'Please enter a password'
            }, {
                type: 'minLength[6]',
                prompt: 'Your password must be at least {ruleValue} characters'
            }]
        },
        terms: {
            identifier: 'terms',
            rules: [{
                type: 'checked',
                prompt: 'You must agree to the terms and conditions'
            }]
        }
    }
});
$('.ui.form2').form({
    fields: {
        field1: {
            rules: [{
                type: 'empty'
            }]
        },
        field2: {
            rules: [{
                type: 'exactly[dog]',
                prompt: '{name} is set to "{value}" that is totally wrong. It should be {ruleValue}'
            }]
        }
    }
});

// AppointmentDetail, CustomerDetail,EmplopyeeDetail,UserDetail
// Customer HistoryDetail,Customer StatusDetail,Customer TabDetail,Customer TreatmentDetail,Customer PaymentDetail
// AccountDetail
// pageServiceTypeDetail,pageServiceDetail
// pageProductTypeDetail,pageProductDetail
// pageSupplierDetail,pageInputDetail, pageOutputDetail
// pageCustomerCareDetail
$('.ui.form20').form({
    inline: true,
    on: 'blur',
    fields: {
        Ages: {
            identifier: 'Ages',
            rules: [{
                type: 'empty',
                color: 'red',
                prompt: 'Vu iLòng Nhập Tuổi '
            }]
        },
        Name: {
            identifier: 'Name',
            rules: [{
                type: 'empty',
                color: 'red',
                prompt: 'Vui Lòng Nhập Lứa Tuổi'
                } ]
        }
    }
});


$('.ui.form22').form({
    Sub_Title: {
        identifier: 'Sub_Title',
        rules: [{
            type: 'empty',
            color: 'red',
            prompt: 'Please enter a Sub Title'
        }]
    }     , 
    Note: {
        identifier: 'Note',
        rules: [{
            type: 'empty',
            color: 'red',
            prompt: 'Please enter a Note'
        }]
    }
});

$('.ui.form3').form({
    fields: {
        search: {
            identifier: 'appointment',
            rules: [{
                type: 'empty',
                prompt: 'Please enter appointment'
            }]
        },
        reasonReturn: {
            identifier: 'reasonReturn',
            rules: [{
                type: 'empty',
                prompt: 'Please enter reasonReturn'
            }]
        },
        branch: {
            identifier: 'branch',
            rules: [{
                type: 'empty',
                prompt: 'Please enter branch'
            }]
        },
        tokenServiceCare: {
            identifier: 'tokenServiceCare',
            rules: [
                {
                    type: 'minCount[1]',
                    prompt: 'Please select at least 1 value'
                }
            ]
        },
        doctor: {
            identifier: 'doctor',
            rules: [{
                type: 'empty',
                prompt: 'Please enter doctor'
            }]
        },
        skills: {
            identifier: 'skills',
            rules: [{
                type: 'minCount[1]',
                prompt: 'Please select at least two skills'
            }]
        },
        gender: {
            identifier: 'gender',
            rules: [{
                type: 'empty',
                prompt: 'Please select a gender'
            }]
        },
        State: {
            identifier: 'State',
            rules: [{
                type: 'empty',
                prompt: 'Please select a gender'
            }]
        },
        Employee: {
            identifier: 'Employee',
            rules: [{
                type: 'empty',
                prompt: 'Please select a gender'
            }]
        },
        GroupUser: {
            identifier: 'GroupUser',
            rules: [{
                type: 'empty',
                prompt: 'Please select a gender'
            }]
        },

        username: {
            identifier: 'username',
            rules: [{
                type: 'empty',
                prompt: 'Please enter a username'
            }]
        },
        password: {
            identifier: 'password',
            rules: [{
                type: 'empty',
                prompt: 'Please enter a password'
            }, {
                type: 'minLength[6]',
                prompt: 'Your password must be at least {ruleValue} characters'
            }]
        },
        terms: {
            identifier: 'terms',
            rules: [{
                type: 'checked',
                prompt: 'You must agree to the terms and conditions'
            }]
        },
        emailValidate: {
            identifier: 'emailValidate',
            rules: [
                {
                    type: 'emailValidate',
                    prompt: 'Please enter a valid e-mail'
                }
            ]
        },
        phonenumber: {
            identifier: 'phonenumber',
            rules: [
                {
                    type: 'minLength[8]',
                    prompt: 'Please enter exactly 8 characters'
                },
                {
                    type: 'maxLength[16]',
                    prompt: 'Please enter exactly 12 characters'
                },
                {
                    type: 'number',
                    prompt: 'Please enter number'
                }
            ]
        },
        phonenumberNotMain: {
            identifier: 'phonenumberNotMain',
            rules: [
                {
                    type: 'number',
                    prompt: 'Please enter number'
                }
            ]
        },
        codewarehouse: {
            identifier: 'codewarehouse',
            rules: [
                {
                    type: 'exactLength[5]',
                    prompt: 'Please enter exactly 10 characters'
                },
                {
                    type: 'empty',
                    prompt: 'Please enter number'
                }
            ]
        },
        name: {
            identifier: 'name',
            rules: [{
                type: 'empty',
                prompt: 'Please enter your name'
            }]
        },
        source: {
            identifier: 'source',
            rules: [{
                type: 'empty',
                prompt: 'Please enter source'
            }]
        },
        language: {
            identifier: 'language',
            rules: [{
                type: 'empty',
                prompt: 'Please enter language'
            }]
        },
        department: {
            identifier: 'department',
            rules: [{
                type: 'empty',
                prompt: 'Please enter department'
            }]
        },
        cmnd: {
            identifier: 'cmnd',
            rules: [
                {
                    type: 'number',
                    prompt: 'Please enter number'
                }
            ]
        },
        basicsalary: {
            identifier: 'basicsalary',
            rules: [
                {
                    type: 'number',
                    prompt: 'Please enter number'
                },
                {
                    type: 'empty',
                    prompt: 'Please enter number'
                }
            ]
        },
        salaryagreed: {
            identifier: 'salaryagreed',
            rules: [
                {
                    type: 'number',
                    prompt: 'Please enter number'
                },
                {
                    type: 'empty',
                    prompt: 'Please enter number'
                }
            ]
        },
        employee: {
            identifier: 'employee',
            rules: [{
                type: 'empty',
                prompt: 'Please enter employee'
            }]
        },
        userGroup: {
            identifier: 'userGroup',
            rules: [{
                type: 'empty',
                prompt: 'Please enter user group'
            }]
        },
        historyType: {
            identifier: 'historyType',
            rules: [{
                type: 'empty',
                prompt: 'Please enter history type'
            }]
        },
        complainType: {
            identifier: 'complainType',
            rules: [{
                type: 'empty',
                prompt: 'Please enter complain type'
            }]
        },
        statusType: {
            identifier: 'statusType',
            rules: [{
                type: 'empty',
                prompt: 'Please enter status type'
            }]
        },
        discountType: {
            identifier: 'discountType',
            rules: [{
                type: 'empty',
                prompt: 'Please enter status type'
            }]
        },
        serviceTab: {
            identifier: 'serviceTab',
            rules: [{
                type: 'empty',
                prompt: 'Please enter service'
            }]
        },
        numberService: {
            identifier: 'numberService',
            rules: [{
                type: 'integer[1..100]',
                prompt: 'Please enter number of unit'
            }]
        },
        discountForCust: {
            identifier: 'discountForCust',
            rules: [{
                type: 'integer[0..100]',
                prompt: 'Please enter number of unit'
            }]
        },

        discountPercent: {
            identifier: 'discountPercent',
            rules: [{
                type: 'integer[1..100]',
                prompt: 'Please enter number of unit'
            }]
        },
        discountAmount: {
            identifier: 'discountAmount',
            rules: [{
                type: 'regExp[/^[0-9,]{0,12}$/]',
                prompt: 'Please enter amount discount'
            }]
        },
        moneyAmount: {
            identifier: 'moneyAmount',
            rules: [{
                type: 'regExp[/^[0-9,]{0,12}$/]',
                prompt: 'Please enter money Amount'
            }]
        },
        discountOther: {
            identifier: 'discountOther',
            rules: [{
                type: 'regExp[/^[0-9,]{0,12}$/]',
                prompt: 'Please enter other discount'
            }]
        },
        accountType: {
            identifier: 'accountType',
            rules: [{
                type: 'empty',
                prompt: 'Please enter account type'
            }]
        },
        accountMethod: {
            identifier: 'accountMethod',
            rules: [{
                type: 'empty',
                prompt: 'Please enter account method'
            }]
        },
        accountAmount: {
            identifier: 'accountAmount',
            rules: [{
                type: 'empty',
                prompt: 'Please enter value'
            }, {
                type: 'regExp[/^[0-9,]{0,12}$/]',
                prompt: 'Please enter account amount'
            }]
        },
        productType: {
            identifier: 'productType',
            rules: [{
                type: 'empty',
                prompt: 'Please enter product type'
            }]
        },
        productUnit: {
            identifier: 'productUnit',
            rules: [{
                type: 'empty',
                prompt: 'Please enter product type'
            }]
        },
        serviceType: {
            identifier: 'serviceType',
            rules: [{
                type: 'empty',
                prompt: 'Please enter service type'
            }]
        },
        unitServiceType: {
            identifier: 'unitServiceType',
            rules: [{
                type: 'empty',
                prompt: 'Please enter service type'
            }]
        },
        unitCountService: {
            identifier: 'unitCountService',
            rules: [{
                type: 'empty',
                prompt: 'Please enter unit count of service'
            }]
        },
        serviceCode: {
            identifier: 'serviceCode',
            rules: [{
                type: 'empty',
                prompt: 'Please enter a service code'
            },
            {
                type: 'exactLength[3]',
                prompt: 'Service code must be at least {ruleValue} characters'
            }
            ]
        },
        servicePrice: {
            identifier: 'servicePrice',
            rules: [{
                type: 'empty',
                prompt: 'Please enter value'
            }, {
                type: 'regExp[/^[0-9,]{0,12}$/]',
                prompt: 'Please enter account amount'
            }]
        },

        clientCode: {
            identifier: 'clientCode',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please enter value'
                },
               
                {
                    type: 'regExp[/^[a-zA-Z0-9-/]{3,10}$/]',
                    prompt: 'Please enter CODE'
                }
            ]
        },
        //assitant1: {
        //    identifier: 'assitant1',
        //    rules: [{
        //        type: 'empty',
        //        prompt: 'Please enterassitant1'
        //    }]
        //},
        //assitant2: {
        //    identifier: 'assitant2',
        //    rules: [{
        //        type: 'empty',
        //        prompt: 'Please enter assitant2'
        //    }]
        //},
        //doctor1: {
        //    identifier: 'doctor1',
        //    rules: [{
        //        type: 'empty',
        //        prompt: 'Please enter doctor1'
        //    }]
        //},
        //doctor2: {
        //    identifier: 'doctor2',
        //    rules: [{
        //        type: 'empty',
        //        prompt: 'Please enter doctor2'
        //    }]
        //},
        product: {
            identifier: 'product',
            rules: [{
                type: 'empty',
                prompt: 'Please enter product'
            }]
        },
        supplier: {
            identifier: 'supplier',
            rules: [{
                type: 'empty',
                prompt: 'Please enter supplier'
            }]
        },
        unitProduct: {
            identifier: 'unitProduct',
            rules: [{
                type: 'empty',
                prompt: 'Please enter unit of product'
            }]
        },
        numberProduct: {
            identifier: 'numberProduct',
            rules: [{
                type: 'integer[1..100]',
                prompt: 'Please enter number of product'
            }]
        },
        productPrice: {
            identifier: 'productPrice',
            rules: [{
                type: 'empty',
                prompt: 'Please enter value'
            }, {
                type: 'regExp[/^[0-9,]{0,12}$/]',
                prompt: 'Please enter price'
            }]
        },
        date: {
            identifier: 'date',
            rules: [{
                type: 'empty',
                prompt: 'Please enter date'
            }]
        },
        folderName: {
            identifier: 'folderName',
            rules: [{
                type: 'empty',
                prompt: 'Please enter value'
            }, {
                type: 'regExp[/^[a-zA-Z0-9-/]{0,50}$/]',
                prompt: 'Please enter folder name'
            }]
        },
        dateValid: {
            identifier: 'dateValid',
            rules: [{
                type: 'regExp[/^[0-9-]{0,50}$/]',
                prompt: 'Please enter folder name'
            }]
        },
        CountTypeDefault: {
            identifier: 'CountTypeDefault',
            rules: [{
                type: 'empty',
                prompt: 'Please enter doctor'
            }]
        },
        ware: {
            identifier: 'ware',
            rules: [{
                type: 'empty',
                prompt: 'Please enter branch'
            }]
        },
        sourceType: {
            identifier: 'sourceType',
            rules: [{
                type: 'empty',
                prompt: 'Please enter sourceType'
            }]
        },
        url: {
            identifier: 'url',
            rules: [
                {
                    type: 'url',
                    prompt: 'Please enter a url'
                }
            ]
        },
        lineWidth: {
            identifier: 'lineWidth',
            rules: [{
                type: 'integer[1..10]',
                prompt: 'Please enter number of unit'
            }]
        },
        opacityDegree: {
            identifier: 'opacityDegree',
            rules: [{
                type: 'integer[1..10]',
                prompt: 'Please enter number of unit'
            }]
        },
        grouptele: {
            identifier: 'grouptele',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please choose a grouptele'
                }
            ]
        },
        namelevel: {
            identifier: 'namelevel',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please choose a namelevel'
                }
            ]
        },
        pageName: {
            identifier: 'pageName',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please choose a pageName'
                }
            ]
        },
        controlName: {
            identifier: 'controlName',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please choose a controlName'
                }
            ]
        },
        controlValue: {
            identifier: 'controlValue',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please enter a controlValue'
                }
            ]
        },
        typecontrol: {
            identifier: 'typecontrol',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please enter a typecontrol'
                }
            ]
        },
        paymentMethod: {
            identifier: 'paymentMethod',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please enter a paymentMethod'
                }
            ]
        },
        InvidualTeleFrom: {
            identifier: 'InvidualTeleFrom',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please enter a paymentMethod'
                }
            ]
        },
        InvidualTeleTo: {
            identifier: 'InvidualTeleTo',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please enter a paymentMethod'
                }
            ]
        },
        serviceTabChange: {
            identifier: 'serviceTabChange',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please enter a paymentMethod'
                }
            ]
        },
        newStatusApp: {
            identifier: 'newStatusApp',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please enter a paymentMethod'
                }
            ]
        },
        password: {
            identifier: 'password',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please enter a password'
                },
                {
                    type: 'minLength[6]',
                    prompt: 'Your password must be at least {ruleValue} characters'
                },
                {
                    type: 'maxLength[15]',
                    prompt: 'Please enter at most 100 characters'
                }
            ]
        },
        usernameCreate: {
            identifier: 'usernameCreate',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please enter a password'
                },
                {
                    type: 'minLength[6]',
                    prompt: 'Your password must be at least {ruleValue} characters'
                },
                {
                    type: 'maxLength[15]',
                    prompt: 'Please enter at most 100 characters'
                }
            ]
        },
        usernamemin6: {
            identifier: 'usernamemin6',
            rules: [{
                type: 'empty',
                prompt: 'Please enter a username'
            }, {
                type: 'minLength[6]',
                prompt: 'Your username must be at least {ruleValue} characters'
            }]
        },
        usernamemin5: {
            identifier: 'usernamemin5',
            rules: [{
                type: 'empty',
                prompt: 'Please enter a username'
            }, {
                type: 'minLength[5]',
                prompt: 'Your username must be at least {ruleValue} characters'
            }]
        },
        passwordNew: {
            identifier: 'passwordNew',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please enter a password'
                },
                {
                    type: 'minLength[6]',
                    prompt: 'Your password must be at least {ruleValue} characters'
                },
                {
                    type: 'maxLength[15]',
                    prompt: 'Please enter at most 100 characters'
                }
            ]
        },
        passwordAgain: {
            identifier: 'passwordAgain',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Please enter a password'
                },
                {
                    type: 'minLength[6]',
                    prompt: 'Your password must be at least {ruleValue} characters'
                },
                {
                    type: 'maxLength[15]',
                    prompt: 'Please enter at most 100 characters'
                }
            ]
        },
    }
});



$('.ui.form4').form({
    fields: {
        name: {
            identifier: 'name',
            rules: [{
                type: 'empty',
                prompt: 'Please enter your name'
            }]
        },
        phonenumber: {
            identifier: 'phonenumber',
            rules: [
                {
                    type: 'minLength[8]',
                    prompt: 'Please enter exactly 8 characters'
                },
                {
                    type: 'maxLength[16]',
                    prompt: 'Please enter exactly 12 characters'
                },
                {
                    type: 'number',
                    prompt: 'Please enter number'
                }
            ]
        },
        skills: {
            identifier: 'skills',
            rules: [{
                type: 'minCount[2]',
                prompt: 'Please select at least two skills'
            }]
        },
        gender: {
            identifier: 'gender',
            rules: [{
                type: 'empty',
                prompt: 'Please select a gender'
            }]
        },
        username: {
            identifier: 'username',
            rules: [{
                type: 'empty',
                prompt: 'Please enter a username'
            }]
        },
        password: {
            identifier: 'password',
            rules: [{
                type: 'empty',
                prompt: 'Please enter a password'
            }, {
                type: 'minLength[6]',
                prompt: 'Your password must be at least {ruleValue} characters'
            }]
        },
        terms: {
            identifier: 'terms',
            rules: [{
                type: 'checked',
                prompt: 'You must agree to the terms and conditions'
            }]
        },
        sourceType: {
            identifier: 'sourceType',
            rules: [{
                type: 'empty',
                prompt: 'Please enter a sourceType'
            }]
        },

        fileUpload: {
            identifier: 'fileUpload',
            rules: [{
                type: 'empty',
                prompt: 'Please enter a fileUpload'
            }]
        },
        reasonCancel: {
            identifier: 'reasonCancel',
            rules: [{
                type: 'empty',
                prompt: 'Please enter a reasonCancel'
            }]
        },



    }
});
$(".setdata.button").on("click", function () {
    $('.ui.form3')
        // set one value
        .form('set value', 'name', 'Jack')
        // set several values
        .form('set values', {
            name: 'Joshua',
            gender: 'male',
            colors: ['red', 'grey'],
            username: 'q_joshua',
            password: 'passw0rd',
            terms: true
        });
})

$(".clear.button").on("click", function () {
    $('form').form('clear')
});
$(".reset.button").on("click", function () {
    $('form').form('reset')
});
$('.ui.form5').form({
    inline: true,
    on: 'blur',
    fields: {
        name: {
            identifier: 'first-name',
            rules: [{
                type: 'empty',
                prompt: 'Please enter your name'
            }]
        },
        skills: {
            identifier: 'last-name',
            rules: [{
                type: 'minCount[2]',
                prompt: 'Please enter your last name'
            }]
        },

        username: {
            identifier: 'username',
            rules: [{
                type: 'empty',
                prompt: 'Please enter a username'
            }]
        },
        password: {
            identifier: 'password',
            rules: [{
                type: 'empty',
                prompt: 'Please enter a password'
            }, {
                type: 'minLength[6]',
                prompt: 'Your password must be at least {ruleValue} characters'
            }]
        },
        terms: {
            identifier: 'terms',
            rules: [{
                type: 'checked',
                prompt: 'You must agree to the terms and conditions'
            }]
        }
    }
});

$('.ui.form6').form({
    on: 'blur',
    inline: true,
    fields: {
        integer: {
            identifier: 'integer',
            rules: [
                {
                    type: 'integer[1..100]',
                    prompt: 'Please enter an integer value'
                }
            ]
        },
        decimal: {
            identifier: 'decimal',
            rules: [
                {
                    type: 'decimal',
                    prompt: 'Please enter a valid decimal'
                }
            ]
        },
        number: {
            identifier: 'number',
            rules: [
                {
                    type: 'number',
                    prompt: 'Please enter a valid number'
                }
            ]
        },
        emailValidate: {
            identifier: 'emailValidate',
            rules: [
                {
                    type: 'email',
                    prompt: 'Please enter a valid e-mail'
                }
            ]
        },
        url: {
            identifier: 'url',
            rules: [
                {
                    type: 'url',
                    prompt: 'Please enter a url'
                }
            ]
        },
        regex: {
            identifier: 'regex',
            rules: [
                {
                    type: 'regExp[/^[a-z0-9_-]{4,16}$/]',
                    prompt: 'Please enter a 4-16 letter username'
                }
            ]
        }
    }
})
    ;

$('.ui.form7').form({
    on: 'blur',
    fields: {
        card: {
            identifier: 'card',
            rules: [
                {
                    type: 'creditCard',
                    prompt: 'Please enter a valid credit card'
                }
            ]
        },
        exactCard: {
            identifier: 'exact-card',
            rules: [
                {
                    type: 'creditCard[visa,amex]',
                    prompt: 'Please enter a visa or amex card'
                }
            ]
        }
    }
})
    ;

$('.ui.form8').form({
    on: 'blur',
    fields: {
        match: {
            identifier: 'match2',
            rules: [
                {
                    type: 'match[match1]',
                    prompt: 'Please put the same value in both fields'
                }
            ]
        },
        different: {
            identifier: 'different2',
            rules: [
                {
                    type: 'different[different1]',
                    prompt: 'Please put different values for each field'
                }
            ]
        }
    }
})
    ;
$('.ui.form9').form({
    on: 'blur',
    fields: {
        minLength: {
            identifier: 'minLength',
            rules: [
                {
                    type: 'minLength[100]',
                    prompt: 'Please enter at least 100 characters'
                }
            ]
        },
        exactLength: {
            identifier: 'exactLength',
            rules: [
                {
                    type: 'exactLength[6]',
                    prompt: 'Please enter exactly 6 characters'
                }
            ]
        },
        maxLength: {
            identifier: 'maxLength',
            rules: [
                {
                    type: 'maxLength[100]',
                    prompt: 'Please enter at most 100 characters'
                }
            ]
        },
    }
})
    ;

$('.ui.form10').form({
    on: 'blur',
    fields: {
        is: {
            identifier: 'is',
            rules: [
                {
                    type: 'is[dog]',
                    prompt: 'Please enter exactly "dog"'
                }
            ]
        },
        isExactly: {
            identifier: 'isExactly',
            rules: [
                {
                    type: 'isExactly[dog]',
                    prompt: 'Please enter exactly "dog"'
                }
            ]
        },
        not: {
            identifier: 'not',
            rules: [
                {
                    type: 'not[dog]',
                    prompt: 'Please enter a value, but not "dog"'
                }
            ]
        },
        notExactly: {
            identifier: 'notExactly',
            rules: [
                {
                    type: 'notExactly[dog]',
                    prompt: 'Please enter a value, but not exactly "dog"'
                }
            ]
        },
        contains: {
            identifier: 'contains',
            rules: [
                {
                    type: 'contains[dog]',
                    prompt: 'Please enter a value containing "dog"'
                }
            ]
        },
        containsExactly: {
            identifier: 'containsExactly',
            rules: [
                {
                    type: 'containsExactly[dog]',
                    prompt: 'Please enter a value containing exactly "dog"'
                }
            ]
        },
        doesntContain: {
            identifier: 'doesntContain',
            rules: [
                {
                    type: 'doesntContain[dog]',
                    prompt: 'Please enter a value not containing "dog"'
                }
            ]
        },
        doesntContainExactly: {
            identifier: 'doesntContainExactly',
            rules: [
                {
                    type: 'doesntContainExactly[dog]',
                    prompt: 'Please enter a value not containing exactly "dog"'
                }
            ]
        }
    }
})
    ;

$('.ui.form11').form({
    on: 'blur',
    fields: {
        minCount: {
            identifier: 'minCount',
            rules: [
                {
                    type: 'minCount[2]',
                    prompt: 'Please select at least 2 values'
                }
            ]
        },
        maxCount: {
            identifier: 'maxCount',
            rules: [
                {
                    type: 'maxCount[2]',
                    prompt: 'Please select a max of 2 values'
                }
            ]
        },
        exactCount: {
            identifier: 'exactCount',
            rules: [
                {
                    type: 'exactCount[2]',
                    prompt: 'Please select 2 values'
                }
            ]
        }
    }
});
$('.ui.form12').form({
    dog: {
        identifier: 'dog',
        rules: [
            {
                type: 'empty',
                prompt: 'You must have a dog to add'
            },
            {
                type: 'contains[fluffy]',
                prompt: 'I only want you to add fluffy dogs!'
            },
            {
                type: 'not[mean]',
                prompt: 'Why would you add a mean dog to the list?'
            }
        ]
    }
});










