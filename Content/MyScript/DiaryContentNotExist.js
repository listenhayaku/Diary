function main() {
    back();
}

function back() {
    setTimeout(() => { location.pathname = "/DiaryList"; }, 3000);
}

main();