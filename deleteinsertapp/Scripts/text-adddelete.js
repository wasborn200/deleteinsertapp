// すでに資格データがある際のinputfield表示条件について
// var count = @Model.Count;
// コントローラーでinput1～10のどこまでデータがあるかでcountを決定。
// それをviewモデルを通じてjavascriptへ伝達
// 初期表示時にデータがある箇所までinputfieldをopenの状態にする

// 現在必要な処理
// ページは一つで良い
// dao, datamodel, viewmodelは必要
// databaseのアクセスconnection設定も必要

// 使用変数一覧
// count： addしたときは次に表示するinputfieldのid、deleteするときは(count - 1)のid
// inputfieldId = 


//if (!(vm.MM2 == null)) {
//    count = 3;
//}
//if (!(vm.MM3 == null)) {
//    count = 4;
//}
//if (!(vm.MM4 == null)) {
//    count = 5;
//}

//count3　の時　２をオープン
//count4　の時　2, 3をオープン
//count5　の時　2,3,4をオープン

// 登録されている項目の数だけ初期表示でオープン

var count = document.getElementById('count').title;
var opennumber = count - 1;

if (count >= 2) {
    for (var opencount = 2; opencount <= opennumber; opencount++) {

        var numberid = "inputfield" + opencount;
        const inputfieldName = document.getElementById(numberid);
        inputfieldName.style.display = "flex";
    }
}
//var open_count = count - 2;
//if (count >= 3) {

//    for (var i = 2, x = 1; 1 < open_count; i++,x++) {
//        var inputfieldId = 'inputfield' + i;
//        var inputfieIdName = document.getElementById(inputfieldId);
//        inputfieIdName.style.display = "flex";
//    }
//}

// addボタン押下時
function clickBtn1() {

    var inputfieldId = 'inputfield' + count;
    var inputfieIdName = document.getElementById(inputfieldId);
    inputfieIdName.style.display = "flex";
    count++;
}

// deleteボタン押下時
function clickBtn2(number) {

    if (count >= 3) {
        count--;
        var inputfieldId = 'inputfield' + count;
        var sinputId = 'input' + number;
        var smmId = 'mm' + number;

        // 項目を非表示にする
        var inputfieldName = document.getElementById(inputfieldId);
        inputfieldName.style.display = "none";

        // 削除した項目のみ値を削除する
        document.getElementById(sinputId).value = '';
        document.getElementById(smmId).value = '';

        // 全項目の文字を取得する
        var input_values = [];
        var mm_values = [];
        for (var i = 1; i <= 4; i++) {
            var inputId = "input" + i;
            var mmId = "mm" + i;
            var old_input = document.getElementById(inputId).value;
            var old_mm = document.getElementById(mmId).value;
            if (!(old_input == "")) {
                input_values.push(old_input);
            }
            if (!(old_mm == "")) {
                mm_values.push(old_mm);
            }
        };

        // 最初のinputから順番に値を再配置してする
        // inputfieldの総数-1の数までループ
        // 最後まで""で埋めないと、valueにundefinedと入力されてしまう。
        for (var number = 0, item = 1; number <= 3; number++, item++) {
            var inputId = "input" + item;
            var mmId = "mm" + item;
            if (input_values[number] == null) {
                document.getElementById(inputId).value = "";
            } else {
                document.getElementById(inputId).value = input_values[number];
            }
            if (mm_values[number] == null) {
                document.getElementById(mmId).value = "";
            } else {
                document.getElementById(mmId).value = mm_values[number];
            }
        };

    }
}