import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';

@Component({
  selector: 'app-clientes-lista',
  templateUrl: './clientes-lista.component.html',
  styleUrls: ['./clientes-lista.component.css']
})
export class ClientesListaComponent implements OnInit {

  constructor() { }

  titulo: string = 'Ver Detalhes';

  @ViewChildren('listItem')
  public listItems!: QueryList<ElementRef<HTMLDivElement>>

  public ngAfterViewInit() {
  }

  expandMenu(index: number): void{
    let currentItem = this.listItems.get(index)?.nativeElement;

    if(this.listItems.length > 1){
      this.listItems.forEach(item => {
        if(item.nativeElement != currentItem){
          item.nativeElement.classList.add('collapsed');
        }
      });
    }

    currentItem?.classList.toggle('collapsed');
  }

  ngOnInit() {
  }

}
