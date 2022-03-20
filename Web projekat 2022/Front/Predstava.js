 import { Pozoriste } from "./Pozoriste.js";
 import { Izvedba } from "./Izvedba.js";
 
 export class Predstava {

    constructor(nods, p) {
        this.naziv = nods[0];
        this.opis = nods[1];
        this.ogranicenje = nods[2];
        this.attrs = nods;
        this.poz = p;
        this.izvedbe = [];
        this.selectedIzv = null;
        this.selectedInd = 0;
    }

    update(nods) {
        this.naziv = nods[0];
        this.opis = nods[1];
        this.ogranicenje = nods[2];
        this.attrs = nods;
        this.container = null;
    }

    draw(host) {

        var classes = ["naziv", "opis", "ogranicenje"];
        let item = document.createElement("div");
        this.container = item;
            host.appendChild(item);
            item.className = "item";
            this.attrs.forEach((e, i) => {
                let x = document.createElement("label");
                item.appendChild(x);
                x.className = classes[i];
                x.innerHTML = e;
            });

            let table = document.createElement("table");
            item.appendChild(table);
            let thead = document.createElement("thead");
            table.appendChild(thead);
            let tr = document.createElement("tr");
            thead.appendChild(tr);
            let a = ["Sala", "Datum", "Vreme", "Karte"];
            a.forEach(ea => {
                let th = document.createElement("th");
                tr.appendChild(th);
                th.innerHTML = ea;
            });
            let tbody = document.createElement("tbody");
            table.appendChild(tbody);
            this.izvedbe.forEach(e => {
                e.draw(tbody);
            });

            item.onclick = (ev => 
                {
                    this.poz.select(this);
                    this.izvedbe.forEach((el, ind) => {
                        if(this.selectedIzv == el) {
                            this.selectedInd = ind;
                        }
                    });
                    this.export(this.poz.container);
                    this.container.style.backgroundColor = "#94b1b8";
                });
    }

    select(i) {
        if(this.selectedIzv != null) {
            this.selectedIzv.container.style.backgroundColor = "#7ca4ad";
        }
        this.selectedIzv = i;
    }

    export(parent) {
        let x = parent.querySelectorAll(".inputPredstava");
        x.forEach((el, ind) => {
            if(el.name == "radioChoice") {
                let x = parent.querySelector("input[value='" + this.attrs[ind] + "']");
                x.checked = true;
            }
            el.value = this.attrs[ind];
        });
    }
}