export class OrderItemModel {
    public productId: string;
    public quantity: number;
    public name: string;

    constructor(id: string, qty: number, name:string) {
        this.productId = id;
        this.quantity = Number(qty);
        this.name = name;
    }
}
