import { Izvedba } from "./Izvedba.js";
import {Predstava} from "./Predstava.js";
import { Sala } from "./Sala.js";

export class Pozoriste {

    constructor(n) {
        this.selectedItem = null;
        this.selectedIndex = 0;
        this.predstave = [];
        this.name = n;
        this.container = null;
        this.sale = [];
        console.log(this.predstave);
    }

    draw(host) {
        let main = document.createElement("div");
        host.appendChild(main);
        main.className = "main";

        let pname = document.createElement("h1");
        main.appendChild(pname);
        pname.innerHTML = this.name;

        let choiceDiv = document.createElement("div");
        choiceDiv.className = "choice";
        main.appendChild(choiceDiv);

        let base = document.createElement("div");
        base.className = "base";
        host.appendChild(base);
        this.container = base;

        let op1 = document.createElement("label");
        op1.innerHTML = "Predstave";
        choiceDiv.appendChild(op1);
        op1 = document.createElement("input");
        op1.type = "radio";
        op1.name = "view";
        op1.value = "Predstave";
        choiceDiv.appendChild(op1);
        op1.onchange = (ev => {
            let c = main.querySelector("input[value='Predstave']");
            if (c.checked) {
                let x = this.container.querySelector(".addNew");
                x.style.display = "flex";
                x.style.flexDirection = "column";
                x = this.container.querySelector(".show");
                x.style.display = "flex";
                x.style.flexWrap = "wrap";
                x = this.container.querySelector(".sale");
                x.style.display = "none";
                x = this.container.querySelector(".showS");
                x.style.display = "none";
            }
            else {
                let x = this.container.querySelector(".sale");
                x.style.display = "flex";
                x.style.flexDirection = "column";
                x = this.container.querySelector(".showS");
                x.style.display = "flex";
                x.style.flexWrap = "wrap";
                x = this.container.querySelector(".addNew");
                x.style.display = "none";
                x = this.container.querySelector(".show");
                x.style.display = "none";
            }
        });
        let op2 = document.createElement("label");
        op2.innerHTML = "Sale";
        choiceDiv.appendChild(op2);
        op2 = document.createElement("input");
        op2.type = "radio";
        op2.name = "view";
        op2.value = "Sale";
        choiceDiv.appendChild(op2);
        op2.onchange = (ev => {
            let c = main.querySelector("input[value='Predstave']");
            if (c.checked) {
                let x = this.container.querySelector(".addNew");
                x.style.display = "flex";
                x.style.flexDirection = "column";
                x = this.container.querySelector(".show");
                x.style.display = "flex";
                x.style.flexWrap = "wrap";
                x = this.container.querySelector(".sale");
                x.style.display = "none";
                x = this.container.querySelector(".showS");
                x.style.display = "none";
            }
            else {
                let x = this.container.querySelector(".sale");
                x.style.display = "flex";
                x.style.flexDirection = "column";
                x = this.container.querySelector(".showS");
                x.style.display = "flex";
                x.style.flexWrap = "wrap";
                x = this.container.querySelector(".addNew");
                x.style.display = "none";
                x = this.container.querySelector(".show");
                x.style.display = "none";
            }
        });
        
        this.drawPredstave(base);
        this.drawSale(base);
        let x = this.container.querySelector(".addNew");
        x.style.display = "none";
        x = this.container.querySelector(".show");
        x.style.display = "none";
        x = this.container.querySelector(".sale");
        x.style.display = "none";
        x = this.container.querySelector(".showS");
        x.style.display = "none";
    }

    show(parent) {
        let sub = this.container.querySelectorAll(".item");
        sub.forEach(el => {
            parent.removeChild(el);
        });
        this.predstave.forEach((el, i) => {
            this.selectedItem = el.draw(parent);

        });
    };

    showSale(parent) {
        let s = this.container.querySelectorAll(".sala");
        s.forEach(el => {
            parent.removeChild(el);
        });

        this.sale.forEach((el, i) => {
            el.draw(parent);
        });
    };

    drawPredstave(base) {
        let addNewDiv = document.createElement("div");
        addNewDiv.className = "addNew";
        base.appendChild(addNewDiv);

        let dataDiv = document.createElement("div");
        addNewDiv.appendChild(dataDiv);
        dataDiv.className = "data";
        let addLeft = document.createElement("div");
        dataDiv.appendChild(addLeft);
        addLeft.className = "left";
        let addRight = document.createElement("div");
        dataDiv.appendChild(addRight);
        addRight.className = "right";

        let showDiv = document.createElement("div");
        base.appendChild(showDiv);
        showDiv.className = "show";

        let properties = ["Naziv", "Opis", "Ogranicenje"];
        let types = ["input", "input", "div"];

        properties.forEach((el, i) => {
            let x = document.createElement("label");
            x.innerHTML = el;
            x.className = "label";
            addLeft.appendChild(x);
            x = document.createElement(types[i]);
            x.className = "inputPredstava"
            addRight.appendChild(x);
            if(el == "Ogranicenje") {
                this.createRadio(["Nema", "+3", "+12", "+18"], x);
                x.name = "radioChoice";
            }
        });

        let buttonDodaj = document.createElement("button");
        addNewDiv.appendChild(buttonDodaj);
        buttonDodaj.innerHTML = "Dodaj predstavu";

        let buttonIzmeni = document.createElement("button");
        addNewDiv.appendChild(buttonIzmeni);
        buttonIzmeni.innerHTML = "Izmeni predstavu";

        let buttonObrisi = document.createElement("button");
        addNewDiv.appendChild(buttonObrisi);
        buttonObrisi.innerHTML = "Obrisi predstavu";

        let dataDiv2 = document.createElement("div");
        addNewDiv.appendChild(dataDiv2);
        dataDiv2.className = "data";
        let addLeft2 = document.createElement("div");
        dataDiv2.appendChild(addLeft2);
        addLeft2.className = "left";
        let addRight2 = document.createElement("div");
        dataDiv2.appendChild(addRight2);
        addRight2.className = "right";

        let props = ["Sala", "Datum", "Vreme", "Karte"];
        let typs = ["select", "date", "time", "number"];

        props.forEach((el, i) => {
            let x = document.createElement("label");
            x.innerHTML = el;
            x.className = "label";
            addLeft2.appendChild(x);
            if(i == 0) {
                x = document.createElement(typs[i]);
            }
            else {
                x = document.createElement("input");
                x.type = typs[i];
            }
            x.className = "inputIzvedba"
            addRight2.appendChild(x);
            if(el == "Ogranicenje") {
                this.createRadio(["Nema", "+3", "+12", "+18"], x);
                x.name = "radioChoice";
            }
        });

        let buttonDodajIzvedbu = document.createElement("button");
        addNewDiv.appendChild(buttonDodajIzvedbu);
        buttonDodajIzvedbu.innerHTML = "Dodaj izvedbu";

        let buttonIzmeniIzvedbu = document.createElement("button");
        addNewDiv.appendChild(buttonIzmeniIzvedbu);
        buttonIzmeniIzvedbu.innerHTML = "Izmeni izvedbu";

        let buttonObrisiIzvedbu = document.createElement("button");
        addNewDiv.appendChild(buttonObrisiIzvedbu);
        buttonObrisiIzvedbu.innerHTML = "Obrisi izvedbu";

        buttonDodaj.onclick = (ev => this.dodajPred(showDiv));

        buttonIzmeni.onclick = (ev => this.izmeniPred(showDiv));

        buttonObrisi.onclick = (ev => this.obrisiPred(showDiv));

        buttonDodajIzvedbu.onclick = (ev => this.dodajIzv(showDiv));

        buttonIzmeniIzvedbu.onclick = (ev => this.izmeniIzv(showDiv));

        buttonObrisiIzvedbu.onclick = (ev => this.obrisiIzv(showDiv));

        this.show(showDiv);
    }

    drawSale(base) {
        let SaleDiv = document.createElement("div");
        SaleDiv.className = "sale";
        base.appendChild(SaleDiv);

        let manage = document.createElement("div");
        SaleDiv.appendChild(manage);
        manage.className = "data";
        let left = document.createElement("div");
        manage.appendChild(left);
        left.className = "left";
        let right = document.createElement("div");
        manage.appendChild(right);
        right.className = "right";

        let saleShow = document.createElement("div");
        base.appendChild(saleShow);
        saleShow.className = "showS";

        let propies = ["Broj", "Kapacitet"];
        let typies = ["number", "number"];

        propies.forEach((el, i) => {
            let x = document.createElement("label");
            x.innerHTML = el;
            x.className = "label";
            left.appendChild(x);
            x = document.createElement("input");
            x.type = typies[i];
            x.className = "inputSala"
            right.appendChild(x);
        });

        let table = document.createElement("table");
            saleShow.appendChild(table);
            let thead = document.createElement("thead");
            table.appendChild(thead);
            let tr = document.createElement("tr");
            thead.appendChild(tr);
            let a = ["Sala", "Kapacitet"];
            a.forEach(ea => {
                let th = document.createElement("th");
                tr.appendChild(th);
                th.innerHTML = ea;
            });
            let tbody = document.createElement("tbody");
            table.appendChild(tbody);
            this.sale.forEach(e => {
                e.draw(tbody);
            });

        let dodajSalu = document.createElement("button");
        SaleDiv.appendChild(dodajSalu);
        dodajSalu.innerHTML = "Dodaj salu";

        dodajSalu.onclick = (ev => this.dodajS(tbody));

        this.showSale(tbody);
    }

    select(i) {
        if(this.selectedItem != null && this.selectedItem != i) {
            this.selectedItem.container.style.backgroundColor = "#e0ebeb";
            if (this.selectedItem.selectedIzv != null) {
                this.selectedItem.selectedIzv.container.style.backgroundColor = "#7ca4ad";
            }
        }
        this.selectedItem = i;
        this.predstave.forEach((el, ind) => {
            if(this.selectedItem == el) {
                this.selectedIndex = ind;
            }
        });
    }

    createRadio(options, parent) {
        options.forEach(el => {
            let x = document.createElement("label");
            x.innerHTML = el;
            x.value = el;
            parent.appendChild(x);
            let y = document.createElement("input");
            y.type = "radio";
            y.name = "radio";
            y.value = el;
            parent.appendChild(y);
        });
    }

    dodajPred (host) {
            let arr = [];
            let fl = true;
            let tmp = ["naziv", "opis", "ogranicenje"];
            let x = this.container.querySelectorAll(".inputPredstava");
            x.forEach((el, z) => {
                if(el.value== "") {
                    alert("Molimo Vas unesite " + tmp[z] + " predstave!");
                   fl = false;
                }
                if(el.name == "radioChoice") {
                    let x = this.container.querySelector("input:checked");
                    if(x == null) {
                        alert("Molimo Vas unesite " + tmp[z] + " predstave!");
                       fl = false;
                    }
                    else {
                        el.value = x.value;
                    }
                   
                }
                arr.push(el.value);
            });
            
            if(fl == false) {
                return;
            }

            //PROBA
            console.log(arr[0]);
            console.log(arr[1]);
            console.log(arr[2]);
            console.log(this.name);
            
            fetch("https://localhost:5001/Predstava/UpisiPredstavu/" + this.name + "/" + arr[0] + "/" + arr[1] + "/" + arr[2], {
                method: "POST"
            }).then(p => {
                if(p.ok){
                    let pred = new Predstava(arr, this);
                    this.predstave.push(pred);
                    this.show(host);
                    
                }
                else
                    alert("Nemoguce dodati predstavu");
            });
    }

    izmeniPred (host) {
        if(this.selectedItem == null){
            alert("Molimo Vas da izaberete predstavu koju zelite da izmenite");
            return;
        }
            let arr = [];
            let fl = true;
            let tmp = ["naziv", "opis", "ogranicenje"];
            let x = this.container.querySelectorAll(".inputPredstava");
            x.forEach((el, i) => {
                if(el.value== "") {
                    alert("Molimo Vas unesite " + tmp[i] + " predstave!");
                    fl = false;
                }
                if(el.name == "radioChoice") {
                    let x = this.container.querySelector("input:checked");
                    if(x == null) {
                        alert("Molimo Vas unesite " + tmp[i] + " predstave!");
                       fl = false;
                    }
                    else {
                        el.value = x.value;
                    }
                }
                arr[i] = el.value;
            });

            if(fl == false) {
                return;
            }

            fetch("https://localhost:5001/Predstava/IzmeniPredstavu/" + this.name +"/" + this.selectedItem.naziv + "/" + arr[0] + "/" + arr[1] + "/" + arr[2], {
                method: "PUT"
            }).then(p => {
                if(p.ok){
                    this.selectedItem.update(arr);
                    this.show(host);
                
                }
                else
                    alert("Nemoguce izmeniti predstavu");
            });                    
    }

    obrisiPred (host) {
        if(this.selectedItem == null) {
            alert("Molimo Vas da izaberete predstavu koju zelite da izbrisete");
            return;
        }
            fetch("https://localhost:5001/Predstava/IzbrisiPredstavu/" + this.name + "/" + this.selectedItem.naziv, {
                method: "DELETE"
            }).then(p => {
                if(p.ok){
                    this.predstave.splice(this.selectedIndex, 1);
                    this.show(host);
                }
                else
                    alert("Nemoguce obrisati predstavu");
            });      
    }

    dodajIzv(host) {
        if (this.selectedItem != null){
            let arr = [];
            let tmparr = ["datum", "vreme", "broj prodatih karata"];
            let x = this.container.querySelectorAll(".inputIzvedba");
            let tmp = null;
            let flag = true;
            x.forEach((el, ind) => {
                if (ind == 0) {
                    console.log(this.sale);
                    this.sale.forEach(s => {
                        if(s.broj == el.value) {
                            tmp = s;
                        }
                    });
                }
                else if(ind == 3) {
                    if(el.value == "") {
                        alert("Molimo Vas unesite " + tmparr[ind-1] + " izvedbe!");
                        flag = false;
                    }
                    else if(parseInt(el.value) > tmp.kapacitet) {
                        flag = false;
                        alert("Premasili ste kapacitet sale. Dozvoljeni kapacitet je" + tmp.kapacitet);
                    }
                    else {
                        arr.push(el.value);
                    }
                }
                else{
                    if(el.value == "") {
                        alert("Molimo Vas unesite " + tmparr[ind-1] + " izvedbe!");
                        flag = false;
                    }
                    else {
                        arr.push(el.value);
                    }
                }
            });
            if(flag == true){

                fetch("https://localhost:5001/Izvedba/UpisiIzvedbu/" + this.name + "/" + this.selectedItem.naziv + "/" + tmp.broj + "/" + arr[0] + "/" + arr[1] + "/" + arr[2], {
                    method: "POST"
                }).then(p => {
                    p.json().then(data => {
                    //if(p.ok){
                        console.log("USPESNO");
                        console.log(data);
                        let izv = new Izvedba(arr, this.selectedItem, tmp, data.id);
                        tmp.izvedbe.push(izv);
                        this.selectedItem.izvedbe.push(izv);
                        this.show(host);
                    })
                    //else
                        //alert("NOOO");
                });

            }
        }
        else {
            alert("Molimo Vas izaberite predstavu za koju zelite da dodate izvedbu");
        }
    }

    izmeniIzv(host) {
        if(this.selectedItem != null){
            if(this.selectedItem.selectedIzv == null) {
                alert("Molimo Vas izaberite izvedbu koju zelite da izmenite");
                return;
            }
            let arr = [];
            let tmparr = ["datum", "vreme", "broj prodatih karata"];
            let x = this.container.querySelectorAll(".inputIzvedba");
            let tmp = null;
            let flag = true;
            x.forEach((el, i) => {
                if (i == 0) {
                    this.sale.forEach(s => {
                        if(s.broj == el.value) {
                            tmp = s;
                        }
                    });
                }
                else if (i == 3) {
                    if(el.value == ""){
                        flag = false;
                        alert("Molimo Vas unesite " + tmparr[i-1] + " izvedbe");
                    }
                        if(parseInt(el.value) > tmp.kapacitet) {
                            flag = false;
                            alert("Premasili ste kapacitet sale. Dozvoljeni kapacitet je" + tmp.kapacitet);
                        }
                        else{
                            arr[i-1] = el.value;
                        }
                    }
                    else {
                        if(el.value == ""){
                            flag = false;
                            alert("Molimo Vas unesite " + tmparr[i-1] + " izvedbe");
                        }
                        else {
                            arr[i-1] = el.value;
                        }
                    }
                });
            if(flag == true) {
                fetch("https://localhost:5001/Izvedba/IzmeniIzvedbu/" + this.name + "/" + this.selectedItem.naziv + "/" + tmp.broj + "/" + arr[0] + "/" + arr[1] + "/" + arr[2] + "/" + this.selectedItem.selectedIzv.id, {
                    method: "PUT"
                }).then(p => {
                    if(p.ok){
                        this.selectedItem.selectedIzv.sala.izvedbe.forEach((e, i) => {
                            if(e == this.selectedItem.selectedIzv) {
                                this.selectedItem.selectedIzv.sala.izvedbe.splice(i, 1);
                            }
                        })
                        this.selectedItem.selectedIzv.update(arr, tmp);
                        tmp.izvedbe.push(this.selectedItem.selectedIzv);
                        this.show(host);
                
                    }
                    else
                        alert("Nemoguce izmeniti izvedbu");
                });   
            }
        }
        else {
            alert("Molimo Vas izaberite predstavu ciju izvedbu zelite da izmenite");
        }
    }

    obrisiIzv(host) {
        if(this.selectedItem == null) {
            alert("Molimo Vas izaberite predstavu ciju izvedbu zelite da izbrisete");
            return;
        }             
        if(this.selectedItem.selectedIzv == null) {
            alert("Molimo Vas izaberite izvedbu koju zelite da izbrisete");
            return;
        }
            fetch("https://localhost:5001/Izvedba/IzbrisiIzvedbu/" + this.name + "/" + this.selectedItem.naziv + "/" + this.selectedItem.selectedIzv.sala.broj + "/" + this.selectedItem.selectedIzv.id, {
                method: "DELETE"
            }).then(p => {
                if(p.ok){
                    this.selectedItem.izvedbe.splice(this.selectedItem.selectedInd, 1);
                    this.selectedItem.selectedIzv.sala.izvedbe.forEach((e, i) => {
                        if(e == this.selectedItem.selectedIzv) {
                            this.selectedItem.selectedIzv.sala.izvedbe.splice(i, 1);
                        }
                    })
                    this.show(host);
                }
                else
                    alert("Nemoguce obrisati izvedbu");
            });  
    }

    dodajS(host) {
            let arr = [];
            let tmparrs = ["broj", "kapacitet"];
            let fl = true;
            let x = this.container.querySelectorAll(".inputSala");
            x.forEach((el, y) => {
                if(el.value == ""){
                    alert("Molimo vas unesite " + tmparrs[y] + " sale");
                    fl = false;
                }
                arr.push(el.value);
            });

            if(fl == false) {
                return;
            }

            fetch("https://localhost:5001/Sala/UpisiSalu/" + this.name + "/" + arr[0] + "/" + arr[1], {
                method: "POST"
            }).then(p => {
                if(p.ok){
                    let sala = new Sala(arr, this);
                    this.sale.push(sala);
                    this.showSale(host);
                    sala.addOption(this.container);       
                }
                else
                    alert("Nemoguce dodati salu");
            });
    }
}