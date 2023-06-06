import { Component, OnInit, Input } from '@angular/core';
import { ApiserviceService } from 'src/app/apiservice.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  constructor(private service: ApiserviceService) { }

  @Input() prod: any;
  id = 0;
  name = "";
  price = 0;
  description = "";
  type = 0;

  ngOnInit(): void {
    this.id = this.prod.id;
    this.name = this.prod.name;
    this.price = this.prod.price;
    this.description = this.prod.description;
    this.type = parseInt(this.prod.type);
  }

  addProduct(): void {
    var pro = {
      id: this.id,
      name: this.name,
      price: this.price,
      description: this.description,
      type: parseInt(this.prod.type)

    };
    console.log(pro);

    if(this.type == 0){
      this.service.addProductClothing(pro).subscribe(res => {
        alert("Product has been added!");
      });
    }else if (this.type == 1) {
      this.service.addProductShoes(pro).subscribe(res => {
        alert("Product has been added!");
      });
    }
  }

  addProductClothing() {
    var pro = {
      id: this.id,
      name: this.name,
      price: this.price,
      description: this.description,
      type: this.type

    };
    this.service.addProductClothing(pro).subscribe(res => {
      alert(res.toString());
    });
  }

  addProductShoes() {
    var pro = {
      id: this.id,
      name: this.name,
      price: this.price,
      description: this.description,
    };
    this.service.addProductShoes(pro).subscribe(res => {
      alert(res.toString());
    });
  }

  
}
