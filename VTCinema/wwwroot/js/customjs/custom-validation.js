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

$('.ui.form3').form({
    inline: true,
    on: 'blur',
    fields: {
        //Validate Customer 

        firstname: {
            identifier: 'firstname',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập họ '
            },
            {
                type: "regExp[/^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ]/]",
                prompt: 'Tên không được nhập số'
            }]       
        },
        name: {
            identifier: 'name',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập tên'
            },
            {
                type: "regExp[/^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ]/]",
                prompt: 'Tên không được nhập số'
            }]
        },
        email: {
            identifier: 'email',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập email'
            }, {
                    type: "regExp[/^([a-zA-Z0-9_\.\-])+\@(gmail.com|yahoo.com)+$/]",
                    prompt: 'Vui lòng nhập email đúng định dạng'
            }
            ]
        },
        phonenumber: {
            identifier: 'phonenumber',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập số điện thoại'
            },{
                    type: "regExp[/^[0-9]/]",
                    prompt: 'Vui lòng nhập đúng số điện thoại'
            },{
                    type: "maxLength[10]",
                    prompt: 'Vui lòng nhập đúng số điện thoại'
            },{
                    type: "minLength[10]",
                    prompt: 'Vui lòng nhập đúng số điện thoại'
            }]
        },      
        date: {
            identifier: 'date',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng chọn ngày'
            }]
        },      
        password: {
            identifier: 'password',
            rules: [
                {
                    type: 'empty',
                    prompt: 'Mật khẩu không được để trống!'
                },
                {
                    type: 'minLength[6]',
                    prompt: 'Mật khẩu từ 6-50 kí tự'
                },
                {
                    type: 'maxLength[50]',
                    prompt: 'Mật khẩu từ 6-50 kí tự'
                },
                {
                    type: "regExp[\s]",
                    prompt:'Mật khẩu không nhập khoảng trắng'
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
                },
                {
                    type: 'match[password]',
                    prompt: 'Mật khẩu và nhập lại mật khẩu không trùng nhau'
                }

            ]
        },
        //actor
        Height: {
            identifier: 'Height',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập chiều cao'
            },{
                type: "regExp[/^[0-9]/]",
                prompt: 'Vui lòng nhập chiều cao'
            }]
        },      
        country: {
            identifier: 'country',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng chọn quốc tịch'
            }]
        },  

        // ages
        
        NameAges: {
            identifier: 'NameAges',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập lứa tuổi'
            }]
        },  
        Ages: {
            identifier: 'Ages',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập tuổi giới hạn'
            }, {
                type: "regExp[/^[0-9]/]",
                 prompt: 'Vui lòng nhập số cho tuổi'
            }]
        },      
        //branch
        BranchCode: {
            identifier: 'BranchCode',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập mã chi nhánh'
            }]
        },  
        Namebranch: {
            identifier: 'Namebranch',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập tên chi nhánh'
            }]
        },  
        ShortName: {
            identifier: 'ShortName',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập tên viết tắt chi nhánh'
            }]
        },  
        Longtitude: {
            identifier: 'Longtitude',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập tung độ'
            }, {
                type: "regExp[/^[0-9]/]",
                prompt: 'Vui lòng nhập số cho tung độ'
            }]
        },     
        Latitude: {
            identifier: 'Latitude',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập vĩ độ'
            }, {
                type: "regExp[/^[0-9]/]",
                    prompt: 'Vui lòng nhập số cho vĩ độ'
            }]
        },     
        Address: {
            identifier: 'Address',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập địa chỉ chi nhánh'
            }]
        },  
        // movie ticket type    
        Nameticket: {
            identifier: 'Nameticket',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập tên loại vé'
            }]
        },  
        Prices: {
            identifier: 'Prices',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập giá'
            }, {
                type: "regExp[/^[0-9]/]",
                prompt: 'Vui lòng nhập số cho giá'
            }]
        },    
        //MovieType
        
        MovieType: {
            identifier: 'MovieType',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập thể loại phim'
            }]   
        },  
        // product
        
        Producttype: {
            identifier: 'Producttype',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng chọn loại sản phẩm'
            }]
        },  
        productPrice: {
            identifier: 'productPrice',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập giá'
            }, {
                type: "regExp[/^[0-9]/]",
                prompt: 'Vui lòng nhập số cho giá'
            }]
        },    
        Sub_Title: {
            identifier: 'Sub_Title',
            rules: [{
                type: 'empty',
                prompt: 'Vui lòng nhập loại phiên dịch'
            }]
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










