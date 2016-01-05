function validateForm() {
    var amnt = document.getElementById("Amount").value;
    var avalbal = document.getElementById("acnt-bal").innerHTML;
    F_account=document.getElementById("FromAccount").value;
    T_Account = document.getElementById("ToAccount").value;

    flag = true;
    if (F_account == "")
    {
        document.getElementById("BalanceValidMessage").innerHTML = "Please select From Account";
        flag = false;
    }
    if (T_Account == "")
    {
        document.getElementById("BalanceValidMessage").innerHTML = "Please select From Account";
        flag = false;
    }

    if (flag)
    {
        if (parseInt(amnt, 10) > parseInt(avalbal,10)) {
            document.getElementById("BalanceValidMessage").innerHTML = "Insufficient Balance.";
            flag = false;
        }

        if (parseInt(amnt, 10) <50) {
            document.getElementById("BalanceValidMessage").innerHTML = "Minimum transferable amount is 50";
            flag = false;
        }


        if (F_account == T_Account) {
            document.getElementById("BalanceValidMessage").innerHTML = "From and To Account can not be same.";
            flag = false;
        }
    }

    if (flag)
        return true;
    else
        return false;
};

function getAccountBalance(accnt) 
{
        $.ajax({
        url: '/BankAccounts/getbalance',
        data: { account: accnt },
        success: function (data) {
            document.getElementById("acnt-bal").innerHTML = data;
        },
        error: function () {
            alert('Error');
        }
    });
};