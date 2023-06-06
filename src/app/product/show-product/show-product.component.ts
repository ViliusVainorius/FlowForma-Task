import { Component, OnInit } from '@angular/core';
import { ApiserviceService } from 'src/app/apiservice.service';

@Component({
  selector: 'app-show-product',
  templateUrl: './show-product.component.html',
  styleUrls: ['./show-product.component.css']
})
export class ShowProductComponent implements OnInit{

  constructor(private service: ApiserviceService) { }

  ProductList: any = [];
  ProductList2: any = [];
  ModalTitle = "";
  ActivateAddProdComp: boolean = false;
  prod: any;

  ngOnInit(): void {
      this.refreshProductList();
  }

  addClick(){
    this.prod = {
      id: 0,
      name: "name",
      price: 0,
      description: "description",
      type: 0,
      lenght: 0,
      diameter: 0,
      brand: "brand",
      size: 0
    }
    this.ModalTitle = "Add Product";
    this.ActivateAddProdComp = true;
  }


  deleteClick(item: any){
    if(confirm('Are you sure??')) {
      this.service.deleteProduct(item.id).subscribe(data => {
        alert("Product deleted!");
        this.refreshProductList();
      })

    }
  }

  closeClick() {
    this.ActivateAddProdComp = false;
    this.refreshProductList();
  }

  refreshProductList() {
    this.service.getProductList().subscribe(data => {
      this.ProductList = data;
      this.ProductList2 = this.ProductList.value;
      console.log("Response data:", this.ProductList.value);
    });
  }

  objectToArray(obj: any): any[] {
    return Object.entries(obj);
  }

}
