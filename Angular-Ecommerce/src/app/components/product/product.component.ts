import { Component, OnInit } from '@angular/core';
import { IProduct } from '../../../Models/i-product';
import { ProductApiService } from '../../../Services/product-api.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-product',
  standalone: true,
  imports:  [CommonModule,FormsModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit {
  products: IProduct[] = [] as IProduct[];
  showPopup = false; 
  newProduct: IProduct = { id: 0, name: '', price: 0 };
  selectedProduct: IProduct = { id: 0, name: '', price: 0 };
  showUpdateModal: boolean = false;


  constructor(private productService: ProductApiService) {} 


  ngOnInit(): void {
    console.log('AppComponent initialized');

    
    this.loadProducts();
  }


  loadProducts(): void {
    this.productService.GetAllProducts().subscribe(data => {
      console.log('Data received:', data); 
      this.products = data;
    }, error => {
      console.error('Error fetching data:', error); 
    });
  }


  delete(id : number) {
    this.productService.deleteProduct(id)
      .subscribe(
        (res) => {
          // Successful deletion
          console.log('Product deleted successfully:', res);
  
          this.products = this.products.filter(p => p.id !== id); // Remove from filtered list
          console.log(id);
          
        },
        (error) => {
          // Handle error
          console.error('Error deleting product:', error);
        }
      );
  }


  openPopup(): void {
    this.showPopup = true;
  }

  closePopup(): void {
    this.showPopup = false;
  }

  addProduct(): void {
    if (this.newProduct.name && this.newProduct.price) {
      this.productService.AddProduct(this.newProduct).subscribe(() => {
        this.loadProducts(); 
        this.closePopup();
      });
    }
  }




  openUpdateModal(product: IProduct) {
    this.selectedProduct = { ...product }; 
    this.showUpdateModal = true;
    console.log("Selected Product for Update:", this.selectedProduct);
  }
  
closeUpdateModal() {
  this.showUpdateModal = false;
}

updateProduct() {
  if (!this.selectedProduct.id) {
    console.error("Product ID is missing");
    return;
  }

  this.productService.UpdateProduct(this.selectedProduct).subscribe({
    next: (updatedProduct) => {
      console.log("Product updated successfully:", updatedProduct);
      this.loadProducts(); // Refresh product list
      this.closeUpdateModal();
    },
    error: (err) => console.error("Error updating product:", err),
  });
}

}
