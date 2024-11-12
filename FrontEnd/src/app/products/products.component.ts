import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { ProductsService } from '../services/produts.service';
import { v4 as uuidv4 } from 'uuid';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit {
  products: Product[] = [];

  newProductName: string =""
  newProductPrice: number = 0

  editProductId: string = "";
  constructor(private productService: ProductsService) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe({
      next: (products) => this.products = products,
      error: (error) => alert('Error: Failed to load products')
    });
  }

  addProduct(): void {
    const product: Product = {
      id: uuidv4(),
      name: this.newProductName,
      cost: this.newProductPrice
    };
    this.productService.addProduct(product).subscribe({
      next: (product) => this.products.push(product),
      error: (error) => alert('Error: Failed to add product'),
      complete:()=> {
        this.newProductName = "";
        this.newProductPrice = 0
      },
    });
  }

  deleteProduct(id: string): void {
    this.productService.deleteProduct(id).subscribe({
      next: () => this.products = this.products.filter((product) => product.id !== id),
      error: (error) => alert('Error: Failed to delete product')
    });
  }

  editProduct(product: Product): void {
    this.editProductId = product.id;
  }

  updateProduct(product: Product): void {
    this.productService.updateProduct(product).subscribe({
      next: () => {
        const index = this.products.findIndex((p) => p.id === product.id);
        this.products[index] = product;
      },
      error: (error) => alert('Error: Failed to update product'),
      complete: () => {
        this.newProductName = "";
        this.newProductPrice = 0;
        this.editProductId = "";
      }
    });
  }
}
