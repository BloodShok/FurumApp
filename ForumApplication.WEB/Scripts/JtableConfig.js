$(document).ready(function () {
    $('#PersonTableContainer').jtable({
        title: 'Table of people',
        paging: true,
        pageSize: 10,
        useBootstrap: true,
        actions: {
            listAction: 'UserLists',
            createAction: 'CreateAccount',
            updateAction: 'UpdateAccount',
            deleteAction: 'DeleteAccount'
        },
        fields: {
            Id: {
                key: true,
                list: false
            },
            UserName: {
                title: 'UserName',
                width: '40%'
            },
            Password: {
                title: 'Password',
                list: false,
                edit: false,
                create: true
            },
            Email: {
                title: 'Email',
                width: '20%'
            },
            DateRegistration: {
                title: 'DateRegistration',
                width: '25%',
                type: 'date',
                displayFormat: 'dd/mm/yy',
                create: false,
                edit: false,
            },
            BirthDay: {
                title: 'BirthDay',
                width: '25%',
                type: 'date',
                displayFormat: 'yy-mm-dd'
            },
            IsActive: {
                title: 'IsActive',
                width: '20%',
                type: 'checkbox',
                values: { 'false': 'Deleted', 'true': 'Active' },
                defaultValue: 'true'
            },
            RoleName: {
                title: 'RoleName',
                width: '20%',
                options: { 'User': 'User', 'Moderator': 'Moderator' }
            },
            Gender: {
                title: 'Gender',
                width: '20%',
                options: { '0': 'Male', '1': 'Female' }
            },
            SomeInformation: {
                title: 'SomeInformation',
                width: '20%'
            },
            Location: {
                title: 'Location',
                width: '20%'
            },
        }
    });
    $('#PersonTableContainer').jtable('load');
});